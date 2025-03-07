﻿using DBLibrary.DBModel;
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
        public ObservableCollection<ItemsViewModel> GetTaskList(string dateString)
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
                data = repository.GetAll().Where((x)=> x.CreationDate.ToString() == dateString && x.PlanDate == null);
            }
            foreach (var item in data)
            {
                result.Add(
                    new ItemsViewModel
                    {   
                        Id = item.Id,
                        WorkContent = item.WorkContent,
                        PlanedDate = item.PlanDate,
                        Completed = item.Complete == "Y" ? true : false,
                        IsImportant = item.Important == "Y" ? true : false
                    });
            }

            return result;
        }

        public ObservableCollection<ItemsViewModel> GetImportant()
        {
            ToDoModel context = new ToDoModel();

            var repository = new ToDoRepository<WorkDetail>(context);
            var result = new ObservableCollection<ItemsViewModel>();
            IQueryable<WorkDetail> data;
            data = repository.GetAll().Where((x) => x.Important == "Y" && x.Complete == "N");
            foreach (var item in data)
            {
                result.Add(
                    new ItemsViewModel
                    {
                        Id = item.Id,
                        WorkContent = item.WorkContent,
                        PlanedDate = item.PlanDate,
                        Completed = item.Complete == "Y" ? true : false,
                        IsImportant = item.Important == "Y" ? true : false
                    });
            }

            return result;
        }

        public ObservableCollection<ItemsViewModel> GetPlan()
        {
            ToDoModel context = new ToDoModel();
            var repository = new ToDoRepository<WorkDetail>(context);
            var result = new ObservableCollection<ItemsViewModel>();
            IQueryable<WorkDetail> data;
            data = repository.GetAll().Where((x) => x.PlanDate!=null && x.Complete == "N");
            foreach (var item in data)
            {
                result.Add(
                    new ItemsViewModel
                    {
                        Id = item.Id,
                        WorkContent = item.WorkContent,
                        PlanedDate = item.PlanDate,
                        Completed = item.Complete == "Y" ? true : false,
                        IsImportant = item.Important == "Y" ? true : false
                    });
            }

            return result;
        }

        public OperationResult AddTasks(ItemsViewModel items)
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
                    PlanDate = items.PlanedDate,
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
        public OperationResult Completed(int id)
        {
            var result = new OperationResult();
            try
            {
                ToDoModel context = new ToDoModel();
                var repository = new ToDoRepository<WorkDetail>(context);
                var FindById = repository.GetAll().Where((x) => x.Id == id).FirstOrDefault();
                FindById.Complete = FindById.Complete=="N"?"Y":"N";
                FindById.LastUpdateDate = DateTime.Now;
                repository.Update(FindById); 
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
        public OperationResult Important(int id)
        {
            var result = new OperationResult();
            try
            {
                ToDoModel context = new ToDoModel();
                var repository = new ToDoRepository<WorkDetail>(context);
                var FindById = repository.GetAll().Where((x) => x.Id == id).FirstOrDefault();
                FindById.Important = FindById.Important == "N" ? "Y" : "N";
                FindById.LastUpdateDate = DateTime.Now;
                repository.Update(FindById);
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

        public OperationResult Delete(int id)
        {
            var result = new OperationResult();
            try
            {
                ToDoModel context = new ToDoModel();
                var repository = new ToDoRepository<WorkDetail>(context);
                var FindById = repository.GetAll().Where((x) => x.Id == id).FirstOrDefault();
                repository.Delete(FindById);
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
