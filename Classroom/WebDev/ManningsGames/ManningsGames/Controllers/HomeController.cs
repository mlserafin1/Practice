using ManningsGames.DAL;
using ManningsGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManningsGames.Controllers
{
    public class HomeController : Controller
    {
        IVideoGameRepository _repo;
        public HomeController(IVideoGameRepository repo)
        {
            _repo = repo;
        }
        public HomeController(): this(new VideoGameRepository())
        {

        }
        // GET: Home
        public ActionResult Index()
        {
            List<VideoGame> videoGames = _repo.GetAll().ToList();
            return View(videoGames);
        }

        [HttpGet]
        public ActionResult Create() { return View(); }
        [HttpPost]
        public ActionResult Create(VideoGame game)
        {
            if (!ModelState.IsValid) return View(game);
            try
            {
                _repo.Create(game);
                return RedirectToAction("Detail", new { id = game.Id});
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id) { return View(); }

        [HttpGet]
        public ActionResult Edit(int id) { return View(); }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            VideoGame game = _repo.GetById(id);
            return View(game);
        }

        [HttpGet]
        public ActionResult Delete(int id) { return View(); }
    }
}