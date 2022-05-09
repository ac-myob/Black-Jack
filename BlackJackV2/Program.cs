using BlackJackV2.Business.Control;
using BlackJackV2.Business.View.IO;

var gameEngine = new GameEngine(new ConsoleReader(), new ConsoleWriter());

gameEngine.Run();