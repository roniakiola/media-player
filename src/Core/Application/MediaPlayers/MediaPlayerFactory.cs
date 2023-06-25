using src.Core.Domain.Entity;

namespace src.Core.Application.MediaPlayers
{
  public class MediaPlayerFactory
  {
    public IMediaPlayer CreateMediaPlayer(MediaFile mediaFile)
    {
      switch (mediaFile)
      {
        case AudioFile audioFile:
          return new AudioPlayer();

        case VideoFile videoFile:
          return new VideoPlayer();

        default:
          throw new NotSupportedException("Media file not supported");
      }
    }
  }
}