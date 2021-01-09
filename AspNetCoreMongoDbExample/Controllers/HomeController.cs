using AspNetCoreMongoDbExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMongoDbExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //var connect = new MongoClient("mongodb+srv://ouzdev:etj810c222@cluster0.zq4ai.mongodb.net/<dbname>?retryWrites=true&w=majority");
            //var database = connect.GetDatabase("sample_geospatial");
            //var collection = database.GetCollection<Shipwrecks>("shipwrecks");

            //List<Shipwrecks> model = await collection.Find(s => s.FeatureType.Length > 1).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteById(string id)
        {
            var connect = new MongoClient("mongodb+srv://ouzdev:etj810c222@cluster0.zq4ai.mongodb.net/<dbname>?retryWrites=true&w=majority");
            var database = connect.GetDatabase("sample_geospatial");
            var collection = database.GetCollection<BsonDocument>("shipwrecks");
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = collection.DeleteOne(deleteFilter);

            return RedirectToAction("Index");
        }

        public IActionResult AddRecord()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRecord(Shipwrecks model)
        {
            var connect = new MongoClient("mongodb+srv://ouzdev:etj810c222@cluster0.zq4ai.mongodb.net/<dbname>?retryWrites=true&w=majority");
            var database = connect.GetDatabase("sample_geospatial");
            var collection = database.GetCollection<BsonDocument>("shipwrecks");
            var bsonDocument = model.ToBsonDocument();

            collection.InsertOne(bsonDocument);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRecord(string id)
        {
            var connect = new MongoClient("mongodb+srv://ouzdev:etj810c222@cluster0.zq4ai.mongodb.net/<dbname>?retryWrites=true&w=majority");
            var database = connect.GetDatabase("sample_geospatial");
            var collection = database.GetCollection<Shipwrecks>("shipwrecks");
            Shipwrecks model = await collection.Find(s => s.Id == id).FirstOrDefaultAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRecord(Shipwrecks model)
        {

            var connect = new MongoClient("mongodb+srv://ouzdev:etj810c222@cluster0.zq4ai.mongodb.net/<dbname>?retryWrites=true&w=majority");
            var database = connect.GetDatabase("sample_geospatial");
            var collection = database.GetCollection<Shipwrecks>("shipwrecks");
            await collection.ReplaceOne(s => s.Id == model.Id, model);

            return RedirectToView("Index");
        }
    }
}