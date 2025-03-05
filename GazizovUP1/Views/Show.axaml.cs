using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GazizovUP1.ViewModels;
namespace GazizovUP1;

public partial class Show : UserControl
{
    public Show()
    {
        InitializeComponent();
        DataContext = new ShowViewModel();
    }
}