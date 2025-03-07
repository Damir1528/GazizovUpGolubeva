using Avalonia;
using Avalonia.Controls;
using GazizovUP1.ViewModels;
using Avalonia.Markup.Xaml;

namespace GazizovUP1;

public partial class Profile : UserControl
{
    public Profile()
    {
        InitializeComponent();
        DataContext = new ProfileViewModel();
    }
}