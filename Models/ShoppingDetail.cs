using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class ShoppingDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Cart Carts { get; set; }

    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Categories { get; set; }
        [JsonIgnore]
        public IEnumerable<ShoppingDetail> ShoppingDetails { get; set; }
    }


}