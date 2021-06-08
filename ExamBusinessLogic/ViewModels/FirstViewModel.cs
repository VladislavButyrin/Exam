using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.ViewModels
{
    public class FirstViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string FirstName { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        [DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}
