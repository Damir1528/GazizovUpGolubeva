using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GazizovUP1.Models;
using GazizovUP1.ViewModels;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System.Text;
using System;
using System.Threading.Tasks;
using DynamicData.Kernel;
using Tmds.DBus.Protocol;

namespace GazizovUP1;

public partial class Avtorizacia : UserControl
{
    private AvtorizaciaViewModel _captchaViewModel;
    public Avtorizacia()
    {
        InitializeComponent();
        GenerateCaptcha();
    }
    private string captcha;
    private void GenerateCaptcha()
    {
        captcha = GenerateRandomString(6); // ���������� ������ ������ 6 ��������
        captchaText.Text = captcha; // ���������� ����� �� ������
    }

    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder result = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }
        return result.ToString();
    }
    public async void autorization(object sender, RoutedEventArgs e)
    {
        AvtorizaciaViewModel page1 = new AvtorizaciaViewModel();
        page1.prover = false;
        string login2 = login.Text;
        string password2 = password.Text;
        page1.autorization = true;
        if (((login2 == "1" && password2 == "organizator123") || (login2 == "2" && password2 == "jury123") || (login2 == "3" && password2 == "user123") || (login2 == "4" && password2 == "moderator123")) && captchaInput.Text == captcha)
        {
            ShowMessage.Text = "�� ������� ��������������! \n ��������� ��������� ������";
            //EnterButton1.IsEnabled = true;
            //EnterButton1.IsVisible = true;
            ChangeMessageAdd(login2);
        }
        else if (captchaInput.Text != captcha)
        {
            await MessageBoxManager.GetMessageBoxStandard("����", "�� ����� �������� �����", ButtonEnum.Ok).ShowAsync();
            EnterButton.IsEnabled = false; // ��������� ������ �����������
            await Task.Delay(10000); // ���� 10 ������
            EnterButton.IsEnabled = true; // ������������ ������
            GenerateCaptcha(); // ���������� ����� �����
            captchaInput.Clear(); // ������� ���� ����� �����
            return;
        }
        else
        { 
            ShowMessage.Text = "�������� ����� ��� ������";
            EnterButton.IsEnabled = false;
            EnterButton.IsVisible = false; 
            ChangeMessageAdd("5"); 
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
}

