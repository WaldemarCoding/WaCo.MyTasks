using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WaCo.MyTasks.Core;
using WaCo.MyTasks.ToDo.ViewModels;
using WaCo.MyTasks.ToDo.Views;

namespace WaCo.MyTasks.ToDo
{
    public class ToDoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RequestNavigate(RegionNames.ContentRegion, nameof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}