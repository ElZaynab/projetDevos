using System.ComponentModel.DataAnnotations;

namespace LibraryManagement
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"\d{10}|\d{13}", ErrorMessage = "ISBN must be 10 or 13 digits")]
        public string ISBN { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(1000, 3000)]
        public int Year { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; }
    }
}
