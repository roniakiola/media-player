namespace src.Core.Domain.Entity
{
  public abstract class MediaFile
  {
    public string Id { get; }
    public string Title { get; set; }
    public int Duration { get; set; }

    protected MediaFile(string title, int duration)
    {
      Id = Guid.NewGuid().ToString();
      Title = title;
      Duration = duration;
    }
  }

  public class AudioFile : MediaFile
  {
    public string Artist { get; set; }

    public AudioFile(string title, int duration, string artist) : base(title, duration)
    {
      Artist = artist;
    }
  }

  public class VideoFile : MediaFile
  {
    public string Quality { get; set; }

    public VideoFile(string title, int duration, string quality) : base(title, duration)
    {
      Quality = quality;
    }
  }
}