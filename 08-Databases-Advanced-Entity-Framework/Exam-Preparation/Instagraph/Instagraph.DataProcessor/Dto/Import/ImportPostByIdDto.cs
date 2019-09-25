namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class ImportPostByIdDto
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }
}
