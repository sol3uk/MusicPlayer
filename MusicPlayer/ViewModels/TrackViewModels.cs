using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPlayer.ViewModels
{
    public class NewTrackViewModel
    {
        public Track Track { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<AudioFile> AudioFiles { get; set; }
    }

    public class NewAlbumViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
    }

    public class NewPlaylistViewModel
    {
        public Playlist Playlist { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}