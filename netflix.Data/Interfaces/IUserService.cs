using netflix.Core.Models;
using OpenSilver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Data.Interfaces
{
    public interface IUserService
    {
        Task<ObservableCollection<Profile>> GetUserProfilesAsync();
    }
}
