using Passes.Services.Auth;


namespace Passes.Pages
{
    public partial class AuthPage : ContentPage
    {
       public AuthPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            AnimtedCreationPage();
            HandleAuthPageStart();
            base.OnAppearing();
        }

        private async void Auth(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
                bool authResult = await AuthHandler(email.Text,password.Text);
                if (authResult)
                {
                    await SecureStorage.SetAsync("login", email.Text);
                    await SecureStorage.SetAsync("password", password.Text);
                    await Shell.Current.GoToAsync("//PassesList?need_update=true", true);
                    password.Text = "";
                    email.Text = "";
                    auth_error.IsVisible = false;
                }
                else
                {
                    password.Text = "";
                    email.Text = "";
                    auth_error.IsVisible = true;
                }
            }
        }

        private async Task<bool> AuthHandler(string login, string password)
        {
            try
            {
                loader.IsRunning = true;
                IAuthService auth = new BitrixAuthService(login, password);
                bool authResult = await auth.Auth();
                loader.IsRunning = false;
                return authResult;
            }
            catch (Exception ex) {
                await DisplayAlert("Ошибка", "Ошибка при загрузке данных", "OK");
                await Shell.Current.GoToAsync("//AuthPage",true);
                return false;
            }
        }

        private void PasswordShowClicked(object sender, EventArgs e)
        {
            var eyeImagePasswordButton = (ImageButton)sender;
            password.IsPassword = !password.IsPassword;
            eyeImagePasswordButton.Source = password.IsPassword ? "eye" : "eye_off";
        }

        private async void AnimtedCreationPage()
        {
            this.Opacity = 0;
            this.TranslationX = this.Width;

            await Task.WhenAll(
                 this.FadeTo(1, 1000),
                 this.TranslateTo(0, 0, 1000, Easing.CubicOut)
                );
        }

        private async void HandleAuthPageStart()
        {
            string? login = await SecureStorage.GetAsync("login");
            string? password = await SecureStorage.GetAsync("password");
            if (login is not null && password is not null)
            {
                bool authResult = await AuthHandler(login, password);
                if (authResult)
                    await Shell.Current.GoToAsync("//PassesList?need_update=true",true);
                else
                {
                    SecureStorage.Remove("login");
                    SecureStorage.Remove("password");
                    await Shell.Current.GoToAsync("//AuthPage", true);
                }
            }
        }
    }

}
