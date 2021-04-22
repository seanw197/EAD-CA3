using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAD_CA3.Models;

namespace EAD_CA3.Controllers
{
    public class FixturesController : Controller
    {

        private static List<Fixture> FixtureList = new List<Fixture>()
        {
            new Fixture() { MatchID = 1, datetime = new DateTime(2021, 2, 20), Venue = "Anfield", OpponentTeam = "Liverpool", GoalsFor = 2, GoalsAgainst = 1 },
            new Fixture() { MatchID = 2, datetime = new DateTime(2021, 3, 21), Venue = "Oriel Park", OpponentTeam = "Bacelona", GoalsFor = 3, GoalsAgainst = 1 },
            new Fixture() { MatchID = 3, datetime = new DateTime(2021, 4, 20), Venue = "Anfield", OpponentTeam = "Liverpool", GoalsFor = 2, GoalsAgainst = 1 },
            new Fixture() { MatchID = 4, datetime = new DateTime(2021, 5, 21), Venue = "Oriel Park", OpponentTeam = "Juventus", GoalsFor = 0, GoalsAgainst = 0 },
            new Fixture() { MatchID = 5, datetime = new DateTime(2021, 6, 20), Venue = "Tallaght", OpponentTeam = "Shamrock Rovers", GoalsFor = 0, GoalsAgainst = 0 },
            new Fixture() { MatchID = 6, datetime = new DateTime(2021, 7, 21), Venue = "Oriel Park", OpponentTeam = "Man Utd", GoalsFor = 0, GoalsAgainst = 0 }
        };

        //new List<Fixture>();


        // GET: Fixtures
        public ActionResult Index()
        {
            //int GoalDifference = GoalsFor - GoalsAgainst;

            int Points = 0;
            int Wins = 0;
            int Draws = 0;
            int Losses = 0;
            int Played = FixtureList.Where(p => p.datetime < DateTime.Now).Count();

            List<Fixture> playedMatches = FixtureList.Where(p => p.datetime < DateTime.Now).ToList();

            foreach (Fixture f in playedMatches)
            {
                if (f.GoalsFor > f.GoalsAgainst)
                {
                    Points += 3;
                    Wins += 1;
                }
                if (f.GoalsFor < f.GoalsAgainst)
                {                    
                    Losses += 1;
                }
                else if (f.GoalsFor == f.GoalsAgainst)
                {
                    Points += 1;
                    Draws += 1;
                }
            }

            ViewBag.message = "Total Played: " + Played + " Wins: " + Wins + " Draws: " + Draws + "Losses: " + Losses;
            return View(FixtureList);
           
        }

        // GET: Fixtures/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fixtures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fixture f)
        {
            try
            {
                FixtureList.Add(f);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fixtures/Edit/5
        public ActionResult Edit(int id)
        {
            Fixture f = FixtureList.FirstOrDefault(p => p.MatchID == id);
            return View(f);
        }

        // POST: Fixtures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Fixture f)
        {
            try
            {
                Fixture fi = FixtureList.FirstOrDefault(p => p.MatchID == id);

                if (fi != null)
                {
                    fi.GoalsFor = f.GoalsFor;
                    fi.GoalsAgainst = f.GoalsAgainst;
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fixtures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fixtures/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
