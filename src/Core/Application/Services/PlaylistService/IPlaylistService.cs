namespace src.Core.Application.Services.PlaylistService
{
  public interface IPlaylistService
  {
    void CreatePlaylist(string playlistName);
    void RemovePlaylist(string id);
    void AddToPlaylist(string id, string mediaId);
    void RemoveFromPlaylist(string id, string mediaId);
  }
}