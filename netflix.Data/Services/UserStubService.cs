using netflix.Core.Models;
using netflix.Data.Interfaces;
using System.Collections.ObjectModel;

namespace netflix.Data.Services
{
    public class UserStubService : IUserService
    {
        public async Task<ObservableCollection<Profile>> GetUserProfilesAsync()
        {
            await Task.Delay(10); // 비동기 호출처럼 만들기 위한 더미 딜레이

            return new ObservableCollection<Profile>
            {
                new Profile("Profile 1", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 2", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 3", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 4", "/netflix;component/Assets/Images/profile1.png"),
            };
        }
    }
}
