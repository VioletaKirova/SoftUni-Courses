namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Dto.Import;
    using Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var allAnimalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var validAnimalAids = new List<AnimalAid>();

            StringBuilder sb = new StringBuilder();

            foreach (var animalAid in allAnimalAids)
            {
                if (!IsValid(animalAid) || validAnimalAids.Select(x => x.Name).ToArray().Contains(animalAid.Name))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                validAnimalAids.Add(animalAid);

                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalDtos = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            var animals = new List<Animal>();
            var passportSerialNumbers = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (var animalDto in animalDtos)
            {
                if (!IsValid(animalDto) || 
                    !IsValid(animalDto.Passport) || 
                    passportSerialNumbers.Contains(animalDto.Passport.SerialNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                passportSerialNumbers.Add(animalDto.Passport.SerialNumber);

                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = new Passport
                    {
                        SerialNumber = animalDto.Passport.SerialNumber,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        OwnerName = animalDto.Passport.OwnerName,
                        RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                    }
                };

                animals.Add(animal);

                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var xmlSetializer = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));

            var vetDtos = (ImportVetDto[])xmlSetializer.Deserialize(new StringReader(xmlString));

            var vets = new List<Vet>();
            var phoneNumbers = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (var vetDto in vetDtos)
            {
                if (!IsValid(vetDto) || phoneNumbers.Contains(vetDto.PhoneNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                phoneNumbers.Add(vetDto.PhoneNumber);

                var vet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                vets.Add(vet);

                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var xmlSetializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var procedureDtos = (ImportProcedureDto[])xmlSetializer.Deserialize(new StringReader(xmlString));

            var procedures = new List<Procedure>();

            StringBuilder sb = new StringBuilder();

            foreach (var procedureDto in procedureDtos)
            {
                if (!IsValid(procedureDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vetNames = context.Vets.Select(v => v.Name).ToArray();
                var animalSerialNumbers = context.Animals.Select(a => a.PassportSerialNumber).ToArray();
                
                var allAnimalAidNames = procedureDto.AnimalAids.Select(a => a.Name).ToArray();
                var distinctAnimalAidNames = procedureDto.AnimalAids.Select(a => a.Name).Distinct().ToArray();

                var animalAidNames = context.AnimalAids.Select(a => a.Name).ToArray();

                var areAnimalAidsValid = true;

                foreach (var animalAid in procedureDto.AnimalAids)
                {
                    if (!animalAidNames.Contains(animalAid.Name))
                    {
                        areAnimalAidsValid = false;
                        break;
                    }
                }

                if (!vetNames.Contains(procedureDto.Vet) ||
                    !animalSerialNumbers.Contains(procedureDto.Animal) ||
                    allAnimalAidNames.Length != distinctAnimalAidNames.Length ||
                    !areAnimalAidsValid)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var procedure = new Procedure
                {
                    Animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == procedureDto.Animal),
                    Vet = context.Vets.FirstOrDefault(v => v.Name == procedureDto.Vet),
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ProcedureAnimalAids = procedureDto.AnimalAids.Select(a => new ProcedureAnimalAid
                    {
                        AnimalAid = context.AnimalAids.FirstOrDefault(aa => aa.Name == a.Name)
                    })
                    .ToArray()
                };

                procedures.Add(procedure);

                sb.AppendLine($"Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}
