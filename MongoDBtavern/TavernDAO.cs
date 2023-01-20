using MongoDB.Driver;
using System.Xml.Linq;

namespace MongoDBtavern
{
    internal class TavernDAO : ITavernDAO
    {
        IMongoCollection<TavernODM> collection;
        public TavernDAO(string db, string clientURI)
        {
            var client = new MongoClient(clientURI);
            var database = client.GetDatabase(db);
            this.collection = database.GetCollection<TavernODM>("storage");
        }
        public async void Create(TavernODM item)
        {
            await collection.InsertOneAsync(item);
        }

        public List<TavernODM> ReadAll()
        {
            return this.collection.Find(new BsonDocument()).ToList();
        }
        public bool CheckIfNameExists(string name)
        {
            var filter = Builders<TavernODM>.Filter.Eq("name", name);
            bool found = this.collection.Find(filter).Any();
            return found;
        }

        public string ReturnItem(string name)
        {
            string result = "";
            foreach (var item in ReadAll())
            {
                if (item.Name == name)
                {
                    result = item.Name + item.Quantity + item.Description;
                    break;
                }
            }
            return result;
        }

        public void Update(string inputName, string inputFilter, string inputUpdate)
        {
            foreach (var item in ReadAll())
            {
                if (item.Name.ToLower() == inputName.ToLower())
                {
                    if ("Name".ToLower() == inputFilter.ToLower() || "Quantity".ToLower() == inputFilter.ToLower() || "Description".ToLower() == inputFilter.ToLower())
                    {
                        var filter = Builders<TavernODM>.Filter.Eq("name", inputName);
                        var update = Builders<TavernODM>.Update.Set(inputFilter, inputUpdate);
                        this.collection.UpdateOne(filter, update);

                        Console.WriteLine($"\tYou fixed the stuff! Great work!");
                    }
                    else
                    {
                        Console.WriteLine("\tI'm afraid that object didn't had the value you where trying to change");
                    }
                }
            }
        }

        public void Delete(string inputName)
        {
            foreach (var item in ReadAll())
            {
                if (item.Name.ToLower() == inputName.ToLower())
                {
                    var filter = Builders<TavernODM>.Filter.Eq("name", inputName);
                    this.collection.DeleteOne(filter);
                }
            }
        }
    }
}