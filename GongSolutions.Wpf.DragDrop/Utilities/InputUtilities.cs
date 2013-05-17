using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GongSolutions.Wpf.DragDrop.Utilities
{
    /// <summary>
    /// Utilities that help differentiate between different input event types.
    /// </summary>
    class InputUtilities
    {
        public static bool IsMouseButtonArgs(InputEventArgs e)
        {
            return null != e as MouseButtonEventArgs;
        }

        public static bool IsTouchArgs(InputEventArgs e)
        {
            return null != e as TouchEventArgs;
        }

        /// <summary>
        /// Returns a Func delegate that encapsulates a method that gets the position of the input event relative to
        /// an IInputElement.
        /// </summary>
        /// <param name="e">The input event args object</param>
        /// <returns>Func that takes in IInputElement and returns a Point</returns>
        public static Func<IInputElement, Point> GetPositionFunc(InputEventArgs e)
        {
            Func<IInputElement, Point> getPosition = null;

            if (IsMouseButtonArgs(e))
            {
                getPosition = ((MouseButtonEventArgs) e).GetPosition;
            }
            else if (IsTouchArgs(e))
            {
                getPosition = (el) => ((TouchEventArgs) e).GetTouchPoint(el).Position;
            }

            return getPosition;
        }

    }
}
