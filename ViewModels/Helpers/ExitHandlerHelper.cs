using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.Helpers
{
   public class ExitHandlerHelper
    {
        public static async void GoToAuthPage()
        {
            SecureStorage.Remove("PHPSESSID");
            string? login = await SecureStorage.GetAsync("login");
            string? password = await SecureStorage.GetAsync("password");
            if (login is not null && password is not null)
            {
                SecureStorage.Remove("login");
                SecureStorage.Remove("password");
            }
            await Shell.Current.GoToAsync("//AuthPage");
        }
    }
}
