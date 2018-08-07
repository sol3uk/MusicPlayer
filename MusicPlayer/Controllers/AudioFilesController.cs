using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicPlayer.Models;

namespace MusicPlayer.Controllers
{
    public class AudioFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AudioFiles
        public ActionResult Index()
        {
            return View(db.AudioFiles.ToList());
        }

        // GET: AudioFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioFile audioFile = db.AudioFiles.Find(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // GET: AudioFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AudioFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FilePath")] AudioFile audioFile)
        {
            if (ModelState.IsValid)
            {
                db.AudioFiles.Add(audioFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audioFile);
        }

        // GET: AudioFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioFile audioFile = db.AudioFiles.Find(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // POST: AudioFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FilePath")] AudioFile audioFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audioFile);
        }

        // GET: AudioFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioFile audioFile = db.AudioFiles.Find(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // POST: AudioFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AudioFile audioFile = db.AudioFiles.Find(id);
            db.AudioFiles.Remove(audioFile);
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
