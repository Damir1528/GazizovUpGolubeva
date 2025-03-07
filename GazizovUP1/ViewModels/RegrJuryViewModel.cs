using System;
using System;
using System.Collections.Generic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace GazizovUP1.ViewModels
{
    public class RegrJuryViewModel : ViewModelBase
    {
            private Bitmap _image;
            public RegrJuryViewModel()
            {
                Image = new Bitmap("C:\\Users\\damir\\Desktop\\GazizovUP1\\GazizovUP1\\Вариант 6\\Ресурсы\\Жюри_import\\foto8.jpg");
            }
            public Bitmap Image { get => _image; set => this.RaiseAndSetIfChanged(ref _image, value); }
        public void ToPage()
        {
            MainWindowViewModel.Instance.PageContent = new OkmoOrg();
        }
    }
}