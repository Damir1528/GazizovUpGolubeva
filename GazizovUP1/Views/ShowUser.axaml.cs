using Avalonia;
using Avalonia.Controls;
using GazizovUP1.ViewModels;
using Avalonia.Markup.Xaml;
using ShowUserViewModel = GazizovUP1.ViewModels.ShowUserViewModel;

namespace GazizovUP1;

public partial class ShowUser : UserControl
{
    public ShowUser()
    {
        InitializeComponent();
        DataContext = new ShowUserViewModel();
    }
}