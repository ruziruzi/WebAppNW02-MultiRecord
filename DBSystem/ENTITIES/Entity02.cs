using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBSystem.ENTITIES
{
    [Table("Player")]
    public class Entity02
    {
        private string gender;
        [Key]
        public int PlayerID { get; set; }
        public int? GuardianID { get; set; }
        public int? TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public int Age { get; set; }
        public string Gender { 
            get { return gender; } 
            set {
                if (value == "M")
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
            } 
        }
        public string AlbertaHealthCareNumber { get; set; }
        public string MedicalAlertDetails { get; set; }
        [NotMapped]
        public string PlayerName {
            get {
                return LastName + ", " + FirstName;
            }
        }

        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public string PlayerAndID {
            get {
                return FullName + "(" + PlayerID + ")";
            }
        }
    }
}
