using System;
using System.Collections.Generic;
using Avalonia.Interactivity;
using GazizovUP1.Models;
using ReactiveUI;

namespace GazizovUP1.ViewModels
{
	public class InfoViewModel : ReactiveObject
	{
        public List<Jury> _juryList;
        public List<Jury> JuryList { get => _juryList; set => this.RaiseAndSetIfChanged(ref _juryList, value); }

        public List<User> _userList;
        public List<User> UserList { get => _userList; set => this.RaiseAndSetIfChanged(ref _userList, value); }
    }
}