using System.ComponentModel.DataAnnotations;

namespace Razor.Nft.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}