using src.Core.Domain.Interfaces;
using src.Core.Domain.Entities;

namespace src.Infrastructure.Repositories
{
  public class MediaFileRepository : IMediaFileRepository
  {
    private static MediaFileRepository? _instance;
    private readonly List<MediaFile> _mediaFiles;

    private MediaFileRepository()
    {
      _mediaFiles = new List<MediaFile>();
    }

    public static MediaFileRepository Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new MediaFileRepository();
        }
        return _instance;
      }
    }

    public void AddMediaFile(MediaFile mediaFile)
    {
      _mediaFiles.Add(mediaFile);
    }

    public void RemoveMediaFile(MediaFile mediaFile)
    {
      _mediaFiles.Remove(mediaFile);
    }

    public MediaFile FindMediaFileById(string mediaId)
    {
      MediaFile? mediaFile = _mediaFiles.Find(m => m.Id == mediaId);
      if (mediaFile != null)
      {
        return mediaFile;
      }
      else
      {
        Console.WriteLine("Mediafile not found");
        return null;
      }
    }
  }
}