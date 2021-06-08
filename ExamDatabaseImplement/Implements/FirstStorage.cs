using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using ExamDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamDatabaseImplement.Implements
{
    public class FirstStorage : IFirstStorage
    {
        public List<FirstViewModel> GetFullList()
        {
            using (var context = new ExamDatabase())
            {
                return context.Firsts
                .Select(rec => new FirstViewModel
                {
                    Id = rec.Id,
                    FirstName = rec.FirstName,
                    Type = rec.Type,
                    Date = rec.Date
                })
               .ToList();
            }
        }
        public List<FirstViewModel> GetFilteredList(FirstBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                return context.Firsts
                .Where(rec => rec.FirstName.Contains(model.FirstName))
               .Select(rec => new FirstViewModel
               {
                   Id = rec.Id,
                   FirstName = rec.FirstName,
                   Type = rec.Type,
                   Date = rec.Date
               })
                .ToList();
            }
        }
        public FirstViewModel GetElement(FirstBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                var first = context.Firsts
                .FirstOrDefault(rec => rec.FirstName == model.FirstName ||
               rec.Id == model.Id);
                return first != null ?
                new FirstViewModel
                {
                    Id = first.Id,
                    FirstName = first.FirstName,
                    Type = first.Type,
                    Date = first.Date
                } :
               null;
            }
        }
        public void Insert(FirstBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                context.Firsts.Add(CreateModel(model, new First()));
                context.SaveChanges();
            }
        }
        public void Update(FirstBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                var element = context.Firsts.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(FirstBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                First element = context.Firsts.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Firsts.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private First CreateModel(FirstBindingModel model, First first)
        {
            first.FirstName = model.FirstName;
            first.Type = model.Type;
            first.Date = model.Date;
            return first;
        }

    }
}
