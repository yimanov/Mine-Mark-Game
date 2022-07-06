using System;

namespace Assets.FindDifferences.Scripts
{
    [Flags]
    public enum ChangeTypes
    {
        /// <summary>
        /// Hides an object from the scene
        /// </summary>
        Hide =              (1 << 0),

        /// <summary>
        /// Flips an obect vertically
        /// </summary>
        FlipVertical =      (1 << 1),

        /// <summary>
        /// Flip an object horizontally
        /// </summary>
        FlipHorizontal =    (1 << 2),

        /// <summary>
        /// Change the color of the object
        /// </summary>
        Colorize =           (1 << 3),

        /// <summary>
        /// Change the color of the object
        /// </summary>
        Move = (1 << 4),
    }
}