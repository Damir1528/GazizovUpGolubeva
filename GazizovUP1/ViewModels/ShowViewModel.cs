using System;
using System.Collections.Generic;
using GazizovUP1.Models;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System.Linq;
using ReactiveUI;
using Microsoft.EntityFrameworkCore;
using Avalonia.Media.Imaging;

namespace GazizovUP1.ViewModels
{
	public class ShowViewModel : ViewModelBase
	{
        // для подсчета записей
        private int _sortMeropriyatiye;
        public int SortMeropriyatiye
        {
            get => _sortMeropriyatiye;
            set => this.RaiseAndSetIfChanged(ref _sortMeropriyatiye, value);
        }
        private int _totalMeropriyatiye;
        public int TotalMeropriyatiye
        {
            get => _totalMeropriyatiye;
            set => this.RaiseAndSetIfChanged(ref _totalMeropriyatiye, value);
        }
        //
        public List<Meropriyatiye> _meropriyatiyeList;
        public List<Meropriyatiye> MeropriyatiyeList { get => _meropriyatiyeList; set => this.RaiseAndSetIfChanged(ref _meropriyatiyeList, value); }
        public ShowViewModel()
        {
            if (myConnection == null)
            {
                Console.WriteLine("ERROR: Ошибка MyConnection = 0");
                _meropriyatiyeList = new List<Meropriyatiye>();
                return;
            }
            MeropriyatiyeList = myConnection.Meropriyatiyes.
            Include(x => x.MeropriyatiyeEventNavigation).ToList();

            TotalMeropriyatiye = MeropriyatiyeList.Count;
            SortMeropriyatiye = MeropriyatiyeList.Count;
            TotalMeropriyatiye = myConnection.Meropriyatiyes.Count();
        }



        public void ToPage()
        {
            MainWindowViewModel.Instance.PageContent = new OkmoOrg();
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
            MeropriyatiyeList = myConnection.Meropriyatiyes
                                                     .Include(x => x.MeropriyatiyeEventNavigation)
                                                     .ToList();
            // поисковая строка
            if (!string.IsNullOrWhiteSpace(_searchMeropriyatiye))
            {
                MeropriyatiyeList = MeropriyatiyeList.Where(x => $"{x.MeropriyatiyeName}".ToLower()
                                                                 .Contains(_searchMeropriyatiye.ToLower()))
                                          .ToList();
            }
            // радио баттоны
            if (_all)
            {

            }
            else
            {
                if (_kg)
                {
                    MeropriyatiyeList = MeropriyatiyeList.Where(x => x.MeropriyatiyeDate.Year == 2022).ToList();
                }
                if (_metr)
                {
                    MeropriyatiyeList = MeropriyatiyeList.Where(x => x.MeropriyatiyeDate.Year == 2023).ToList();
                }
                if (_litr)
                {
                    MeropriyatiyeList = MeropriyatiyeList.Where(x => x.MeropriyatiyeDate.Year == 2024).ToList();
                }
            }
            
            switch (_selectedSort)
            {
                case 0:  
                    IsVisibleSort = false;
                    break;

                case 1: 
                    IsVisibleSort = true;
                    if (_sortDown)
                    {
                        MeropriyatiyeList = MeropriyatiyeList.OrderByDescending(x => x.MeropriyatiyeName).ThenByDescending(x => x.MeropriyatiyeName).ToList();
                    }
                    else
                    {
                        MeropriyatiyeList = MeropriyatiyeList.OrderBy(x => x.MeropriyatiyeName).ThenBy(x => x.MeropriyatiyeName).ToList();
                    }
                    break;

            }
            // галочка с ролью
            if (_photo)
            {
                //MaterialList = MaterialList.Where(x => x.Image.HasValue && x.Image.Value > 0).ToList();
            }
            if (_unphoto)
            {
                //MaterialList = MaterialList.Where(x => !x.Image.HasValue).ToList();
            }
            // подсчет записй
            SortMeropriyatiye = MeropriyatiyeList.Count;
        }
        // радио баттоны
        bool _all = true;
        public bool All { get => _all; set { this.RaiseAndSetIfChanged(ref _all, value); AllFilters(); } }
        bool _kg = false;
        public bool Kg { get => _kg; set { this.RaiseAndSetIfChanged(ref _kg, value); AllFilters(); } }
        bool _metr = false;
        public bool Metr { get => _metr; set { this.RaiseAndSetIfChanged(ref _metr, value); AllFilters(); } }
        bool _litr = false;
        public bool Litr { get => _litr; set { this.RaiseAndSetIfChanged(ref _litr, value); AllFilters(); } }

        // 
        int _selectedSort = 0;
        public int SelectedSort { get => _selectedSort; set { _selectedSort = value; AllFilters(); } }

        bool _isVisibleSort = false;
        public bool IsVisibleSort { get => _isVisibleSort; set => this.RaiseAndSetIfChanged(ref _isVisibleSort, value); }

        bool _sortUp = true;
        public bool SortUp { get => _sortUp; set { this.RaiseAndSetIfChanged(ref _sortUp, value); AllFilters(); } }

        bool _sortDown = false;
        public bool SortDown { get => _sortDown; set { this.RaiseAndSetIfChanged(ref _sortDown, value); AllFilters(); } }

        // с
        bool _photo = false;
        public bool Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                AllFilters();
            }
        }
        // без
        bool _unphoto = false;
        public bool UnPhoto
        {
            get => _unphoto;
            set
            {
                _unphoto = value;
                AllFilters();
            }
        }
    }
}