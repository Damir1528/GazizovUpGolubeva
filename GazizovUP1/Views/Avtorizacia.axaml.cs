using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using GazizovUP1.ViewModels;

namespace GazizovUP1;

public partial class Avtorizacia : UserControl
{
    public Avtorizacia()
    {
        InitializeComponent();
        DataContext = new AvtorizaciaViewModel();
    }
}