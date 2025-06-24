using CommunityToolkit.Mvvm.ComponentModel;
using Passes.Models.Profile;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.Services.HttpRequestsGet.HttpRequestGetProfile;


namespace Passes.ViewModels
{
    [QueryProperty(nameof(IsNeedUpdate), "need_update")]
    public partial class ProfileViewModel : ObservableObject
    {
        private bool _isNeedUpdate = false;
        private IHttpGetRequest<ProfileResponseModel> _profileService;
        private string _baseUrl;

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
        }

        private async Task Init(bool needToUpdate)
        {   if (needToUpdate)
                await GetProfileData();
        }

        private async Task GetProfileData()
        {
            IsLoading = true;
            var response = await _profileService.GetData() ?? new ProfileResponseModel();
            ProfileData = response?.Profile ?? new ProfileModel();
            IsLoading = false;
        }
  
    }
}
