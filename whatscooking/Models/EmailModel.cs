using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace heartoflove.Models
{
    

        public class EmailModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            [DisplayName("Email address")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [DisplayName("Comments")]
            public string Comments { get; set; }
        }
    
}