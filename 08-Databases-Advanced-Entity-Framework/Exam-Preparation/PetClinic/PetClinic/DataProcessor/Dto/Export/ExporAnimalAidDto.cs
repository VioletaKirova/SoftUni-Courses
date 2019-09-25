namespace PetClinic.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class ExporAnimalAidDto
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public decimal Price { get; set; }
    }
}
