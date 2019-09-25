namespace PetClinic.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement]
        [Required]
        public string Vet { get; set; }

        [XmlElement]
        [Required]
        public string Animal { get; set; }

        [XmlElement]
        [Required]
        public string DateTime { get; set; }

        [XmlArray]
        [Required]
        public ImportAnimalAidDto[] AnimalAids { get; set; }
    }
}
