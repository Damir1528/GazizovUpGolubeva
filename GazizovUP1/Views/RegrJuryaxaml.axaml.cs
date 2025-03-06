using Avalonia;
using Avalonia.Controls;
using GazizovUP1.ViewModels;
using Avalonia.Markup.Xaml;

namespace GazizovUP1;

public partial class RegrJuryaxaml : UserControl
{
    public RegrJuryaxaml()
    {
        InitializeComponent();
        DataContext = new RegrJuryViewModel();
    }
}