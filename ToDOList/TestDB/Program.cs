using DBLibrary.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkDetail entity = new WorkDetail()
            {
                Id = 2,
                WorkContent = "22222",
                Important = "Y",
                PlanDate = DateTime.Now,
                CreationDate = DateTime.Now,
                LastUpdataDate = DateTime.Now
            };

            Class1 service = new Class1();
            service.Create(entity);
        }
    }
}
