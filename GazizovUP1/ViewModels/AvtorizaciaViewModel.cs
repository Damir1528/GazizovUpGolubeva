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
        
        //private int _login;
        //private string _parol;
        //private string _captchaInput;
        //private string _captchaText;
        //private Bitmap _captchaBitmap;

        //public int Login
        //{
        //    get => _login;
        //    set => this.RaiseAndSetIfChanged(ref _login, value);
        //}

        //public string Parol
        //{
        //    get => _parol;
        //    set => this.RaiseAndSetIfChanged(ref _parol, value);
        //}

        //public string CaptchaInput
        //{
        //    get => _captchaInput;
        //    set => this.RaiseAndSetIfChanged(ref _captchaInput, value);
        //}

        //public Bitmap CaptchaBitmap
        //{
        //    get => _captchaBitmap;
        //    private set => this.RaiseAndSetIfChanged(ref _captchaBitmap, value);
        //}

        //public ICommand AuthorizeCommand { get; }

        //public AvtorizaciaViewModel()
        //{
        //    GenerateCaptcha();
        //    AuthorizeCommand = ReactiveCommand.Create(Authorize);
        //}

        //private void Authorize()
        //{
        //    if (CaptchaInput != _captchaText)
        //    {
        //        ChangeMessageAdd(5); // ������ �����
        //        GenerateCaptcha(); // ��������� ����� �����
        //        return;
        //    }

        //    // ����� ������ ���� ���� ������ �����������
        //    if ((Login == 1 && Parol == "organizator123") || (Login == 2 && Parol == "jury123") || (Login == 3 && Parol == "user123") || (Login == 4 && Parol == "moderator123"))
        //    {
        //        ChangeMessageAdd(Login);
        //    }
        //    else
        //    {
        //        ChangeMessageAdd(5); // ������ �����������
        //    }
        //}

        //private async void ChangeMessageAdd(int role)
        //{
        //    string message = role switch
        //    {
        //        1 => "�� ������������������ ��� �������������",
        //        2 => "�� ������������������ ��� ����",
        //        3 => "�� ������������������ ��� �������������",
        //        4 => "�� ������������������ ��� �����������",
        //        _ => "������, ��������� ����� ��� ������"
        //    };

        //    await MessageBoxManager.GetMessageBoxStandard("����", message, ButtonEnum.Ok).ShowAsync();
        //    MainWindowViewModel.myConnection.SaveChanges();
        //    MainWindowViewModel.Instance.PageContent = new Show();
        //}

        //private void GenerateCaptcha(int length = 6)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    var random = new Random();
        //    var captcha = new StringBuilder();

        //    for (int i = 0; i < length; i++)
        //    {
        //        captcha.Append(chars[random.Next(chars.Length)]);
        //    }

        //    _captchaText = captcha.ToString(); // ��������� ����� �����

        //    // �������� ����������� �����
        //    using (Bitmap bitmap = new Bitmap(200, 50))
        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.Clear(Color.White);
        //        graphics.DrawString(_captchaText, new Font("Arial", 24), Brushes.Black, new PointF(10, 10));

        //        // ���������� ����
        //        for (int i = 0; i < 20; i++)
        //        {
        //            int x = random.Next(bitmap.Width);
        //            int y = random.Next(bitmap.Height);
        //            bitmap.SetPixel(x, y, Color.Gray);
        //        }

        //        CaptchaBitmap = new Bitmap(bitmap);
        //    }
        //}

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