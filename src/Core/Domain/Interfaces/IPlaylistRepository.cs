using src.Core.Domain.Entities;

namespace src.Core.Domain.Interfaces
{
  public interface IPlaylistRepository
  {
    void AddPlaylist(Playlist playlist);
    void RemovePlaylist(Playlist playlist);
    Playlist FindPlaylistById(string playlistId);
  }
}