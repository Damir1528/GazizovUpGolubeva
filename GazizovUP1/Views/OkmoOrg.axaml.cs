using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GazizovUP1.ViewModels;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System;
using Avalonia.Interactivity;

namespace GazizovUP1;

public partial class OkmoOrg : UserControl
{
    public OkmoOrg()
    {
        InitializeComponent();
        DataContext = new OknoOrgViewModel();
        var hour = DateTime.Now.Hour;
        if (hour >= 9 && hour <= 11)
            Day.Text = "������ ����";
        else if (hour >= 11 && hour <= 18)
            Day.Text = "������ ����";
        else
            Day.Text = "������ �����";
    }

    private void Button_Click_Uchastniki(object sender, RoutedEventArgs e)
    {
        Info dataWindow = new Info("������ �� ����������...");
        //dataWindow.Info();
    }

    private void Button_Click_Juri(object sender, RoutedEventArgs e)
    {
        Info dataWindow = new Info("������ � ����...");
        //dataWindow.Info();
    }
}