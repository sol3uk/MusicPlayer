using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicPlayer.Models
{
    public class Playlist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Playlist Name")]
        [Required]
        public string Name { get; set; }
    }

    public class PlaylistTrack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }

    public class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }
        [NotMapped]
        public Album Album { get; set; }
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        [NotMapped]
        public Artist Artist { get; set; }
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }
        [NotMapped]
        public AudioFile AudioFile { get; set; }
        [Display(Name = "Audio File")]
        public int AudioFileId { get; set; }
    }

    public class Artist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Artist Name")]
        [Required]
        public string Name { get; set; }
    }

    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Album Name")]
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public Artist Artist { get; set; }
        [Display(Name = "Artist")]
        [Required]
        public int ArtistId { get; set; }
    }


    public class AudioFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "File Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "File Path")]
        [Required]
        public string FilePath { get; set; }
    }
}