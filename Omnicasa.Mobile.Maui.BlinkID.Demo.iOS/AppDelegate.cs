using System.Reactive.Linq;
using CoreGraphics;
using Foundation;
using ReactiveUI;
using UIKit;

namespace Omnicasa.Mobile.Maui.BlinkID.Demo.iOS;

/// <inheritdoc/>
[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    /// <inheritdoc/>
    public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";

    /*
    private IBlinkIDService blinkIDService = new BlinkIDService();
    private IDisposable? currentScanner;
    */

    /// <inheritdoc/>
    public override UIWindow? Window
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        /*
        blinkIDService
            .Initialize(iOSLic)
            .Catch<bool, Exception>(_ => Observable.Return(false))
            .Subscribe(initialized =>
            {
                System.Diagnostics.Debug.WriteLine($"Register BLINKID with result => {initialized}");
            });
        */

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();

        var but = new UIButton(new CGRect(100, 100, 100, 100))
        {
            BackgroundColor = UIColor.Red,
            AutoresizingMask = UIViewAutoresizing.All,
        };
        but.SetTitle("Start scan", UIControlState.Normal);
        but.TouchUpInside += But_TouchUpInside;

        vc.View!.AddSubview(but);
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }

    private void But_TouchUpInside(object? sender, EventArgs e)
    {
        /*
        currentScanner?.Dispose();
        currentScanner = blinkIDService
            .Scan(1)
            .SubscribeOn(RxApp.MainThreadScheduler)
            .Catch<CardRecognizer?, Exception>(ex =>
            {
                System.Diagnostics.Debug.WriteLine($"Scanning throw error => {ex.GetType().Name}");
                return Observable.Return<CardRecognizer?>(null);
            })
            .Subscribe(card =>
            {
                System.Diagnostics.Debug.WriteLine($"Card => {card?.FirstName}");
            });
        */
    }
}
