using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool mainContentOpacity = false;
    }
}
