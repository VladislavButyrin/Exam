using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.Interfaces
{
    public interface IFirstStorage
    {
        List<FirstViewModel> GetFullList();
        List<FirstViewModel> GetFilteredList(FirstBindingModel model);
        FirstViewModel GetElement(FirstBindingModel model);
        void Insert(FirstBindingModel model);
        void Update(FirstBindingModel model);
        void Delete(FirstBindingModel model);

    }
}
