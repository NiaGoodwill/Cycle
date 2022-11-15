using Unit05.Game.Casting;

namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that increases the length of the snakes.</para>
    /// <para>The responsibility of GrowSnakesAction is to increase the length of both snakes.</para>
    /// </summary>

    public class GrowSnakesAction : Action
    {
        int counter = 0;

        /// <summary>
        /// Constructs a new instance of GrowSnakesAction.
        /// </summary>
        public GrowSnakesAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");

            if (counter != 20)
            {
                counter += 1;
            }
            else
            {
                counter = 0;
                snake1.GrowTail(1);
                snake2.GrowTail(1);
            }
        }
    }

}
