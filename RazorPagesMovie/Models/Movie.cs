using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models {
    public class Movie {
        public int ID { get; set; } //The ID field is required by the database for the primary key
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)] // [DataType(DataType.Date)]: The DataType attribute specifies the type of the data (Date). With this attribute:
                                // -The user is not required to enter time information in the date field.
                                // -Only the date is displayed, not time information.
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set;}
        
        
        [StringLength(30), Required] //Two annotations combined on a single line
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [StringLength(5)]
        public string Rating { get; set; }
    }
}