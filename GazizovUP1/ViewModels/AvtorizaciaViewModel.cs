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
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Input;
using Avalonia.Media;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace GazizovUP1.ViewModels
{
	public class AvtorizaciaViewModel : ViewModelBase
	{
        bool _prover = false;
        public bool prover
        {
            get => _prover;
            set => this.RaiseAndSetIfChanged(ref _prover, value);
        }
        bool _autorization = true;
        public bool autorization
        {
            get => _autorization;
            set => this.RaiseAndSetIfChanged(ref _autorization, value);
        }
        public bool _enabled = true;
        public bool enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _enabled, value);
            }
        }
        public async void ToPageOknoOrg()
        {
            await Task.Delay(4000);
            MainWindowViewModel.Instance.PageContent = new OkmoOrg();
        }
    }
}