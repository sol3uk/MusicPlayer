using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MusicPlayer.Models;

namespace MusicPlayer.Controllers.API
{
    public class TracksApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TracksApi
        public IQueryable<Track> GetTracks()
        {
            var apiTracks = db.Tracks;
            var tempAlbums = db.Albums.ToList();
            var tempArtists = db.Artists.ToList();
            var tempAudioFiles = db.AudioFiles.ToList();
            foreach (var track in apiTracks)
            {
                track.Album = tempAlbums.Find(x => x.Id == track.AlbumId);
                track.Album.Artist = tempArtists.Find(x => x.Id == track.Album.ArtistId);
                track.Artist = tempArtists.Find(x => x.Id == track.ArtistId);
                track.AudioFile = tempAudioFiles.Find(x => x.Id == track.AudioFileId);
            }
            return apiTracks;
        }

        // GET: api/TracksApi/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult GetTrack(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/TracksApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrack(int id, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.Id)
            {
                return BadRequest();
            }

            db.Entry(track).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TracksApi
        [ResponseType(typeof(Track))]
        public IHttpActionResult PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(track);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = track.Id }, track);
        }

        // DELETE: api/TracksApi/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult DeleteTrack(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            db.SaveChanges();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(int id)
        {
            return db.Tracks.Count(e => e.Id == id) > 0;
        }
    }
}