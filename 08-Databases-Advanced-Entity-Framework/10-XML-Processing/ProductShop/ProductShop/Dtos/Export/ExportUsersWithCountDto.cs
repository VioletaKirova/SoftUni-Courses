namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class ExportUsersWithCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserProductsDto[] Users { get; set; }
    }
}
