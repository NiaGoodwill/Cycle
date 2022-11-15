using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snakes.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snakes heads.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction1 = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction1 = new Point(0, Constants.CELL_SIZE);
            }

            // up
            if (keyboardService.IsKeyDown("up"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // left
            if (keyboardService.IsKeyDown("left"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("right"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // down
            if (keyboardService.IsKeyDown("down"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }




            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.TurnHead(direction1);

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake2.TurnHead(direction2);


        }
    }
}