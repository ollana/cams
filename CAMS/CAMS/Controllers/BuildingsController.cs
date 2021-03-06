﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAMS.Models;

namespace CAMS.Controllers
{
    public class BuildingsController : BaseController
    {

        // GET: Buildings
        public ActionResult Index()
        {
            try
            {
                //only super user can view buildings
                if (IsSuperUser())
                {
                    using (var db = new CAMS_DatabaseEntities())
                    {
                        return View(db.Labs.Select(e => e.Building).Distinct().ToList());
                    }
                }
                return RedirectAcordingToLogin();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        

        // GET: Buildings/Edit/building name
        public ActionResult Edit(string building)
        {
            try
            {
                if (building == null || building == string.Empty)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //only super user can view buildings
                if (IsSuperUser())
                {
                    object buildingName = building;
                    return View(buildingName);
                }
                return RedirectAcordingToLogin();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string NewName, string OldName)
        {
            try
            {
                if (NewName == null || NewName == string.Empty || OldName == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (var db = new CAMS_DatabaseEntities())
                {
                    //only super user can edit buildings
                    if (IsSuperUser())
                    {
                        List<int> labsId = db.Labs.Where(e => e.Building.Equals(OldName)).Select(e => e.LabId).ToList();
                        foreach (var lbid in labsId)
                        {
                            UpdateLabBuilding(lbid, NewName);
                        }
                        object buildingName = NewName;
                        return RedirectToAction("Index");

                    }
                    return RedirectAcordingToLogin();
                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        private void UpdateLabBuilding(int lbid,string newName)
        {
            using (var db = new CAMS_DatabaseEntities())
            {
                Lab lab = db.Labs.Find(lbid);
                lab.Building = newName;
                db.SaveChanges();
            }
        }

        // GET: Buildings/Delete/name
        public ActionResult Delete(string building)
        {
            try
            {
                //only super user can delete buildings
                if (IsSuperUser())
                {
                    object buildingName = building;
                    return View(buildingName);
                }
                return RedirectAcordingToLogin();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // POST: Buildings/Delete/name
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string building)
        {
            try
            {
                using (var db = new CAMS_DatabaseEntities())
                {
                    //only super user can delete buildings
                    if (IsSuperUser())
                    {
                        List<int> labsId = db.Labs.Where(e => e.Building.Equals(building)).Select(e => e.LabId).ToList();
                        foreach (var lbid in labsId)
                        {
                            DeleteLab(lbid);
                        }
                        return RedirectToAction("Index");
                    }
                    return RedirectAcordingToLogin();
                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (var db = new CAMS_DatabaseEntities())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
