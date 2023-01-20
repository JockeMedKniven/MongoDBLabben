IUIIO io;
ITavernDAO dao;
io = new TextIO();
dao = new TavernDAO("YeOldeTavern", "mongodb+srv://new-user-31:old-user-31@cluster0.dwwr7ta.mongodb.net/?retryWrites=true&w=majority");
Controller controller = new Controller(io, dao);
controller.StartProgram();