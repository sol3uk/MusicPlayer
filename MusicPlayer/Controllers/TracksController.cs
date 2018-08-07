using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Controllers
{
    public class TracksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tracks
        public ActionResult Index()
        {
            var viewModel = new List<TrackViewModel>();
            var tempTracks = db.Tracks.ToList();
            foreach (var track in tempTracks)
            {
                viewModel.Add(new TrackViewModel
                {
                    Track = track,
                    Album = db.Albums.Find(track.AlbumId),
                    Artist = db.Artists.Find(track.ArtistId),
                    AudioFile = db.AudioFiles.Find(track.AudioFileId)
                });
            }
            return View(viewModel);
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            var artists = db.Artists.ToList();
            var albums = db.Albums.ToList();
            var audioFiles = db.AudioFiles.ToList();

            var viewModel = new TrackViewModel
            {
                Artists = artists,
                Albums = albums,
                AudioFiles = audioFiles
            };
            return View(viewModel);
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AlbumId,ArtistId,AudioFileId")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(track);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            var viewModel = new TrackViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                var artists = db.Artists.ToList();
                var albums = db.Albums.ToList();
                var audioFiles = db.AudioFiles.ToList();

                viewModel.Track = track;
                viewModel.Artists = artists;
                viewModel.Albums = albums;
                viewModel.AudioFiles = audioFiles;
            }
            return View(viewModel);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AlbumId,ArtistId,AudioFileId")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(track);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
