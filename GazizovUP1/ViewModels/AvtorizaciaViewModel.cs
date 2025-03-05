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
                ChangeMessageAdd(5); // ������ �����������
            }
        }
        private async void ChangeMessageAdd(int role)
        {
            string message = role switch
            {
                1 => "�� ������������������ ��� �������������",
                2 => "�� ������������������ ��� ����",
                3 => "�� ������������������ ��� �������������",
                4 => "�� ������������������ ��� �����������",
                _ => "������, ��������� ����� ��� ������"
            };

            await MessageBoxManager.GetMessageBoxStandard("����", message, ButtonEnum.Ok).ShowAsync();
            MainWindowViewModel.myConnection.SaveChanges();
            MainWindowViewModel.Instance.PageContent = new Show();
        }

        //private async System.Threading.Tasks.Task ChangeMessageAdd()
        //{
        //    ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("����", "��������� ���������?", ButtonEnum.YesNo).ShowAsync();
        //    if (result == ButtonResult.Yes)
        //    {
        //        MainWindowViewModel.myConnection.SaveChanges();
        //        MainWindowViewModel.Instance.PageContent = new Show();
        //        await MessageBoxManager.GetMessageBoxStandard("����", "��������� ������� ���������", ButtonEnum.Ok).ShowAsync();
        //    }
        //    else if (result == ButtonResult.No)
        //    {
        //        MainWindowViewModel.Instance.PageContent = new Show();
        //    }
        //}
    }
}