using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GazizovUP1.Models;
using GazizovUP1.ViewModels;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;

namespace GazizovUP1;

public partial class Avtorizacia : UserControl
{
    private AvtorizaciaViewModel _captchaViewModel;
    public Avtorizacia()
    {
        InitializeComponent();
        _captchaViewModel = new AvtorizaciaViewModel();
        EnterButton1 = this.FindControl<Button>("EnterButton1");
        EnterButton1.IsEnabled = false;
        EnterButton1.IsVisible = false;
        captchaTextBox.IsEnabled = false;
        captchaTextBox.IsVisible = false;
        RefreshCaptcha.IsEnabled = false;
        RefreshCaptcha.IsVisible = false;
    }
    public void autorization(object sender, RoutedEventArgs e)
    {
        AvtorizaciaViewModel page1 = new AvtorizaciaViewModel();
        page1.prover = false;
        string login2 = login.Text;
        string password2 = password.Text;
        page1.autorization = true;
        if ((login2 == "1" && password2 == "organizator123") || (login2 == "2" && password2 == "jury123") || (login2 == "3" && password2 == "user123") || (login2 == "4" && password2 == "moderator123"))
        {
            ShowMessage.Text = "�� ������� ��������������! \n ������� �� ������ Open � ��������� 4 �������";
            EnterButton1.IsEnabled = true;
            EnterButton1.IsVisible = true;
            ChangeMessageAdd(login2);
        }
        else
        {
            ShowMessage.Text = "�������� ����� ��� ������";
            // ������ ������ Enter
            EnterButton.IsEnabled = false;
            EnterButton.IsVisible = false; // ������ ���������

            //CanvasCaptha.Children.Clear();
            //CanvasCaptha.Children.Add(AvtorizaciaViewModel.Can);
            //captchaTextBox.IsEnabled = true;
            //captchaTextBox.IsVisible = true;
            //RefreshCaptcha.IsEnabled = true;
            //RefreshCaptcha.IsVisible = true;
            ChangeMessageAdd("5"); // ������ �����������
        }
    }

    private async void ChangeMessageAdd(string role)
    {
        string message = role switch
        {
            "1" => "�� ������������������ ��� �������������",
            "2" => "�� ������������������ ��� ����",
            "3"=> "�� ������������������ ��� �������������",
            "4"=> "�� ������������������ ��� �����������",
            _ => "������, ��������� ����� ��� ������"
        };

        await MessageBoxManager.GetMessageBoxStandard("����", message, ButtonEnum.Ok).ShowAsync();
        MainWindowViewModel.myConnection.SaveChanges();
        MainWindowViewModel.Instance.PageContent = new OkmoOrg();
    }
    
    //private bool _isCapthcaValid = false;
    //public string CaptchaValue;
    //private void RefreshCaptcha_Click(object sender, RoutedEventArgs e)
    //{
    //    string enteredCaptcha = captchaTextBox.Text;
    //    if (enteredCaptcha.ToLower() == AvtorizaciaViewModel.CaptchaValue.ToLower())
    //    {
    //        _isCapthcaValid = true;
    //        // ����� ������� �����
    //        // ����� ��������� ���������� ��������
    //        ShowMessages.Text = "����� ������� �����!";
    //        EnterButton.IsEnabled = true;
    //        EnterButton.IsVisible = true;
    //        captchaTextBox.IsEnabled = false;
    //        captchaTextBox.IsVisible = false;
    //        RefreshCaptcha.IsEnabled = false;
    //        RefreshCaptcha.IsVisible = false;
    //    }
    //    else
    //    {
    //        _isCapthcaValid = false;
    //        // ����� ������� �������
    //        // ��������� ����� � ���� ��� ���� �������
    //        AvtorizaciaViewModel.CreateCaptha();
    //        CanvasCaptha.Children.Clear();
    //        CanvasCaptha.Children.Add(AvtorizaciaViewModel.Can);
    //        ShowMessages.Text = "�������� �����. ���������� ��� ���.";
    //    }
    //}
}

