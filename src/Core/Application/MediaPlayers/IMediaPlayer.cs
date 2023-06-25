using src.Core.Domain.Entity;

namespace src.Core.Application.MediaPlayers
{
  public interface IMediaPlayer
  {
    void Play(MediaFile mediaFile);
    void Pause();
    void Stop();
    void Seek(int position);

  }
}