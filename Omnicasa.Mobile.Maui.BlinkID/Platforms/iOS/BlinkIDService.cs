using System.Reactive.Disposables;
using System.Reactive.Linq;
using Omnicasa.Mobile.Maui.BlinkID.iOS;
using Omnicasa.Mobile.Maui.BlinkID.Models;
using UIKit;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.Maui.BlinkID.Platforms.iOS
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDService
    {
        private MBBlinkIdMultiSideRecognizer? blinkIdMultiSideRecognizer;

        /// <inheritdoc/>
        public IObservable<bool> Initialize(string licenseKey)
        {
            return Observable.Create<bool>(o =>
            {
                var blinkInstance = MBMicroblinkSDK.Instance();
                if (blinkInstance == null)
                {
                    o.OnError(new NotSupportedException());
                }

                blinkInstance!.SetLicenseKey(licenseKey, (error) =>
                {
                    o.OnError(new Exception());
                });

                o.OnNext(true);
                o.OnCompleted();

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizer?> Scan()
        {
            UIViewController? scannerUIController = null;

            return Observable.Create<CardRecognizer?>(o =>
            {
                try
                {
                    blinkIdMultiSideRecognizer = new MBBlinkIdMultiSideRecognizer();

                    var scannerController = MakeScannerViewController(
                        new[] { blinkIdMultiSideRecognizer },
                        (state) =>
                        {
                            switch (state)
                            {
                                case RecognizingState.DidFinishedScanning:
                                    System.Diagnostics.Debug.WriteLine("DidFinishedScanning");
                                    o.OnNext(blinkIdMultiSideRecognizer.Result.Parse());
                                    break;

                                case RecognizingState.DidFinishedScanningFirstSide:
                                    System.Diagnostics.Debug.WriteLine("DidFinishedScanningFirstSide");
                                    break;

                                case RecognizingState.DidTapClose:
                                    System.Diagnostics.Debug.WriteLine("DidTapClose");
                                    o.OnCompleted();
                                    break;

                                default:
                                    break;
                            }
                        });

                    scannerUIController = ObjCRuntime.Runtime
                        .GetINativeObject<UIViewController>(scannerController.Handle, false);

                    var keyWindow = PlatformHelper.KeyWindow();
                    if (scannerUIController == null
                        || keyWindow == null
                        || keyWindow.RootViewController == null)
                    {
                        o.OnError(new InvalidOperationException("Expect KeyWindow"));
                    }

                    keyWindow!.RootViewController!.PresentViewController(
                        scannerUIController!,
                        true,
                        () =>
                        {
                            o.OnCompleted();
                        });
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }

                return Disposable.Create(() =>
                {
                    scannerUIController?.Dispose();
                    scannerUIController = null;
                });
            });
        }

        private IMBRecognizerRunnerViewController MakeScannerViewController(
            MBRecognizer[] mBRecognizers,
            Action<RecognizingState> action)
        {
            var settings = new MBBlinkIdOverlaySettings();
            var recognizerCollection = new MBRecognizerCollection(recognizers: mBRecognizers);
            var blinkIdOverlayViewController = new MBBlinkIdOverlayViewController(
                settings: settings,
                recognizerCollection: recognizerCollection,
                new CustomMBBlinkIdOverlayViewControllerDelegate(action));

            var recognizerRunneViewController =
                MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(blinkIdOverlayViewController);

            return recognizerRunneViewController;
        }
    }
}
