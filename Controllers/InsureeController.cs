using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;


namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
            
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }

            return View(table);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {                      
            return View();
        }
        
    
         

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,CarYear,DateOfBirth,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Table table)
        {
            if (ModelState.IsValid)
            {
                decimal quote = 50.00m;
                
                TimeSpan lifeSpan =  DateTime.Now - table.DateOfBirth;
                var age = lifeSpan.TotalDays / 365.2422;

                //Age related quote calculations
                if (age <= 18)
                {
                    quote += 100;
                }
                else if (age > 18 && age <= 25)
                {
                    quote += 50;
                }
                else
                {
                    quote += 50;
                }

                //Car related quote calculations
                if (table.CarYear < 2000 || table.CarYear > 2015)
                {
                    quote += 25;
                }
               
                if (table.CarMake == "Porsche" && table.CarModel == "911 Carrera")
                {
                    quote += 50;
                }
                else if (table.CarMake == "Porsche")
                {
                    quote += 25;
                }
                
                //Driving history quote calculations
                if (table.SpeedingTickets > 0)
                {
                    quote += (10 * table.SpeedingTickets);
                }
                if (table.DUI)
                {
                    quote *= 1.25m;
                }
                //Coverage Type
                if (table.CoverageType)
                {
                    quote *= 1.5m;
                }
                table.Quote = quote;
                db.Tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            return View(table);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,CarYear,DateOfBirth,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table table = db.Tables.Find(id);
            db.Tables.Remove(table);
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
