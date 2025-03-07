using Avalonia;
using Avalonia.Controls;
using GazizovUP1.ViewModels;
using Avalonia.Markup.Xaml;
using ShowJuryViewModel = GazizovUP1.ViewModels.ShowJuryViewModel;

namespace GazizovUP1;

public partial class ShowJury : UserControl
{
    public ShowJury()
    {
        InitializeComponent();
        DataContext = new ShowJuryViewModel();
    }
}