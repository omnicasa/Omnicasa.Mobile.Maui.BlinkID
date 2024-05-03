﻿using Omnicasa.Mobile.Maui.BlinkID.Models;

namespace Omnicasa.Mobile.Maui.BlinkID
{
    /// <summary>IBlinkIDService.</summary>
    public interface IBlinkIDService
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="licenseKey">string.</param>
        IObservable<bool> Initialize(string licenseKey);

        /// <summary>
        /// Scan.
        /// Limit = -1, scan forever.
        /// </summary>
        /// <returns>CardRecognizer.</returns>
        IObservable<CardRecognizer?> Scan(int limit = -1);
    }
}
