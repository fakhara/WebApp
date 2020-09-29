using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Wexnet
    {
        static int idCount = 0;
        public static List<Wexnet> DBWexnet = new List<Wexnet>();
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Hestighet")]
        public string Hestighet { get; set; }
        [Required(ErrorMessage = "Enter RingNamn")]
        public string RingNamn { get; set; }
        [Required(ErrorMessage = "Enter IP Adress Dist A")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")]
        public string IPAdressDistA { get; set; }
        [Required(ErrorMessage = "Enter Port Dist A")]
        public string PortDistA { get; set; }
        [Required(ErrorMessage = "Enter IP Adress Dist B")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")]
        public string IPAdressDistB { get; set; }
        [Required(ErrorMessage = "Enter Port Dist B")]
        public string PortDistB { get; set; }
        public Wexnet()
        {
            Id = idCount++;
            if(Id ==0)
            {
                Wexnet.DBWexnet.Add(new Wexnet { Hestighet = "10", RingNamn = "wex1234", IPAdressDistA = "1.1.1.2", PortDistA = "1", IPAdressDistB = "2.2.2.3", PortDistB = "1" });
                Wexnet.DBWexnet.Add(new Wexnet { Hestighet = "1", RingNamn = "wex1080", IPAdressDistA = "10.105.4.116", PortDistA = "7", IPAdressDistB = "10.105.4.135", PortDistB = "29" });
                
            }

        }
    }
}
