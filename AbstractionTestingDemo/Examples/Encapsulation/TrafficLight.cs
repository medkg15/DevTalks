using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Encapsulation
{
    /// <summary>
    /// Represents a basic cross-intersection traffic light.
    /// </summary>
    public class TrafficLight
    {
        public enum Signal
        {
            Red,
            Green,
            Yellow
        };

        public enum Direction
        {
            NorthSouth,
            EastWest
        }

        private readonly Dictionary<Direction, Signal> state;
        private readonly TimeSpan greenInterval;
        private readonly TimeSpan yellowInterval;

        private TimeSpan currentTime;
        private bool isNorthSouthActive;
        private bool isYellow;

        /// <summary>
        /// Create a TrafficLight with the given Green and Yellow light intervals.
        /// </summary>
        /// <param name="greenInterval">Amount of time the light will stay green in one direction.</param>
        /// <param name="yellowInterval">Amount of time the light will stay yellow before changing to red.</param>
        public TrafficLight(TimeSpan greenInterval, TimeSpan yellowInterval)
        {
            this.state = new Dictionary<Direction, Signal>
            {
                [Direction.NorthSouth] = Signal.Green,
                [Direction.EastWest] = Signal.Red,
            };

            this.greenInterval = greenInterval;
            this.yellowInterval = yellowInterval;

            this.isNorthSouthActive = true;
            this.isYellow = false;
            this.currentTime = new TimeSpan();
        }

        /// <summary>
        /// Check the current light Signal for the given Direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Signal CheckSignal(Direction direction)
        {
            return state[direction];
        }

        /// <summary>
        /// Apply the given change of time to the StreetLight's state.
        /// </summary>
        /// <param name="delta"></param>
        public void AdvanceTime(TimeSpan delta)
        {
            currentTime += delta;

            if (isYellow && yellowInterval < currentTime)
            {
                state[Direction.NorthSouth] = isNorthSouthActive ? Signal.Red : Signal.Green;
                state[Direction.EastWest] = isNorthSouthActive ? Signal.Green : Signal.Red;

                isYellow = false;

                isNorthSouthActive = !isNorthSouthActive;
                currentTime = new TimeSpan();
            }

            if (!isYellow && greenInterval < currentTime)
            {
                if (isNorthSouthActive)
                {

                    state[Direction.NorthSouth] = Signal.Yellow;
                }
                else
                {
                    state[Direction.EastWest] = Signal.Yellow;
                }

                isYellow = true;
                currentTime = new TimeSpan();
            }
        }
    }
}
