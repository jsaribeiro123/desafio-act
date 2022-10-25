using System.ComponentModel.DataAnnotations;

namespace Razor.Nft.Models
{
    public class Lancamento
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}