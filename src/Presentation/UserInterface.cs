using src.Infrastructure.Repositories;
using src.Core.Application.Services.PlaylistService;
using src.Core.Application.Services.MediaPlayer;
using src.Core.Domain.Entities;

namespace src.Presentation
{
  public class UserInterface
  {
    private readonly PlaylistService playlistService;
    private readonly MediaPlayerFactory mediaPlayerFactory;
    private readonly MediaFileRepository mediaFileRepository;
    private readonly PlaylistRepository playlistRepository;

    public UserInterface()
    {
      mediaFileRepository = MediaFileRepository.Instance;
      playlistRepository = PlaylistRepository.Instance;
      playlistService = new PlaylistService(playlistRepository, mediaFileRepository);
      mediaPlayerFactory = new MediaPlayerFactory();
    }


    public void Run()
    {
      while (true)
      {
        Console.WriteLine("=== Media Player CLI ===");
        Console.WriteLine("1. Create Playlist");
        Console.WriteLine("2. Remove Playlist");
        Console.WriteLine("3. Add Media File to Playlist");
        Console.WriteLine("4. Remove Media File from Playlist");
        Console.WriteLine("5. Play Media File");
        Console.WriteLine("6. Pause Media File");
        Console.WriteLine("7. Stop Media File");
        Console.WriteLine("8. List All Media Files");
        Console.WriteLine("9. List All Playlists");
        Console.WriteLine("10. Add Media File");
        Console.WriteLine("11. Quit");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            CreatePlaylist();
            break;
          case "2":
            RemovePlaylist();
            break;
          case "3":
            AddMediaFileToPlaylist();
            break;
          case "4":
            RemoveMediaFileFromPlaylist();
            break;
          case "5":
            PlayMediaFile();
            break;
          case "6":
            PauseMediaFile();
            break;
          case "7":
            StopMediaFile();
            break;
          case "8":
            ListAllMediaFiles();
            break;
          case "9":
            ListAllPlaylists();
            break;
          case "10":
            AddMediaFile();
            break;
          case "11":
            Console.WriteLine("Goodbye!");
            return;
          default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
        }

        Console.WriteLine();
      }
    }

    private void CreatePlaylist()
    {
      Console.Write("Enter the playlist name: ");
      string playlistName = Console.ReadLine();

      playlistService.CreatePlaylist(playlistName);

      Console.WriteLine("Playlist created successfully.");
    }

    private void RemovePlaylist()
    {
      Console.Write("Enter the playlist ID: ");
      string playlistId = Console.ReadLine();

      playlistService.RemovePlaylist(playlistId);

      Console.WriteLine("Playlist removed successfully.");
    }

    private void AddMediaFileToPlaylist()
    {
      Console.Write("Enter the playlist ID: ");
      string playlistId = Console.ReadLine();

      Console.Write("Enter the media file ID: ");
      string mediaId = Console.ReadLine();

      playlistService.AddToPlaylist(playlistId, mediaId);

      Console.WriteLine("Media file added to playlist successfully.");
    }

    private void RemoveMediaFileFromPlaylist()
    {
      Console.Write("Enter the playlist ID: ");
      string playlistId = Console.ReadLine();

      Console.Write("Enter the media file ID: ");
      string mediaId = Console.ReadLine();

      playlistService.RemoveFromPlaylist(playlistId, mediaId);

      Console.WriteLine("Media file removed from playlist successfully.");
    }

    private void AddMediaFile()
    {
      Console.Write("Enter the media file title: ");
      string title = Console.ReadLine();

      Console.Write("Enter the media file duration: ");
      int duration = int.Parse(Console.ReadLine());

      Console.Write("Enter the media file type (audio/video): ");
      string fileType = Console.ReadLine();

      MediaFile mediaFile;
      if (fileType.ToLower() == "audio")
      {
        Console.Write("Enter the artist: ");
        string artist = Console.ReadLine();

        mediaFile = new AudioFile(title, duration, artist);
      }
      else if (fileType.ToLower() == "video")
      {
        Console.Write("Enter the video quality: ");
        string quality = Console.ReadLine();

        mediaFile = new VideoFile(title, duration, quality);
      }
      else
      {
        Console.WriteLine("Invalid media file type. Please try again.");
        return;
      }

      mediaFileRepository.AddMediaFile(mediaFile);

      Console.WriteLine("Media file added successfully.");
    }

    private void PlayMediaFile()
    {
      Console.Write("Enter the media file ID: ");
      string mediaId = Console.ReadLine();

      MediaFile mediaFile = mediaFileRepository.FindMediaFileById(mediaId);
      if (mediaFile != null)
      {
        IMediaPlayer mediaPlayer = mediaPlayerFactory.CreateMediaPlayer(mediaFile);
        mediaPlayer.Play(mediaFile);
        Console.WriteLine($"Now playing: {mediaFile.Title}");
      }
      else
      {
        Console.WriteLine("Media file not found.");
      }
    }

    private void PauseMediaFile()
    {
      // todo
    }

    private void StopMediaFile()
    {
      // todo
    }

    private void ListAllMediaFiles()
    {
      List<MediaFile> mediaFiles = mediaFileRepository.GetAllMediaFiles();

      Console.WriteLine("=== All Media Files ===");
      foreach (MediaFile mediaFile in mediaFiles)
      {
        Console.WriteLine($"ID: {mediaFile.Id}, Title: {mediaFile.Title}, Duration: {mediaFile.Duration}");
      }
    }

    private void ListAllPlaylists()
    {
      List<Playlist> playlists = playlistRepository.GetAllPlaylists();

      Console.WriteLine("=== All Playlists ===");
      foreach (Playlist playlist in playlists)
      {
        Console.WriteLine($"ID: {playlist.Id}, Name: {playlist.Name}");
      }
    }
  }
}

