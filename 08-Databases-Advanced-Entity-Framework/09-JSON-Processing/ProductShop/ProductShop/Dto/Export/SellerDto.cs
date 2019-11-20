namespace ProductShop.Dto.Export
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class SellerDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public List<SoldProductDto> SoldProducts { get; set; }
    }
}
