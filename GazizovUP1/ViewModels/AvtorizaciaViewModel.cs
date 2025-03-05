using System;
using System.Collections.Generic;
using System.Linq;
using GazizovUP1.Models;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using System.Reactive;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Avalonia.Threading;
using Avalonia.Input;

namespace GazizovUP1.ViewModels
{
	public class AvtorizaciaViewModel : ViewModelBase
	{
        private int _login;
        private string _parol;
        public int Login
        {
            get => _login;
            set => this.RaiseAndSetIfChanged(ref _login, value);
        }
        public string Parol
        {
            get => _parol;
            set => this.RaiseAndSetIfChanged(ref _parol, value);
        }
        public ReactiveCommand<Unit, Unit> AuthorizeCommand { get; }

        public AvtorizaciaViewModel()
        {
            AuthorizeCommand = ReactiveCommand.Create(Authorize);
        }
        private async void Authorize()
        {
            Logined log = MainWindowViewModel.myConnection.Logineds.FirstOrDefault(x => x.LoginedId == Login);
            if (log != null && log.LoginedPassword == Parol)
            {
                int role = log.LoginedRole;
                ChangeMessageAdd(role);
            }
            else
            {
                ChangeMessageAdd(5); // Ошибка авторизации
            }
        }
        private async void ChangeMessageAdd(int role)
        {
            string message = role switch
            {
                1 => "Вы зарегистрировались под организатором",
                2 => "Вы зарегистрировались под жюри",
                3 => "Вы зарегистрировались под пользователем",
                4 => "Вы зарегистрировались под модератором",
                _ => "Ошибка, проверьте логин или пароль"
            };

            await MessageBoxManager.GetMessageBoxStandard("Окно", message, ButtonEnum.Ok).ShowAsync();
            MainWindowViewModel.myConnection.SaveChanges();
            MainWindowViewModel.Instance.PageContent = new Show();
        }

        //private async System.Threading.Tasks.Task ChangeMessageAdd()
        //{
        //    ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Окно", "Сохранить изменения?", ButtonEnum.YesNo).ShowAsync();
        //    if (result == ButtonResult.Yes)
        //    {
        //        MainWindowViewModel.myConnection.SaveChanges();
        //        MainWindowViewModel.Instance.PageContent = new Show();
        //        await MessageBoxManager.GetMessageBoxStandard("Окно", "Изменения успешно сохранены", ButtonEnum.Ok).ShowAsync();
        //    }
        //    else if (result == ButtonResult.No)
        //    {
        //        MainWindowViewModel.Instance.PageContent = new Show();
        //    }
        //}
    }
}