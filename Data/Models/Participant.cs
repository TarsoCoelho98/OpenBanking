using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OpenBanking.Data.Models
{
    public class Participant
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Api Url")]
        public string ApiEndpointUrl { get; set; }
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }
    }
}
