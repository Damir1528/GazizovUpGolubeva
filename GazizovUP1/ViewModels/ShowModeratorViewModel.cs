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
	public class ShowModeratorViewModel : ViewModelBase
	{
        //
        public List<Moderator> _moderatorList;
        public List<Moderator> ModeratorList { get => _moderatorList; set => this.RaiseAndSetIfChanged(ref _moderatorList, value); }
        public ShowModeratorViewModel()
        {
            if (myConnection == null)
            {
                Console.WriteLine("ERROR: Ошибка MyConnection = 0");
                _moderatorList = new List<Moderator>();
                return;
            }
            ModeratorList = myConnection.Moderators.
            Include(x => x.ModeratorNavigation).
            Include(x => x.ModeratorDirectionNavigation).ToList();
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
            ModeratorList = myConnection.Moderators
                                                     .Include(x => x.ModeratorNavigation).
                                                     Include(x => x.ModeratorDirectionNavigation).ToList();
            // поисковая строка
            if (!string.IsNullOrWhiteSpace(_searchMeropriyatiye))
            {
                ModeratorList = ModeratorList.Where(x => $"{x.ModeratorNavigation.UsersFio}".ToLower()
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