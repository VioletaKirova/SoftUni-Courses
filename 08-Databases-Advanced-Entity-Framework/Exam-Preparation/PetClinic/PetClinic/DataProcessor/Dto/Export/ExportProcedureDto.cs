namespace PetClinic.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportProcedureDto
    {
        [XmlElement]
        public string Passport { get; set; }

        [XmlElement]
        public string OwnerNumber { get; set; }

        [XmlElement]
        public string DateTime { get; set; }

        [XmlArray]
        public ExporAnimalAidDto[] AnimalAids { get; set; }

        [XmlElement]
        public string TotalPrice { get; set; }
    }
}
