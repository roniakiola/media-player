namespace src.Core.Application.Observers
{
  public class PlaybackObserver : IMediaPlayerObserver
  {
    public void OnPlay()
    {
      Console.WriteLine("Track started");
    }

    public void OnPause()
    {
      Console.WriteLine("Track paused.");
    }

    public void OnStop()
    {
      Console.WriteLine("Track stopped.");
    }
  }
}