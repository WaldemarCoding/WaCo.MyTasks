using Prism.Ioc;
using WaCo.MyTasks.DesktopUI.Views;
using System.Windows;
using Microsoft.Extensions.Logging;
using Prism.Modularity;
using WaCo.MyTasks.DataAccess;
using WaCo.MyTasks.Services;
using WaCo.MyTasks.Services.Interfaces;
using WaCo.MyTasks.ToDo;

namespace WaCo.MyTasks.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ITaskEntryService, TaskEntryService>();
            containerRegistry.Register<ITaskEntryRepository, TaskEntryRepository>();

            var logger = CreateLogger();
            containerRegistry.RegisterInstance(logger);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ToDoModule>();
        }

        private ILogger CreateLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .SetMinimumLevel(LogLevel.Debug)
                    .AddFile("Logs/logfile-{Date}.log");
            });
            ILogger logger = loggerFactory.CreateLogger("WaCo.MyTasks.Log");
            return logger;
        }
    }
}
