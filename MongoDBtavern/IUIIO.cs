namespace MongoDBtavern
{
    internal interface IUIIO
    {
        public void Print(string output);
        public string GetInput();
        public void Clear();
        public void Exit();
    }
}
