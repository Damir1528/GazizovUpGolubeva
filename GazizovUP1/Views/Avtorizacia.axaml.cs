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
            ShowMessage.Text = "Вы успешно авторизовались! \n Нажмите на кнопку Open и подождите 4 секунды";
            EnterButton1.IsEnabled = true;
            EnterButton1.IsVisible = true;
            ChangeMessageAdd(login2);
        }
        else
        {
            ShowMessage.Text = "Неверный логин или пароль";
            // Скрыть кнопку Enter
            EnterButton.IsEnabled = false;
            EnterButton.IsVisible = false; // Скрыть визуально

            //CanvasCaptha.Children.Clear();
            //CanvasCaptha.Children.Add(AvtorizaciaViewModel.Can);
            //captchaTextBox.IsEnabled = true;
            //captchaTextBox.IsVisible = true;
            //RefreshCaptcha.IsEnabled = true;
            //RefreshCaptcha.IsVisible = true;
            ChangeMessageAdd("5"); // Ошибка авторизации
        }
    }

    private async void ChangeMessageAdd(string role)
    {
        string message = role switch
        {
            "1" => "Вы зарегистрировались под организатором",
            "2" => "Вы зарегистрировались под жюри",
            "3"=> "Вы зарегистрировались под пользователем",
            "4"=> "Вы зарегистрировались под модератором",
            _ => "Ошибка, проверьте логин или пароль"
        };

        await MessageBoxManager.GetMessageBoxStandard("Окно", message, ButtonEnum.Ok).ShowAsync();
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
    //        // Капча введена верно
    //        // Можно выполнить дальнейшие действия
    //        ShowMessages.Text = "Капча введена верно!";
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
    //        // Капча введена неверно
    //        // Обновляем капчу и даем еще одну попытку
    //        AvtorizaciaViewModel.CreateCaptha();
    //        CanvasCaptha.Children.Clear();
    //        CanvasCaptha.Children.Add(AvtorizaciaViewModel.Can);
    //        ShowMessages.Text = "Неверная капча. Попробуйте еще раз.";
    //    }
    //}
}

