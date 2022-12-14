using Unit05.Game;
using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;

using System.Numerics;

namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            // cast.AddActor("snake1", new Snake(Constants.GREEN, 1));
            // cast.AddActor("snake2", new Snake(Constants.RED, 3));
            cast.AddActor("food", new Food());
            cast.AddActor("snake1", new Snake (Constants.GREEN, new Vector2(Constants.CELL_SIZE * 4, Constants.CELL_SIZE * 4)));
            cast.AddActor("snake2", new Snake (Constants.RED, new Vector2(Constants.CELL_SIZE * 12, Constants.CELL_SIZE * 12)));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("update", new GrowSnakesAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}