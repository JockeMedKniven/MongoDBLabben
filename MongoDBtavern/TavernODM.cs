namespace MongoDBtavern
{
    internal class TavernODM
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement ("name")]
        public string Name { get; set; }

        [BsonElement ("quantity")]
        public int Quantity { get; set; }

        [BsonElement ("description")]
        public string? Description { get; set; }
    }
}
