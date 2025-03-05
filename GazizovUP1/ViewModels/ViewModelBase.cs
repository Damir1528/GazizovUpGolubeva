using CommunityToolkit.Mvvm.ComponentModel;
using GazizovUP1.Models;
using ReactiveUI;

namespace GazizovUP1.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public static PostgresContext myConnection = new PostgresContext();
    }
}
