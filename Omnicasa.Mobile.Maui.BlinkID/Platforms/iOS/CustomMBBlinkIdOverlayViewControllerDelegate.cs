using Omnicasa.Mobile.Maui.BlinkID.iOS;
using Omnicasa.Mobile.Maui.BlinkID.Models;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.Maui.BlinkID.Platforms.iOS
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class CustomMBBlinkIdOverlayViewControllerDelegate
        : MBBlinkIdOverlayViewControllerDelegate
    {
        private readonly IMBBlinkIdOverlayViewControllerDelegate? mBBlinkIdOverlayViewControllerDelegate;

        private readonly Action<RecognizingState>? recognizingState;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMBBlinkIdOverlayViewControllerDelegate"/> class.
        /// </summary>
        /// <param name="mBBlinkIdOverlayViewControllerDelegate">IMBBlinkIdOverlayViewControllerDelegate.</param>
        public CustomMBBlinkIdOverlayViewControllerDelegate(
            IMBBlinkIdOverlayViewControllerDelegate mBBlinkIdOverlayViewControllerDelegate)
        {
            this.mBBlinkIdOverlayViewControllerDelegate = mBBlinkIdOverlayViewControllerDelegate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMBBlinkIdOverlayViewControllerDelegate"/> class.
        /// </summary>
        /// <param name="recognizingState">RecognizingState action.</param>
        public CustomMBBlinkIdOverlayViewControllerDelegate(Action<RecognizingState> recognizingState)
        {
            this.recognizingState = recognizingState;
        }

        /// <inheritdoc/>
        public override void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
        {
            mBBlinkIdOverlayViewControllerDelegate?.BlinkIdOverlayViewControllerDidFinishScanning(blinkIdOverlayViewController, state);
            recognizingState?.Invoke(RecognizingState.DidFinishedScanning);
        }

        /// <inheritdoc/>
        public override void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController)
        {
            mBBlinkIdOverlayViewControllerDelegate?.BlinkIdOverlayViewControllerDidFinishScanningFirstSide(blinkIdOverlayViewController);
            recognizingState?.Invoke(RecognizingState.DidFinishedScanningFirstSide);
        }

        /// <inheritdoc/>
        public override void BlinkIdOverlayViewControllerDidTapClose(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController)
        {
            mBBlinkIdOverlayViewControllerDelegate?.BlinkIdOverlayViewControllerDidTapClose(blinkIdOverlayViewController);
            recognizingState?.Invoke(RecognizingState.DidTapClose);
        }
    }
}
