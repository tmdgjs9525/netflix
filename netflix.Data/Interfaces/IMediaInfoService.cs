using netflix.Core.Models;
using System.Collections.ObjectModel;

namespace netflix.Data.Interfaces
{
    public interface IMediaInfoService
    {
        Task<ObservableCollection<MediaInfo>> GetMediaInfosAsync();
    }
}