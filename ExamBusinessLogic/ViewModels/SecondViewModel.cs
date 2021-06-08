using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.ViewModels
{
    public class SecondViewModel
    {
        public int Id { get; set; }

        public int FirstId { get; set; }

        [DisplayName("Название")]
        public string SecondName { get; set; }

    }
}
