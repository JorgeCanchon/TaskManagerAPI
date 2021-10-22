using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces.Repositories;

namespace TaskManager.Core.UsesCases.Tasks
{
    public class TaskInteractor : ITaskInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TaskInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public Response DeleteTask(int id)
        {
            Func<Response> func = () =>
            {
                var entity = _repositoryWrapper.TaskRepository
                            .FindByCondition(x => x.Id == id)
                            .FirstOrDefault();

                if (entity == null)
                    return new Response() { Status = 202, Message = $"No se existe la tarea con id:{id}", Payload = null };

                var result = _repositoryWrapper.TaskRepository.Delete(entity);

                return result == EntityState.Deleted ?
                       new Response() { Status = 200, Message = "Tarea eliminada con éxito", Payload = entity.Id } :
                       new Response() { Status = 202, Message = "No se pudo eliminar la tarea", Payload = null };
            };

            return GetStatus(func);
        }

        public Response GetTasks()
        {
            Func<Response> func = () =>
            {
                var tasks = _repositoryWrapper.TaskRepository.FindAll();

                return tasks.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = tasks } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            };

            return GetStatus(func);
        }

        public Response InsertTask(TaskEntity task)
        {
            Func<Response> func = () =>
            {
                var entity = _repositoryWrapper.TaskRepository.Create(task);

                return entity.Id >= 0 ?
                     new Response() { Status = 201, Message = "Tarea creada con éxito", Payload = task.Id } :
                     new Response() { Status = 400, Message = "No se pudo crear la tarea", Payload = null };
            };

            return GetStatus(func);
        }

        public Response UpdateTask(TaskEntity task)
        {
            Func<Response> func = () =>
            {
                var result = _repositoryWrapper.TaskRepository.Update(task, "Id");
                return result == EntityState.Modified ?
                        new Response() { Status = 200, Message = "Tarea modificada con éxito", Payload = null } :
                        new Response() { Status = 400, Message = "No se pudo modificar la Tarea", Payload = null };
            };

            return GetStatus(func);
        }

        public Response GetStatus(Func<Response> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
