using Passes.Services.Auth;


namespace Passes.Pages
{
    public partial class AuthPage : ContentPage
    {

       public AuthPage()
        {
            InitializeComponent();
        }

        private async void Auth(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
                loader.IsRunning = true;
                IAuthService auth = new BitrixAuthService(email.Text, password.Text);
                bool authResult = await auth.Auth();
                loader.IsRunning = false;
                if (authResult)
                    await Shell.Current.GoToAsync("//PassesList");
                else
                {
                    password.Text = "";
                    email.Text = "";
                    auth_error.IsVisible = true;
                }
            }
        }

        private void PasswordShowClicked(object sender, EventArgs e)
        {
            var eyeImagePasswordButton = (ImageButton)sender;
            password.IsPassword = !password.IsPassword;
            eyeImagePasswordButton.Source = password.IsPassword ? "eye" : "eye_off";
        }
    }

}
