using src.Core.Domain.Entities;

namespace src.Core.Domain.Interfaces
{
  public interface IMediaFileRepository
  {
    void AddMediaFile(MediaFile mediaFile);
    void RemoveMediaFile(MediaFile mediaFile);
    MediaFile findMediaFileById(string mediaId);
  }
}