using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.UsesCases.Tasks;
using TaskManager.Core.UsesCases.User;

namespace TaskManager.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TaskInteractor>().As<ITaskInteractor>().SingleInstance();
            builder.RegisterType<UserInteractor>().As<IUserInteractor>().SingleInstance();
        }
    }
}
