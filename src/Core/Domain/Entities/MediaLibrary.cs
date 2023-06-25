namespace src.Core.Domain.Entities
{
  public class MediaLibrary
  {
    public string Id { get; }
    public List<MediaFile> MediaFiles { get; set; }
    public List<Playlist> Playlists { get; set; }

    public MediaLibrary()
    {
      Id = Guid.NewGuid().ToString();
      MediaFiles = new List<MediaFile>();
      Playlists = new List<Playlist>();
    }

    public void AddMediaFile(MediaFile mediaFile)
    {
      MediaFiles.Add(mediaFile);
    }

    public void RemoveMediaFile(MediaFile mediaFile)
    {
      MediaFiles.Remove(mediaFile);
    }

    public void CreatePlaylist(string name)
    {
      Playlist playlist = new Playlist(name);
      Playlists.Add(playlist);
    }

    public void DeletePlaylist(Playlist playlist)
    {
      Playlists.Remove(playlist);
    }
  }
}