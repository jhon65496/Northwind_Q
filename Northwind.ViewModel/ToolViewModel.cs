using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Northwind.ViewModel
{
    public class ToolViewModel
    {
        private readonly IToolManager _toolManager;
        public string DisplayName { get; set; }

        private ICommand _closeCommand = null;

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(Close));

        public ToolViewModel(IToolManager toolManager)
        {
            _toolManager = toolManager;
        }

        public void Close()
        {
            _toolManager.CloseTool(this);
        }
    }
}
