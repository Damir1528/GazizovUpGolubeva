using System;
using System.Collections.Generic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;
using ReactiveUI;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;

namespace GazizovUP1.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public List<User> _userList;
        private Random _random = new Random();
        private User _selectedUser;
        public List<User> Users { get; set; }
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public List<User> UserList { get => _userList; set => this.RaiseAndSetIfChanged(ref _userList, value); }
        public ProfileViewModel()
        {
            if (myConnection == null)
            {
                Console.WriteLine("ERROR: Ошибка MyConnection = 0");
                _userList = new List<User>();
                return;
            }
            UserList = myConnection.Users.Include(x => x.Jury).
                                                     Include(x => x.Moderator).
                                                     Include(x => x.Users).
                                                     Include(x => x.UsersCountryNavigation).
                                                     Include(x => x.UsersGenderNavigation).ToList();
            Image = new Bitmap("C:\\Users\\damir\\Desktop\\GazizovUP1\\GazizovUP1\\Вариант 6\\Ресурсы\\Жюри_import\\foto8.jpg");
            SelectRandomUser();

        }

        private Bitmap _image;
            public Bitmap Image { get => _image; set => this.RaiseAndSetIfChanged(ref _image, value); }
        public void ToPage()
        {
            MainWindowViewModel.Instance.PageContent = new OkmoOrg();
        }
        public void SelectRandomUser()
        {
            if (Users.Count > 0)
            {
                SelectedUser = Users[_random.Next(Users.Count)];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}