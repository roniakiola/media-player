using src.Core.Domain.Entities;
using src.Core.Domain.Interfaces;

namespace src.Core.Application.Services.PlaylistService
{
  public class PlaylistService : IPlaylistService
  {
    private readonly IPlaylistRepository playlistRepository;
    private readonly IMediaFileRepository mediaFileRepository;

    public PlaylistService(IPlaylistRepository playlistRepository, IMediaFileRepository mediaFileRepository)
    {
      this.playlistRepository = playlistRepository;
      this.mediaFileRepository = mediaFileRepository;
    }

    public void CreatePlaylist(string playlistName)
    {
      Playlist playlist = new Playlist(playlistName);
      playlistRepository.AddPlaylist(playlist);
    }

    public void RemovePlaylist(string playlistId)
    {
      Playlist playlist = playlistRepository.FindPlaylistById(playlistId);
      playlistRepository.RemovePlaylist(playlist);
    }

    public void AddToPlaylist(string playlistId, string mediaId)
    {
      Playlist playlist = playlistRepository.FindPlaylistById(playlistId);
      MediaFile mediaFile = mediaFileRepository.FindMediaFileById(mediaId);
      if (playlist != null && mediaFile != null)
      {
        playlist.AddMediaFile(mediaFile);
      }
    }

    public void RemoveFromPlaylist(string playlistId, string mediaId)
    {
      Playlist playlist = playlistRepository.FindPlaylistById(playlistId);
      MediaFile mediaFile = mediaFileRepository.FindMediaFileById(mediaId);
      if (playlist != null && mediaFile != null)
      {
        playlist.RemoveMediaFile(mediaFile);
      }
    }
  }
}