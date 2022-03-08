using System.ComponentModel.DataAnnotations;

namespace MTNMOMOApiIntegration.Model
{
    public class MtnMomoApiRequest
    {
        [Key]
        public long Id { get; set; }
        public string? Token { get; set; }
    }
}
