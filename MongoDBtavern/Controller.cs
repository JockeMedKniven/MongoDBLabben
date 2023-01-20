
namespace MongoDBtavern
{
    internal class Controller
    {
        IUIIO io;
        ITavernDAO dao;
        public Controller(IUIIO io, ITavernDAO dao)
        {
            this.io = io;
            this.dao = dao;
        }

        public void StartProgram()
        {
            string name;
            int quantity;
            string description;
            string filter;
            string update;
            while (true)
            {
                io.Print("\n\tYe Olde Tavern Store Room" +
                    "\n\t1. Store something" +
                    "\n\t2. Have a look at the existing stuff" +
                    "\n\t3. Change something" +
                    "\n\t4. Remove something" +
                    "\n\t5. Go back out to the tavern");
                io.Print("\n\tMake a choice:\t");
                Int32.TryParse(io.GetInput(), out int menuSelect);
                io.Clear();
                switch (menuSelect)
                {
                    case 1:
                        bool youSuck = true;
                        while (youSuck)
                        {
                            io.Print("\tWhat would the name of this thingy be? ");
                            name = io.GetInput();
                            if (name == "")
                            {
                                bool ffs = true;
                                while (ffs)
                                {
                                    Console.WriteLine("\tI said.. WHAT WOULD THE NAME OF THIS THINGOMAYING BE?");
                                    name = io.GetInput();
                                    if (name != "")
                                    {
                                        ffs = false;
                                    }
                                }
                            }
                            io.Print("\tHow many would you say it'd be? ");
                            Int32.TryParse(io.GetInput(), out quantity);
                            if (quantity > 0)
                            {
                                io.Print("\tHow would you describe this thing? ");
                                description = io.GetInput();
                                TavernODM item = new TavernODM { Name = name, Quantity = quantity, Description = description };
                                dao.Create(item);
                                io.Print($"\tYou dusted just enough space to store the {name} in the best available spot");
                                youSuck = false;
                            }
                            else
                            {
                                io.Print("\tNumerals... Please! Now you will start over");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        io.Print("\n\tThis is everything you have in your shitty tavern: \n");
                        dao.ReadAll().ForEach(thing =>
                        {
                            io.Print($"\tName = {thing.Name}, " +
                                $"\n\tQuantity = {thing.Quantity}, " +
                                $"\n\tDescription = {thing.Description}\n");
                        });
                        Console.ReadKey();
                        break;
                    case 3:
                        io.Print("\n\tThis is everything you have in your shitty tavern: ");
                        dao.ReadAll().ForEach(thing =>
                        {
                            io.Print($"\tName = {thing.Name}, " +
                                $"\n\tQuantity = {thing.Quantity}, " +
                                $"\n\tDescription = {thing.Description}\n");
                        });
                        io.Print("\n\tWhat object do you wish to manipulate? ");
                        name = io.GetInput();
                        if (dao.CheckIfNameExists(name))
                        {
                            dao.ReturnItem(name);
                            io.Print("\tWhat about this object doesn't match your expectations? ");
                            filter = io.GetInput();
                            io.Print("\tWhat do you want it to be instead? ");
                            update = io.GetInput();
                            dao.Update(name, filter, update);
                        }
                        else
                            io.Print("\tSorry, that object did not exist :( ");
                        Console.ReadKey();
                        break;
                    case 4:
                        io.Print("\n\tWhich object do you wish to remove? ");
                        name = io.GetInput();
                        if (dao.CheckIfNameExists(name))
                        {
                            dao.Delete(name);
                            io.Print($"\tWell done, all that remains where the {name} existed is a clean spot surrounded by dust.");
                            Console.ReadKey();
                        };
                        break;
                    case 5:
                        io.Exit();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }

            }

        }
    }
}
