using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPlayer.ViewModels
{
    public class TrackViewModel
    {
        public Track Track { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public Album Album { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public AudioFile AudioFile { get; set; }
        public IEnumerable<AudioFile> AudioFiles { get; set; }
    }

    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }

    public class PlaylistViewModel
    {
        public Playlist Playlist { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}