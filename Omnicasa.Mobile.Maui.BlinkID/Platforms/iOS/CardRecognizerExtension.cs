#if !DEBUG
using System;
using Omnicasa.Mobile.Maui.BlinkID.iOS;
using Omnicasa.Mobile.Maui.BlinkID.Models;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.Maui.BlinkID.Platforms.iOS
#pragma warning restore SA1300
{
    /// <summary>CardRecognizerExtension.</summary>
    public static class CardRecognizerExtension
    {
        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="recognizerResult">MBBlinkIdMultiSideRecognizerResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizer? Parse(this MBBlinkIdMultiSideRecognizerResult recognizerResult)
        {
            if (recognizerResult == null)
            {
                return null;
            }

            return new CardRecognizer()
            {
                FirstName = recognizerResult.FirstName?.Value,
                LastName = recognizerResult.LastName?.Value,
                FullName = recognizerResult.FullName?.Value,
            };
        }
    }
}
#endif