using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Controllers
{
  public class AnimalController : Controller
  {
    [HttpGet("/homepage")]
    public ActionResult Index()
    {

      return View();
    }

    [HttpGet("/form")]
    public ActionResult CreateForm()
    {

      return View();
    }

    [HttpGet("/list")]
    public ActionResult AnimalList()
    {

      return View(Dog.GetAll());
    }

    [HttpPost("/new")]
    public ActionResult SaveDog()
    {
      Dog newDog = new Dog(Request.Form["name"], Request.Form["gender"],Request.Form["checkin"],Request.Form["breed"]);
          newDog.SaveDog();
          return RedirectToAction("AnimalList");
        }
    }



  }
