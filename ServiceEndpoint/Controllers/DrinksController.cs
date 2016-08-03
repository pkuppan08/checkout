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
using ServiceEndpoint.Models;

namespace ServiceEndpoint.Controllers
{
    public class DrinksController : ApiController
    {
        private ServiceEndpointContext db = new ServiceEndpointContext();

        // GET: v2/Drinks
        public List<Drink> GetDrinks()
        {
            return db.Drinks.ToList();
        }

        // GET: v2/Drinks?drinkName={drinkName}
        [ResponseType(typeof(Drink))]
        public IHttpActionResult GetDrink(string drinkName)
        {
            Drink drink = db.Drinks.FirstOrDefault(x => string.Compare(x.DrinkName, drinkName, true) == 0 && x.IsDeleted == false);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        // PUT: v2/Drinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrink(int id, Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drink.DrinkId)
            {
                return BadRequest();
            }

            if (db.Drinks.Find(id).IsDeleted == true)
            {
                return BadRequest();
            }


            db.Entry(drink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: v2/Drinks
        [ResponseType(typeof(Drink))]
        public IHttpActionResult PostDrink(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int DrinkCount = db.Drinks.Where(x => string.Compare(x.DrinkName, drink.DrinkName, true) == 0 && x.IsDeleted == false).Count();
            if (DrinkCount == 0)
            {
                db.Drinks.Add(drink);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Drink already exists");
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = drink.DrinkId }, drink);
        }

        // DELETE: v2/Drinks/5
        [ResponseType(typeof(Drink))]
        public IHttpActionResult DeleteDrink(int id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }

            drink.IsDeleted = true;
            db.Entry(drink).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(drink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinkExists(int id)
        {
            return db.Drinks.Count(e => e.DrinkId == id) > 0;
        }
    }
}