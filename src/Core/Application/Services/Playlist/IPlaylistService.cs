namespace src.Core.Application.Services.MediaPlayer
{
  public interface IPlaylistService
  {
    void CreatePlaylist(string playlistName);
    void DeletePlaylist(string id);
    void AddToPlaylist(string id, string mediaId);
    void RemoveFromPlaylist(string id, string mediaId);
  }
}