using System.ComponentModel.DataAnnotations;

namespace ExamTP.Models
{
    public class Management
    {
        public int ManagementId { get; set; }

        [Required]
        public string Name { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public int Salary { get; set;}
        public DateTime Date { get; set;}
        
    }
}
