using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDatabaseImplement.Models
{
    public class Second
    {
        public int Id { get; set; }

        public int FirstId { get; set; }

        [Required]
        public string SecondName { get; set; }

        public First First { get; set; }
    }
}
