namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPictureDto
    {
        [Required]
        public string Path { get; set; }

        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal Size { get; set; }
    }
}
