using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using ExamDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamDatabaseImplement.Implements
{
    public class SecondStorage : ISecondStorage
    {
        public List<SecondViewModel> GetFullList()
        {
            using (var context = new ExamDatabase())
            {
                return context.Seconds
                .Select(rec => new SecondViewModel
                {
                    Id = rec.Id,
                    FirstId = rec.FirstId,
                    SecondName = rec.SecondName
                })
               .ToList();
            }
        }
        public List<SecondViewModel> GetFilteredList(SecondBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                return context.Seconds
                .Where(rec => rec.SecondName.Contains(model.SecondName))
               .Select(rec => new SecondViewModel
               {
                   Id = rec.Id,
                   FirstId = rec.FirstId,
                   SecondName = rec.SecondName
               })
                .ToList();
            }
        }
        public SecondViewModel GetElement(SecondBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                var second = context.Seconds
                .FirstOrDefault(rec => rec.SecondName == model.SecondName ||
               rec.Id == model.Id);
                return second != null ?
                new SecondViewModel
                {
                    Id = second.Id,
                    FirstId = second.FirstId,
                    SecondName = second.SecondName
                } :
               null;
            }
        }
        public void Insert(SecondBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                context.Seconds.Add(CreateModel(model, new Second()));
                context.SaveChanges();
            }
        }
        public void Update(SecondBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                var element = context.Seconds.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(SecondBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                Second element = context.Seconds.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Seconds.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Second CreateModel(SecondBindingModel model, Second second)
        {
            second.SecondName = model.SecondName;
            second.FirstId = model.FirstId;
            return second;
        }

    }
}
