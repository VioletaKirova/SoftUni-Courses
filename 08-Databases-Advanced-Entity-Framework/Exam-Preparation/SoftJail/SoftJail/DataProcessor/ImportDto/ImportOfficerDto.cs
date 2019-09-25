namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [XmlElement]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement]
        [Required]
        public string Position { get; set; }

        [XmlElement]
        [Required]
        public string Weapon { get; set; }

        [XmlElement]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerWithId[] Prisoners { get; set; }
    }
}
