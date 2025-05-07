using netflix.Core.Models;
using System.Collections.ObjectModel;

namespace netflix.Data.Services
{
    public interface IMediaInfoService
    {
        Task<ObservableCollection<MediaInfo>> GetMediaInfosAsync();
    }
}