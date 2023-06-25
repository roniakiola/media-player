using src.Core.Domain.Entities;

namespace src.Core.Application.Services.MediaPlayer
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