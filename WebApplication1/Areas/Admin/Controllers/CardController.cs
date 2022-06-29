using Business29.Services;
using DAL29.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        public async Task< IActionResult> Index()
        {
            List<Card> cards;
            try
            {
                cards = await _cardService.GetAll();
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                    status = 504,
                });
              
            }
            return View(cards);
        }
        public async Task<IActionResult> Details(int? id)
        {
            Card card = new Card();
            try
            {
                card = await _cardService.Get(id);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                    status = 504,
                });

            }
            return View(card);
        }
        [HttpGet]
        public  async Task<IActionResult> Update(int? id)
        {
            Card card;
            try
            {
               card= await _cardService.Get(id);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                    status = 504,
                });

            }
            return View(card);
        }
        

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Card card)
        {
           
            try
            {
                await _cardService.Update(card);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                    status = 504,
                });

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card)
        {

            try
            {
                await _cardService.Create(card);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                    status = 504,
                });

            }
            return RedirectToAction("Index");
        }
    }
}
