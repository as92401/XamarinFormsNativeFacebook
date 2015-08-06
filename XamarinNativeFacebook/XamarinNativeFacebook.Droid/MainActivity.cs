using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XamarinNativeFacebook.Droid
{
    [Activity(Label = "XamarinNativeFacebook", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
		public static ICallbackManager CallbackManager = CallbackManagerFactory.Create();
        public static readonly string[] PERMISSIONS = new[] { "publish_actions" };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
			CallbackManager.OnActivityResult (requestCode, (int)resultCode, data);
        }
    }
}