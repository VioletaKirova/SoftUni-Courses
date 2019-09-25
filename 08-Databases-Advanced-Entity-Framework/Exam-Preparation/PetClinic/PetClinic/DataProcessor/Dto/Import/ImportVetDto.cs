namespace PetClinic.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [XmlElement]
        [Range(22, 65)]
        public int Age { get; set; }

        [XmlElement]
        [Required]
        [RegularExpression(@"(^\+359[0-9]{9}$)|(^0[0-9]{9}$)")]
        public string PhoneNumber { get; set; }
    }
}
