namespace MongoDBtavern
{
    internal interface ITavernDAO
    {
        void Create(TavernODM item);
        public List<TavernODM> ReadAll();
        public bool CheckIfNameExists(string name);
        public string ReturnItem(string name);
        void Update(string inputName, string inputFilter, string inputUpdate);
        void Delete(string inputName);
    }
}
