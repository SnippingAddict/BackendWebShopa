using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int Qty { get; set; }
        [JsonIgnore]
        public ShoppingDetail ShoppingDetail { get; set; }
        [ForeignKey("ShoppingDetail")]
        public int ProductId { get; set; }


    }

}
