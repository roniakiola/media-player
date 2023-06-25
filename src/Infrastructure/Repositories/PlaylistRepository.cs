using src.Core.Domain.Interfaces;
using src.Core.Domain.Entities;

namespace src.Infrastructure.Repositories
{
  public class PlaylistRepository : IPlaylistRepository
  {
    private static PlaylistRepository _instance;
    private readonly List<Playlist> _playlists;

    private PlaylistRepository()
    {
      _playlists = new List<Playlist>();
    }

    public static PlaylistRepository Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PlaylistRepository();
        }
        return _instance;
      }
    }

    public void AddPlaylist(Playlist playlist)
    {
      _playlists.Add(playlist);
    }

    public void RemovePlaylist(Playlist playlist)
    {
      _playlists.Remove(playlist);
    }

    public Playlist FindPlaylistById(string playlistId)
    {
      Playlist? playlist = _playlists.Find(p => p.Id == playlistId);
      if (playlist != null)
      {
        return playlist;
      }
      else
      {
        Console.WriteLine("Playlist not found");
        return null;
      }
    }
  }
}