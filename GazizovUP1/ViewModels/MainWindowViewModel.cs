using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using GazizovUP1.Models;
using Avalonia.Controls;
using ReactiveUI;

namespace GazizovUP1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        public MainWindowViewModel()
        {
            Instance = this;
        }

        public static PostgresContext myConnection = new PostgresContext();

        UserControl _pageContent = new Avtorizacia();

        public UserControl PageContent
        {
            get => _pageContent;
            set => this.RaiseAndSetIfChanged(ref _pageContent, value);
        }
    }
}
