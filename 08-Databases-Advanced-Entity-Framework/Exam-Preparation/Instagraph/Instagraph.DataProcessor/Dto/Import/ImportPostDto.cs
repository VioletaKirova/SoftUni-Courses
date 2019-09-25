namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class ImportPostDto
    {
        [XmlElement("caption")]
        [Required]
        public string Caption { get; set; }

        [XmlElement("user")]
        [Required]
        public string User { get; set; }

        [XmlElement("picture")]
        [Required]
        public string Picture { get; set; }
    }
}
