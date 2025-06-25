using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.Profile;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.Services.HttpRequestsGet.HttpRequestGetProfile;
using Passes.Services.HttpRequestsPost;
using System.Threading.Tasks;



namespace Passes.ViewModels
{
    [QueryProperty(nameof(IsNeedUpdate), "need_update")]
    public partial class ProfileViewModel : ObservableObject
    {
        private bool _isNeedUpdate = false;
        private IHttpGetRequest<ProfileResponseModel> _profileService;
        private string _baseUrl;
        private Dictionary<string, string?> _requiredFields;
        private SendProfileService _sendProfileService;

        [ObservableProperty]
        private bool mainContentOpacity = false;

        [ObservableProperty]
        private ProfileModel profileData;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string? password;

        [ObservableProperty]
        private string? confirmPassword;

        public bool IsNeedUpdate
        {
            get => _isNeedUpdate;
            set
            {
                _isNeedUpdate = value;
                Init(_isNeedUpdate);
            }
        }

        public ProfileViewModel()
        {
            _baseUrl = (new BaseUrlService()).GetBaseUrl();
            _profileService = new ProfileService<ProfileResponseModel>("Mobile\\GetProfileInfo",_baseUrl);
            _sendProfileService = new SendProfileService();
        }

        private async Task Init(bool needToUpdate)
        {   if (needToUpdate)
                await GetProfileData();
        }

        [RelayCommand]
        public async Task SendRequest()
        {
            if (!await this.Validate())
                return;
            if (await _sendProfileService.MakeRequest(ProfileData))
            {
                await GetProfileData();
                await Shell.Current.DisplayAlert("","Данные обновлены","ОК");
            }

        }

        private async Task GetProfileData()
        {
            IsLoading = true;
            var response = await _profileService.GetData() ?? new ProfileResponseModel();
            ProfileData = response?.Profile ?? new ProfileModel();
            IsLoading = false;
        }

        private async Task<bool> Validate()
        {
            _requiredFields = new Dictionary<string, string?>()
            {
                { "- Фамилия", ProfileData.LastName },
                { "- Имя", ProfileData.Name },
                { "- Отчество", ProfileData.SecondName },
                { "- Телефон", ProfileData.PersonalPhone },
                { "- Должность", ProfileData.WorkPosition },
                { "- Кабинет", ProfileData.WorkRoom }
            };
            var emptyFields = _requiredFields
                .Where(field => String.IsNullOrEmpty(field.Value))
                .Select(field => field.Key)
                .ToList();

            if (emptyFields.Any())
            {
                var message = "Не заполнены следующие обязательные поля:\n"
                    + string.Join("\n", emptyFields);
                await Shell.Current.DisplayAlert("Ошибка", message, "ОК");
                return false;
            }
            return true;
        }
    }
}
