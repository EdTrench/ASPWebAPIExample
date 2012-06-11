using System;
using System.Linq;
using System.Web.Mvc;
using MVCWebApiClient.Models;

namespace MVCWebApiClient.Controllers
{
 public class ProductsController : Controller
 {
  //
  // GET: /Products/
  ProductsRepository _productRepository;

  public ProductsController(ProductsRepository productRepository)
  {
   _productRepository = productRepository;
  }

  public ActionResult Index()
  {
   return View(_productRepository.Get());
  }

  //
  // GET: /Products/Details/5

  public ActionResult Details(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // GET: /Products/Create

  public ActionResult Create()
  {
   return View(_productRepository.New());
  }

  //
  // POST: /Products/Create

  [HttpPost]
  public ActionResult Create(Product model)
  {
   _productRepository.Create(model);
                
   return RedirectToAction("Index");
  }

  //
  // GET: /Products/Edit/5

  public ActionResult Edit(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // POST: /Products/Edit/5

  [HttpPost]
  [ValidationFilter]
  public ActionResult Edit(Product model)
  {
   try
   {
    _productRepository.Update(model);

    return RedirectToAction("Index");
   }
   catch
   {
    return View();
   }
  }

  //
  // GET: /Products/Delete/5

  public ActionResult Delete(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // POST: /Products/Delete/5

  [HttpPost]
  public ActionResult Delete(int id, FormCollection collection)
  {
   try
   {
    _productRepository.Delete(id);
    return RedirectToAction("Index");
   }
   catch
   {
    return View();
   }
  }
 }
}