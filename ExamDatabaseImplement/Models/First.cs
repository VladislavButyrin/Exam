using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamDatabaseImplement.Models
{
    public class First
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
