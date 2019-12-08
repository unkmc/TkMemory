using System;
using System.Threading.Tasks;

namespace TkMemory.Integration.TkClient.Properties.Commands.Peasant
{
    /// <summary>
    /// Commands for moving the player around the current map.
    /// </summary>
    public class PeasantMovementCommands
    {

        #region Fields

        private readonly TkClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes commands for moving the player.
        /// </summary>
        /// <param name="self">The game client data for the player.</param>
        public PeasantMovementCommands(TkClient self)
        {
            _self = self;
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// Directions in which a player may be moved.
        /// </summary>
        public enum Direction { None, Up, Right, Down, Left }

        #endregion Enums

        #region Public Methods

        /// <summary>
        /// Moves a player in the specified direction.
        /// </summary>
        /// <param name="direction">The direction in which to move the player.</param>
        /// <returns>True if a movement command is sent; false otherwise.</returns>
        public async Task<bool> Move(Direction direction)
        {
            if (direction == Direction.None)
            {
                return false;
            }

            await _self.Activity.WaitForMovementCooldown();
            var directionKey = $"{{{direction.ToString()}}}";
            _self.Send($"{Keys.Esc}{directionKey}");
            _self.Activity.ResetCommandCooldown();

            return true;
        }

        /// <summary>
        /// Moves a player toward the specified target.
        /// </summary>
        /// <param name="target">The multibox target to follow.</param>
        /// <param name="distance">The maximum distance from the target that is allowed before movement commands will be sent.</param>
        /// <returns>True if a movement command is sent; false otherwise.</returns>
        public async Task<bool> Follow(TkClient target, uint distance)
        {
            await _self.Activity.WaitForMovementCooldown();
            var direction = GetFollowDirection(target, distance);
            return await Move(direction);
        }

        #endregion Public Methods

        #region Private Methods

        private Direction GetFollowDirection(TkClient target, uint distance)
        {
            if (target.Environment.Map.Name != _self.Environment.Map.Name)
            {
                return Direction.None;
            }

            var x = (int)target.Environment.Map.Coordinates.X - (int)_self.Environment.Map.Coordinates.X;
            var y = (int)target.Environment.Map.Coordinates.Y - (int)_self.Environment.Map.Coordinates.Y;

            if (Math.Abs(x) >= Math.Abs(y) && Math.Abs(x) > distance)
            {
                return x > 0
                    ? Direction.Right
                    : Direction.Left;
            }

            if (Math.Abs(y) > distance)
            {
                return y > 0
                    ? Direction.Down
                    : Direction.Up;
            }

            return Direction.None;
        }

        #endregion Private Methods
    }
}
