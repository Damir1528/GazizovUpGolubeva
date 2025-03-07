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
	public class ShowJuryViewModel : ViewModelBase
	{
        //
        public List<Jury> _juryList;
        public List<Jury> JuryList { get => _juryList; set => this.RaiseAndSetIfChanged(ref _juryList, value); }
        public ShowJuryViewModel()
        {
            if (myConnection == null)
            {
                Console.WriteLine("ERROR: Ошибка MyConnection = 0");
                _juryList = new List<Jury>();
                return;
            }
            JuryList = myConnection.Juries.
            Include(x => x.JuryDirectionNavigation).
            Include(x => x.JuryNavigation).ToList();
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
            JuryList = myConnection.Juries
                                                     .Include(x => x.JuryDirectionNavigation).
                                                     Include(x => x.JuryNavigation).ToList();
            // поисковая строка
            if (!string.IsNullOrWhiteSpace(_searchMeropriyatiye))
            {
                JuryList = JuryList.Where(x => $"{x.JuryNavigation.UsersFio}".ToLower()
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