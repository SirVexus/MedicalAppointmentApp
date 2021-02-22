using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedicalAppointmentApp.Utilities
{
    /// <summary>
    /// Application utilities
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Generate random Id
        /// </summary>
        /// <returns></returns>
        public static int GenerateId()
        {
            Random rnd = new Random();
            return rnd.Next();
        }
        /// <summary>
        /// Gets error Message Control, message content and text color as parameters
        /// Sets Color and text for refferenced control
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void SetErrorMessage(TextBlock errorMessage, string message, Brush color)
        {
            errorMessage.Text = message;
            errorMessage.Foreground = color;
        }
    }
}
