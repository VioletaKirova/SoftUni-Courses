namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class ImportCommentDto
    {
        [XmlElement("content")]
        [Required]
        public string Content { get; set; }

        [XmlElement("user")]
        [Required]
        public string User { get; set; }

        [XmlElement("post")]
        [Required]
        public ImportPostByIdDto Post { get; set; }
    }
}
