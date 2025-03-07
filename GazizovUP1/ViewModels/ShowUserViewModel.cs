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
using GazizovUP1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GazizovUP1.ViewModels
{
	public class ShowUserViewModel : ViewModelBase
	{
        //
        public List<User> _userList;

        public List<User> UserList { get => _userList; set => this.RaiseAndSetIfChanged(ref _userList, value); }
        public ShowUserViewModel()
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
        }
        //фильтрация
        private string _selectedMaterialsFilter = null;
        string _searchMeropriyatiye;
        public string SearchMeropriyatiye
        {
            get => _searchMeropriyatiye;
            set
            {
                _searchMeropriyatiye = value;
                AllFilters();
            }
        }

        void AllFilters()
        {
            UserList = myConnection.Users
                                                     .Include(x => x.Jury).
                                                     Include(x => x.Moderator).
                                                     Include(x => x.Users).
                                                     Include(x => x.UsersCountryNavigation).
                                                     Include(x => x.UsersGenderNavigation).ToList();
            // поисковая строка
            if (!string.IsNullOrWhiteSpace(_searchMeropriyatiye))
            {
                UserList = UserList.Where(x => $"{x.UsersFio}".ToLower()
                                                                 .Contains(_searchMeropriyatiye.ToLower()))
                                          .ToList();
            }
        }
        public void ToPage()
        {
            MainWindowViewModel.Instance.PageContent = new OkmoOrg();
        }
    }
}