using ApiClient;
using BitsoProyect.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitsoProyect.Controllers
{
    public class BitcoinController : Controller
    {
        ApiResponse apiResponse = new ApiResponse();

        // GET: Bitcoin
        public ActionResult Index(string SelectedOperation)
        {
            ViewBag.SelectedOperation= SelectedOperation??"Trades";
            return View();
        }


        [HttpGet]
        public JsonResult Trades()
        {
            try
            {
                apiResponse = APICLientFactory.CreateApiClient("trades/?book=btc_mxn&limit=10");

                return Json(apiResponse.Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {

                return Json(null, JsonRequestBehavior.AllowGet);
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
        }
        [HttpGet]
        public JsonResult OrderBook()
        {
            try
            {

                ViewBag.SelectedOperation = "OrderBook";
                apiResponse = APICLientFactory.CreateApiClient("order_book/?book=btc_mxn");

                return Json(apiResponse.Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Mercado()
        {
            try
            {
                apiResponse = APICLientFactory.CreateApiClient("ticker/?book=btc_mxn");
                Ticker ticker= JObject.Parse(apiResponse.Data).SelectToken("payload").ToObject<Ticker>();
                return View(ticker);
            }
            catch (Exception exception)
            {
                ExceptionHandler.Instance.WriteExceptionLog(exception);
                return View();
            }
        }
    }
}