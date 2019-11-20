namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class SaleExportDto
    {
        [JsonProperty("car")]
        public CarExportDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
