namespace MongoDBtavern
{
    internal class TextIO : IUIIO
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }


    }
}
