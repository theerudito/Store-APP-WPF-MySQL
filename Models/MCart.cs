using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCart
    {
        [Key]
        public int IdCart { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public float P_Total { get; set; }
        public MClient Clients { get; set; }
        public MProduct Products { get; set; }
        public List<MDetailsCart> DetailsCart { get; set; } = new List<MDetailsCart>();
    }
}
