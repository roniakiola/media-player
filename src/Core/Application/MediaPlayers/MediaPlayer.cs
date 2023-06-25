using src.Core.Domain.Entity;

namespace src.Core.Application.MediaPlayers
{
  public abstract class MediaPlayer : IMediaPlayer
  {

    public void Play(MediaFile mediaFile)
    {
      Console.WriteLine($"Playing: {mediaFile.Title}");
    }

    public void Pause()
    {
      Console.WriteLine("Track paused");
    }

    public void Stop()
    {
      Console.WriteLine("Track stopped");
    }

    public void Seek(int position)
    {
      Console.WriteLine($"Skipped to: {position}");
    }
  }

  public class AudioPlayer : MediaPlayer { }

  public class VideoPlayer : MediaPlayer { }
}