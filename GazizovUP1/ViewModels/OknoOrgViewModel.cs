using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using Tmds.DBus.Protocol;
using System;
using System.Collections.Generic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;
using ReactiveUI;
using Avalonia.Interactivity;

namespace GazizovUP1.ViewModels
{
	public class OknoOrgViewModel : ViewModelBase
	{
        private string _firstName;
        private string _lastName;
        private string _profilePicture;
        private string _greetingMessage;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string ProfilePicture
        {
            get => _profilePicture;
            set { _profilePicture = value; OnPropertyChanged(); }
        }

        //private async void SetGreetingMessage()
        //{
        //    var hour = DateTime.Now.Hour;
        //    if (hour >= 9 && hour <= 11)
        //        await MessageBoxManager.GetMessageBoxStandard("Окно", "Доброе утро", ButtonEnum.Ok).ShowAsync();
        //    else if (hour >= 11 && hour <= 18)
        //        await MessageBoxManager.GetMessageBoxStandard("Окно", "Добрый день", ButtonEnum.Ok).ShowAsync();
        //    else
        //        await MessageBoxManager.GetMessageBoxStandard("Окно", "Добрый вечер", ButtonEnum.Ok).ShowAsync();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Bitmap _imageOrg;
        public OknoOrgViewModel()
        {
            ImageOrg = new Bitmap("C:\\Users\\damir\\Desktop\\GazizovUP1\\GazizovUP1\\Вариант 6\\Ресурсы\\Жюри_import\\foto8.jpg");
        }
        public Bitmap ImageOrg { get => _imageOrg; set => this.RaiseAndSetIfChanged(ref _imageOrg, value); }
        public void ToPage()
        {
            MainWindowViewModel.Instance.PageContent = new Show();
        }
        public void ToPageJury()
        {
            MainWindowViewModel.Instance.PageContent = new ShowJury();
        }
        public void ToPageModerator()
        {
            MainWindowViewModel.Instance.PageContent = new ShowModerator();
        }
        public void ToPageUser()
        {
            MainWindowViewModel.Instance.PageContent = new ShowUser();
        }
        public void ToPageRegr()
        {
            MainWindowViewModel.Instance.PageContent = new RegrJuryaxaml();
        }
        public void ToPageProfile()
        {
            MainWindowViewModel.Instance.PageContent = new Profile();
        }
    }
}