using src.Core.Domain.Entities;

namespace src.Core.Application.Services.MediaPlayer
{
  public class PlaylistService : IPlaylistService
  {
    private readonly MediaLibrary mediaLibrary;

    public PlaylistService(MediaLibrary mediaLibrary)
    {
      this.mediaLibrary = mediaLibrary;
    }

    public void CreatePlaylist(string playlistName)
    {
      mediaLibrary.CreatePlaylist(playlistName);
    }

    public void DeletePlaylist(string playlistId)
    {
      Playlist playlist = FindPlaylistById(playlistId);
      mediaLibrary.DeletePlaylist(playlist);
    }

    public void AddToPlaylist(string playlistId, string mediaId)
    {
      Playlist playlist = FindPlaylistById(playlistId);
      MediaFile mediaFile = FindMediaFileById(mediaId);
      if (playlist != null && mediaFile != null)
      {
        playlist.AddMediaFile(mediaFile);
      }
    }

    public void RemoveFromPlaylist(string playlistId, string mediaId)
    {
      Playlist playlist = FindPlaylistById(playlistId);
      MediaFile mediaFile = FindMediaFileById(mediaId);
      if (playlist != null && mediaFile != null)
      {
        playlist.RemoveMediaFile(mediaFile);
      }
    }

    public Playlist FindPlaylistById(string playlistId)
    {
      Playlist? playlist = mediaLibrary.Playlists.Find(p => p.Id == playlistId);
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

    public MediaFile FindMediaFileById(string mediaId)
    {
      MediaFile? mediaFile = mediaLibrary.MediaFiles.Find(m => m.Id == mediaId);
      if (mediaFile != null)
      {
        return mediaFile;
      }
      else
      {
        Console.WriteLine("Mediafile not found");
        return null;
      }
    }
  }
}