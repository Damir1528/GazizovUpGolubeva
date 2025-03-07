using Avalonia;
using Avalonia.Controls;
using GazizovUP1.ViewModels;
using Avalonia.Markup.Xaml;
using ShowModeratorViewModel = GazizovUP1.ViewModels.ShowModeratorViewModel;

namespace GazizovUP1;

public partial class ShowModerator : UserControl
{
    public ShowModerator()
    {
        InitializeComponent();
        DataContext = new ShowModeratorViewModel();
    }
}