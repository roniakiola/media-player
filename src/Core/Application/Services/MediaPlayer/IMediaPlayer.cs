using src.Core.Domain.Entities;

namespace src.Core.Application.Services.MediaPlayer
{
  public interface IMediaPlayer
  {
    void Play(MediaFile mediaFile);
    void Pause();
    void Stop();
    void Seek(int position);

  }
}