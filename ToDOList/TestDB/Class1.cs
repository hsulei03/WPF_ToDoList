using DBLibrary.DBModel;
using DBLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class Class1
    {
        public void Create(WorkDetail entity)
        {
            ToDoModel context = new ToDoModel();
            var repo = new ToDoRepository<WorkDetail>(context);
            repo.Create(entity);
            context.SaveChanges();

        }
    }
}
