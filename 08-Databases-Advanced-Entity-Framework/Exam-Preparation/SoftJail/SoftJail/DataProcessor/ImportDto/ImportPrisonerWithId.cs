namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ImportPrisonerWithId
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
