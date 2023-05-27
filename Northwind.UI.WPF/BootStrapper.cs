using Northwind.ViewModel;
using StructureMap;

namespace Northwind.UI.WPF
{
    public class BootStrapper
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return ObjectFactory.GetInstance<MainWindowViewModel>();
            }
        }

        public BootStrapper()
        {
            ObjectFactory.Initialize(
                o => o.Scan(
                    a =>
                    {
                        a.WithDefaultConventions();
                        a.AssembliesFromApplicationBaseDirectory(
                            d => d.FullName.StartsWith("Northwind"));
                        a.LookForRegistries();
                    }));
        }

    }
}
