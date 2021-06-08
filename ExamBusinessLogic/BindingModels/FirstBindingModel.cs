using System;

namespace ExamBusinessLogic.BindingModels
{
    public class FirstBindingModel
    {
        public int? Id { get; set; }
        
        public string FirstName { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }
    }
}
