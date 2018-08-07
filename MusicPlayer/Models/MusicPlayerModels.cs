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
        public int Id { get; set; }
        [Display(Name = "Playlist Name")]
        [Required]
        public string Name { get; set; }
    }

    public class PlaylistTrack
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }

    public class Track
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }
        [NotMapped]
        public Album Album { get; set; }
        [Display(Name = "Album")]
        public byte AlbumId { get; set; }
        [NotMapped]
        public Artist Artist { get; set; }
        [Display(Name = "Artist")]
        public byte ArtistId { get; set; }
        [NotMapped]
        public AudioFile AudioFile { get; set; }
        [Display(Name = "Audio File")]
        public byte AudioFileId { get; set; }
    }

    public class Artist
    {
        public int Id { get; set; }
        [Display(Name = "Artist Name")]
        [Required]
        public string Name { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }
        [Display(Name = "Album Name")]
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public Artist Artist { get; set; }
        [Display(Name = "Artist")]
        [Required]
        public byte ArtistId { get; set; }
    }


    public class AudioFile
    {
        public int Id { get; set; }
        [Display(Name = "File Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "File Path")]
        [Required]
        public string FilePath { get; set; }
    }
}