﻿using Prism.Ioc;
using WaCo.MyTasks.DesktopUI.Views;
using System.Windows;
using Prism.Modularity;
using WaCo.MyTasks.DataAccess;
using WaCo.MyTasks.Services;
using WaCo.MyTasks.ToDo;

namespace WaCo.MyTasks.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ITaskService, TaskService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ToDoModule>();
        }
    }
}
