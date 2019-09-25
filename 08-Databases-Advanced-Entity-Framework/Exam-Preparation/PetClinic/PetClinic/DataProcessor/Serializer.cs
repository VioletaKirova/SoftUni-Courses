namespace PetClinic.DataProcessor
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Dto.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.PassportSerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(a => a.Age)
                .ThenBy(a => a.SerialNumber)
                .ToArray();

            var result = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(p => p.DateTime)
                .ThenBy(p => p.Animal.PassportSerialNumber)
                .Select(p => new ExportProcedureDto
                {
                    Passport = p.Animal.PassportSerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids.Select(paa => new ExporAnimalAidDto
                    {
                        Name = paa.AnimalAid.Name,
                        Price = paa.AnimalAid.Price
                    })
                    .ToArray(),
                    TotalPrice = $"{p.Cost:f2}"
                }) 
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            var sb = new StringBuilder();
            xmlSerializer.Serialize(new StringWriter(sb), procedures, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
