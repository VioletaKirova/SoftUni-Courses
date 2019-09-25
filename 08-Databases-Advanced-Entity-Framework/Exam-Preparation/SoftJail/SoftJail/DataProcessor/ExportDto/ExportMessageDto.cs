namespace SoftJail.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class ExportMessageDto
    {
        [XmlElement]
        public string Description { get; set; }

        public void ReverseDescription()
        {
            var description = this.Description.ToCharArray();

            Array.Reverse(description);

            this.Description = new string(description);
        }
    }
}
