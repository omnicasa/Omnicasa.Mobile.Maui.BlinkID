using Omnicasa.Mobile.Maui.BlinkID.iOS;


namespace Omnicasa.Mobile.Maui.BlinkID.Demo.iOS;

public interface IMBBlinkIdOverlayViewControllerDelegate
{
    void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state);
    void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(MBBlinkIdOverlayViewController blinkIdOverlayViewController);
}

public class CMBBlinkIdOverlayViewControllerDelegate : MBBlinkIdOverlayViewControllerDelegate
{
    private IMBBlinkIdOverlayViewControllerDelegate mBBlinkIdOverlayViewControllerDelegate;

    public CMBBlinkIdOverlayViewControllerDelegate(IMBBlinkIdOverlayViewControllerDelegate mBBlinkIdOverlayViewControllerDelegate)
    {
        this.mBBlinkIdOverlayViewControllerDelegate = mBBlinkIdOverlayViewControllerDelegate;
    }

    public override void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
    {
        mBBlinkIdOverlayViewControllerDelegate.BlinkIdOverlayViewControllerDidFinishScanning(blinkIdOverlayViewController, state);
    }

    public override void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
        mBBlinkIdOverlayViewControllerDelegate.BlinkIdOverlayViewControllerDidFinishScanningFirstSide(blinkIdOverlayViewController);
    }

    public override void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
        mBBlinkIdOverlayViewControllerDelegate.BlinkIdOverlayViewControllerDidTapClose(blinkIdOverlayViewController);
    }
}

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate, IMBBlinkIdOverlayViewControllerDelegate
{
    public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";
    MBBlinkIdMultiSideRecognizer blinkIdMultiSideRecognizer;


    public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

        var blinkInstance = MBMicroblinkSDK.Instance();


        blinkInstance.SetLicenseKey(iOSLic, (error) =>
        {

        });
        blinkIdMultiSideRecognizer = new MBBlinkIdMultiSideRecognizer();


        // create a UIViewController with a single UILabel
        var vc = new UIViewController ();

		var but = new UIButton(new CGRect(100, 100, 100, 100))
		{
			BackgroundColor = UIColor.Red,
			AutoresizingMask = UIViewAutoresizing.All,
		};
		but.SetTitle("Start scan", UIControlState.Normal);
        but.TouchUpInside += But_TouchUpInside;

        vc.View!.AddSubview (but);
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}

    private void But_TouchUpInside(object? sender, EventArgs e)
    {
		var recognizerRunnerViewController = MakeUIViewController();
		var viewController = ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false);


		Window?.RootViewController?.PresentViewController(viewController!, true, null);
    }


    public IMBRecognizerRunnerViewController MakeUIViewController()
    {

        MBBlinkIdOverlaySettings settings = new MBBlinkIdOverlaySettings();

        var recognizerList = new MBRecognizer[1]
		{
            blinkIdMultiSideRecognizer
        }; 
		var recognizerCollection = new MBRecognizerCollection(recognizers: recognizerList);

        var blinkIdOverlayViewController =
			new MBBlinkIdOverlayViewController(settings: settings, recognizerCollection: recognizerCollection, new CMBBlinkIdOverlayViewControllerDelegate(this));

        var recognizerRunneViewController =
			MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(blinkIdOverlayViewController)!;


		return recognizerRunneViewController;
	}

    public void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
    {
        var result = blinkIdMultiSideRecognizer?.Result;
        if (result != null)
        {
            System.Diagnostics.Debug.WriteLine(result.Description);
        }
    }

    public void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
    }

    public void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
    }
}

