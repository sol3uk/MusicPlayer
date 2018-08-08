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
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var viewModel = new List<AlbumViewModel>();
            var tempAlbums = db.Albums.ToList();
            foreach (var album in tempAlbums)
            {
                viewModel.Add(new AlbumViewModel
                {
                    Album = album,
                    Artist = db.Artists.Find(album.ArtistId)
                });
            }
            return View(viewModel);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? Id)
        {
            var viewModel = new AlbumViewModel();
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(Id);
            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                viewModel.Album = album;
            }
            if (Id != null)
            {
                
                viewModel.Tracks = db.Tracks.Where(x => x.AlbumId == Id);
            }
            return View(viewModel);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            var artists = db.Artists.ToList();
            var viewModel = new AlbumViewModel
            {
                Artists = artists
            };
            return View(viewModel);
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            var viewModel = new AlbumViewModel
            {
                Album = album
            };
            if (viewModel.Album == null)
            {
                return HttpNotFound();
            }
            else
            {
                var artists = db.Artists.ToList();
                viewModel.Album = album;
                viewModel.Artist = db.Artists.Find(album.ArtistId);
                viewModel.Artists = artists;
            }

            return View(viewModel);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
