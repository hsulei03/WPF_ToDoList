using DBLibrary.DBModel;
using DBLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_01.ViewModel;

namespace ToDoList_01.Service
{
    public class ToDoListService
    {
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
                    Important = items.IsImportant ? "Y" : "N"
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
