using System.Linq;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;


namespace pwaWebAPIFx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public ActionResult<string> Get()
        {
            //Connection string - as given by azure service
            string connectionString =
 @"mongodb://pwamongo:6DFKJioREGoAEFy1RjUyasTzZSxzcEUGeUc7A6NHwX3EY0JqmFrdnZFuQR4FsUrcRpRdDbc5BlynEe0FssB2pw==@pwamongo.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            //Database and Table name
            var db = mongoClient.GetDatabase("NewsEdge");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Users");

            //Excluding _id column 
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");

            //result to json string
            var result = collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Exclude("_id")).ToList();
            return result.ToJson();
        }

        // GET: api/Kiddy/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kiddy
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Kiddy/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
