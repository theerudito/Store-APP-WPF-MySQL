using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCompany
    {
        [Key]
        public string NameCompany { get; set; }
        public string NameOwner { get; set; }
        public string Direction { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string Phone { get; set; }
        public string NumDocument { get; set; }
        public string Serie1 { get; set; }
        public string Serie2 { get; set; }
        public string Document { get; set; }
        public string DataBase { get; set; }
        public string Iva { get; set; }
        public string Current { get; set; }

    }
}
