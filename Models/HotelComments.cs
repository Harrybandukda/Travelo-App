using COMP2139_Assignment1.Models;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment2.Models
{
    public class HotelComments
    {
        [Key]
        public int HotelCommentID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The comment should not exceed 500 characters!")]
        public string? Content { get; set; }

        [Display(Name = "Posted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime DatePosted { get; set; }

        public int HotelsId { get; set; }

        public Hotels? Hotel {  get; set; }

    }
}
