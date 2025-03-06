using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GazizovUP1;

public partial class Info : UserControl
{
    public Info(string data)
    {
            InitializeComponent();
            DataTextBlock.Text = data; // Установка текста в TextBlock
    }
}
