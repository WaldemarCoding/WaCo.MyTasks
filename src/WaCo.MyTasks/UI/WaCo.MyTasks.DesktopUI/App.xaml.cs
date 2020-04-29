using Prism.Ioc;
using WaCo.MyTasks.DesktopUI.Views;
using System.Windows;

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

        }
    }
}
