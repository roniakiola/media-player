using src.Core.Domain.Entities;

namespace src.Core.Domain.Interfaces
{
  public interface IPlaylistRepository
  {
    void CreatePlaylist(Playlist playlist);
    void DeletePlaylist(Playlist playlist);
    Playlist FindPlaylistById(string playlistId);
  }
}