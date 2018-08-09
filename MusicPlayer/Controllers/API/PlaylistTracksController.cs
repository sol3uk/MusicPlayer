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
    public class PlaylistTracksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PlaylistTracks
        public IQueryable<PlaylistTrack> GetPlaylistTracks()
        {
            var playlistTracks = db.PlaylistTracks;
            var tracks = db.Tracks.ToList();
            foreach (var playlistTrack in playlistTracks)
            {
                playlistTrack.Track = tracks.Find(x => x.Id == playlistTrack.TrackId);
            }
            return playlistTracks;
        }

        // GET: api/PlaylistTracks/5
        [ResponseType(typeof(PlaylistTrack))]
        public IHttpActionResult GetPlaylistTrack(int id)
        {
            PlaylistTrack playlistTrack = db.PlaylistTracks.Find(id);
            if (playlistTrack == null)
            {
                return NotFound();
            }

            return Ok(playlistTrack);
        }

        // PUT: api/PlaylistTracks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlaylistTrack(int id, PlaylistTrack playlistTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playlistTrack.Id)
            {
                return BadRequest();
            }

            db.Entry(playlistTrack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistTrackExists(id))
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

        // POST: api/PlaylistTracks
        public IHttpActionResult PostPlaylistTrack(NewPlaylistTrack newPlaylistTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var playlistTrack = new PlaylistTrack();
            playlistTrack.PlaylistId = newPlaylistTrack.PlaylistId;
            playlistTrack.TrackId = newPlaylistTrack.TrackId;
            db.PlaylistTracks.Add(playlistTrack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playlistTrack.Id }, newPlaylistTrack);
        }

        // DELETE: api/PlaylistTracks/5
        [ResponseType(typeof(PlaylistTrack))]
        public IHttpActionResult DeletePlaylistTrack(int id)
        {
            PlaylistTrack playlistTrack = db.PlaylistTracks.Find(id);
            if (playlistTrack == null)
            {
                return NotFound();
            }

            db.PlaylistTracks.Remove(playlistTrack);
            db.SaveChanges();

            return Ok(playlistTrack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaylistTrackExists(int id)
        {
            return db.PlaylistTracks.Count(e => e.Id == id) > 0;
        }
    }

    public class NewPlaylistTrack
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }
}