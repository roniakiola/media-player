namespace src.Core.Application.Observers
{
  public interface IMediaPlayerObserver
  {
    void OnPlay();
    void OnPause();
    void OnStop();
  }
}