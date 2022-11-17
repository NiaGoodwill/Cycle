using System.Collections.Generic;
using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when either snake 
    /// collides with the other snake, or either snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private string winner = "";

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleSnakeCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score and moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>

        // private void HandleFoodCollisions(Cast cast)
        // {
            // Snake snake = (Snake)cast.GetFirstActor("snake");
            // Score score = (Score)cast.GetFirstActor("score");
            // Food food = (Food)cast.GetFirstActor("food");
            // 
            // // if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
            // {
                // int points = food.GetPoints();
                // snake.GrowTail(points);
                // score.AddPoints(points);
                // food.Reset();
            // }
        // }

        /// <summary>
        /// Sets the game over flag and the winner if the snakes collide.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSnakeCollisions(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head1 = snake1.GetHead();
            Actor head2 = snake2.GetHead();
            List<Actor> body1 = snake1.GetBody();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    winner = "Green";
                }
            }

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winner = "Red";
                }
            }


        }

        /// <summary>
        /// Sets the game over flag and the winner if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head1 = snake1.GetHead();
            Actor head2 = snake2.GetHead();
            List<Actor> body1 = snake1.GetBody();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winner = "Red";
                }
            }
            
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    winner = "Green";
                }
            }

        }

        /// <summary>
        /// Creates "game over" and "winner" messages and makes everything white.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments1 = snake1.GetSegments();
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2 - 4 * Constants.CELL_SIZE;
                int y = Constants.MAX_Y / 2 - 3 * Constants.CELL_SIZE;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // create a "winner" message
                int X = Constants.MAX_X / 2 - 4 *Constants.CELL_SIZE;
                int Y = (Constants.MAX_Y / 2) + 30 - 3 * Constants.CELL_SIZE;
                Point Position = new Point(X, Y);

                Actor Winner = new Actor();
                Winner.SetText($"Winner: {winner}");
                Winner.SetPosition(Position);
                cast.AddActor("winner", Winner);


                // make everything white
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }

                snake1.SetSnakeColor(Constants.WHITE);
                snake2.SetSnakeColor(Constants.WHITE);

            }
        }

    }
}