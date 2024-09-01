using GameCatalog.DataAccess;
using GameCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GameCatalog.Controllers
{
    public class GameController : Controller
    {
        private GameRepository gameRepo;
        public GameController()
        {
            gameRepo = new GameRepository();
        }
        // GET: GameController
        public ActionResult Index()
        {
            return View(gameRepo.GetAll());
        }

        public ActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGame(Game obj)
        {

            gameRepo.Create(obj);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            gameRepo.DeleteGame(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var obj = gameRepo.GetById(id);
            
            return View(obj);
        }
        
        [HttpPost]
        public ActionResult Edit(Game obj)
        {
                
            gameRepo.UpdateGame(obj);
            return RedirectToAction("Index");
        }
        

    }
}
