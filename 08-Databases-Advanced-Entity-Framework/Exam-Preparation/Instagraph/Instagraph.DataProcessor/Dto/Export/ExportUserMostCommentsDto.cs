namespace Instagraph.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class ExportUserMostCommentsDto
    {
        [XmlElement]
        public string Username { get; set; }

        [XmlElement]
        public int MostComments { get; set; }
    }
}
