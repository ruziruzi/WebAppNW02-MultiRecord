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
        [Key]
        public int PlayerID { get; set; }
        public int GuardianID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string AlbertaHealthCareNumber { get; set; }
        public string MedicalAlertDetails { get; set; }
        //public int ProductID { get; set; }
        //public string ProductName { get; set; }
        //public int? SupplierID { get; set; }
        //public int? CategoryID { get; set; }
        //public string QuantityPerUnit { get; set; }
        //public decimal? UnitPrice { get; set; }
        //public Int16? UnitsInStock { get; set; }
        //public Int16? UnitsOnOrder { get; set; }
        //public Int16? ReorderLevel { get; set; }
        //public bool Discontinued { get; set; }

        //[NotMapped]
        //public string ProductandID
        //{
        //    get
        //    {
        //        return ProductName + "(" + ProductID + ")";
        //    }
        //}
    }
}
