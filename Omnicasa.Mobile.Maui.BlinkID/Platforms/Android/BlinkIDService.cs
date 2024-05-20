using System.Reactive.Disposables;
using System.Reactive.Linq;
using AndroidX.Activity.Result;
using Com.Microblink;
using Com.Microblink.Blinkid;
using Com.Microblink.Blinkid.Intent;
using Omnicasa.Mobile.Maui.BlinkID.Models;

namespace Omnicasa.Mobile.Maui.BlinkID.Platforms.Android
{
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDService
    {
        private class ActivityResultCallback : Java.Lang.Object, IActivityResultCallback
        {
            private readonly Action<ActivityResult?> callback;

            public ActivityResultCallback(Action<ActivityResult?> callback) =>
                this.callback = callback;

            public ActivityResultCallback(TaskCompletionSource<ActivityResult?> tcs) =>
                callback = tcs.SetResult;

            public void OnActivityResult(Java.Lang.Object? result)
            {
                if (result is ActivityResult activityResult)
                {
                    callback(activityResult);
                }
                else
                {
                    callback(null);
                }
            }
        }

        /// <inheritdoc/>
        public IObservable<bool> Initialize(string licenseKey)
        {
            return Observable.Create<bool>(o =>
            {
                var context = PlatformHelper.Context;
                if (context == null)
                {
                    o.OnError(new ArgumentException("Expect Context"));
                }

                MicroblinkSDK.SetLicenseKey(licenseKey, context!);

                if (IntentDataTransferMode.PersistedOptimised != null)
                {
                    MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;
                }

                o.OnNext(true);
                o.OnCompleted();

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizer?> Scan(int limit = -1)
        {
            var currentActivity = PlatformHelper.Activity;

            var observable = Observable.Create<CardRecognizer?>(o =>
            {
                if (currentActivity is not AndroidX.Activity.ComponentActivity componentActivity)
                {
                    o.OnError(new ArgumentException("Expect ComponentActivity"));
                }

                o.OnNext(null);
                o.OnCompleted();

                return Disposable.Create(() =>
                {
                });
            });

            return observable;
        }
    }
}
