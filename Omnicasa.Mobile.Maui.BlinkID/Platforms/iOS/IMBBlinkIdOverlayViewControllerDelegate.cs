using Omnicasa.Mobile.Maui.BlinkID.iOS;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.Maui.BlinkID.Platforms.iOS
#pragma warning restore SA1300
{
    /// <summary>IMBBlinkIdOverlayViewControllerDelegate.</summary>
    public interface IMBBlinkIdOverlayViewControllerDelegate
    {
        /// <summary>
        /// BlinkIdOverlayViewControllerDidFinishScanning.
        /// </summary>
        /// <param name="blinkIdOverlayViewController">MBBlinkIdOverlayViewController.</param>
        /// <param name="state">MBRecognizerResultState.</param>
        void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state);

        /// <summary>
        /// BlinkIdOverlayViewControllerDidTapClose.
        /// </summary>
        /// <param name="blinkIdOverlayViewController">MBBlinkIdOverlayViewController.</param>
        void BlinkIdOverlayViewControllerDidTapClose(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController);

        /// <summary>
        /// BlinkIdOverlayViewControllerDidFinishScanningFirstSide.
        /// </summary>
        /// <param name="blinkIdOverlayViewController">MBBlinkIdOverlayViewController.</param>
        void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }
}
