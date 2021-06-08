using System;
using System.Collections.Generic;
using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;

namespace ExamBusinessLogic.BusinessLogics
{
    public class SecondLogic
    {
        private readonly ISecondStorage _secondStorage;
        public SecondLogic(ISecondStorage secondStorage)
        {
            _secondStorage = secondStorage;
        }
        public List<SecondViewModel> Read(SecondBindingModel model)
        {
            if (model == null)
            {
                return _secondStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SecondViewModel> { _secondStorage.GetElement(model)
                };
            }
            return _secondStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SecondBindingModel model)
        {
            var element = _secondStorage.GetElement(new SecondBindingModel
            {
                SecondName = model.SecondName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть что-то с таким названием");
            }
            if (model.Id.HasValue)
            {
                _secondStorage.Update(model);
            }
            else
            {
                _secondStorage.Insert(model);
            }
        }
        public void Delete(SecondBindingModel model)
        {
            var element = _secondStorage.GetElement(new SecondBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _secondStorage.Delete(model);
        }
    }
}
