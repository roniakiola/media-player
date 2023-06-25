using src.Core.Domain.Entities;
using src.Core.Application.Observers;
using System.Timers;

namespace src.Core.Application.Services.MediaPlayer
{
  public abstract class MediaPlayer : IMediaPlayer
  {
    private List<IMediaPlayerObserver> _observers;
    private System.Timers.Timer timer;
    private int currentPosition;

    public void Subscribe(IMediaPlayerObserver observer)
    {
      _observers.Add(observer);
    }

    public void Unsubscribe(IMediaPlayerObserver observer)
    {
      _observers.Remove(observer);
    }

    protected void NotifyPlay()
    {
      foreach (var observer in _observers)
      {
        observer.OnPlay();
      }
    }

    protected void NotifyPause()
    {
      foreach (var observer in _observers)
      {
        observer.OnPause();
      }
    }

    protected void NotifyStop()
    {
      foreach (var observer in _observers)
      {
        observer.OnStop();
      }
    }

    public void Play(MediaFile mediaFile)
    {
      Console.WriteLine($"Playing: {mediaFile.Title}");
      currentPosition = 0;
      StartTimer(mediaFile.Duration);
    }

    public void Pause()
    {
      Console.WriteLine("Track paused");
      timer.Stop();
    }

    public void Stop()
    {
      Console.WriteLine("Track stopped");
      StopTimer();
    }

    public void Seek(int position)
    {
      currentPosition = position;
      Console.WriteLine($"Skipped to: {position}");
    }

    protected void StartTimer(int duration)
    {
      timer = new System.Timers.Timer();
      timer.Interval = 1000;
      timer.Elapsed += (sender, e) => TimerElapsed(sender, e, duration);
      timer.Start();
    }

    protected void StopTimer()
    {
      timer?.Stop();
      timer?.Dispose();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e, int duration)
    {
      currentPosition++;
      if (currentPosition >= duration)
      {
        Stop();
        StopTimer();
      }
    }
  }

  public class AudioPlayer : MediaPlayer { }

  public class VideoPlayer : MediaPlayer { }
}