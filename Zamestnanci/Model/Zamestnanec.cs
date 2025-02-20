using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace ZamestnanciManagement.Model
{
    public class Zamestnanec
    {

       
        public int Id { get; set; }
        [Required]
        public string  Prijmeni {get; set; }
            
        [Required]
        public string Jmeno { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; } = null;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null;

       
    }
}
