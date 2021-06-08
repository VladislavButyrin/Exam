using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.Interfaces
{
    public interface ISecondStorage
    {
        List<SecondViewModel> GetFullList();
        List<SecondViewModel> GetFilteredList(SecondBindingModel model);
        SecondViewModel GetElement(SecondBindingModel model);
        void Insert(SecondBindingModel model);
        void Update(SecondBindingModel model);
        void Delete(SecondBindingModel model);

    }
}
