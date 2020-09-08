using DBLibrary.DBModel;
using DBLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_01.ViewModel;

namespace ToDoList_01.Service
{
    public class ToDoListService
    {
        public ObservableCollection<ItemsViewModel> GetJobList(string dateString)
        {
            ToDoModel context = new ToDoModel();

            var repository = new ToDoRepository<WorkDetail>(context);
            var result  = new ObservableCollection<ItemsViewModel>();
            IQueryable<WorkDetail> data;
            if (dateString.Equals(string.Empty))
            {
                data = repository.GetAll();
            }
            else
            {
                data = repository.GetAll().Where((x)=>x.CreationDate.ToString() == dateString);
            }
            foreach (var item in data)
            {
                result.Add(
                    new ItemsViewModel
                    {   
                        Id = item.Id,
                        WorkContent = item.WorkContent,
                        Completed = item.Complete == "Y" ? true : false,
                        IsImportant = item.Important == "Y" ? true : false
                    });
            }

            return result;
        }

        public OperationResult AddJobs(ItemsViewModel items)
        {
            var result = new OperationResult();
            try
            {
                ToDoModel context = new ToDoModel();
                var repository = new ToDoRepository<WorkDetail>(context);
                WorkDetail entity = new WorkDetail()
                {
                    WorkContent = items.WorkContent,
                    Important = items.IsImportant ? "Y" : "N",
                    Complete = items.Completed ? "Y" : "N",
                    CreationDate = DateTime.Now,
                    PlanDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                };

                repository.Create(entity);
                context.SaveChanges();
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.exception = ex;
            }

            return result;
        }


    }
}
