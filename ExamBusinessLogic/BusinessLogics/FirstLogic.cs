using System;
using System.Collections.Generic;
using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;


namespace ExamBusinessLogic.BusinessLogics
{
    public class FirstLogic
    {
        private readonly IFirstStorage _firstStorage;
        public FirstLogic(IFirstStorage firstStorage)
        {
            _firstStorage = firstStorage;
        }
        public List<FirstViewModel> Read(FirstBindingModel model)
        {
            if (model == null)
            {
                return _firstStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FirstViewModel> { _firstStorage.GetElement(model)
                };
            }
            return _firstStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FirstBindingModel model)
        {
            var element = _firstStorage.GetElement(new FirstBindingModel
            {
                FirstName = model.FirstName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть что-то с таким названием");
            }
            if (model.Id.HasValue)
            {
                _firstStorage.Update(model);
            }
            else
            {
                _firstStorage.Insert(model);
            }
        }
        public void Delete(FirstBindingModel model)
        {
            var element = _firstStorage.GetElement(new FirstBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _firstStorage.Delete(model);
        }
    }
}
