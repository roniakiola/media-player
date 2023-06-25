namespace src.Core.Domain.Entities
{
  public class Playlist
  {
    public string Id { get; }
    public string Name { get; set; }
    public List<MediaFile> MediaFiles { get; set; }

    public Playlist(string name)
    {
      Id = Guid.NewGuid().ToString();
      Name = name;
      MediaFiles = new List<MediaFile>();
    }

    public void AddMediaFile(MediaFile mediaFile)
    {
      MediaFiles.Add(mediaFile);
    }

    public void RemoveMediaFile(MediaFile mediaFile)
    {
      MediaFiles.Remove(mediaFile);
    }
  }
}