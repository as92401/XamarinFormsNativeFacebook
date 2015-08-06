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
            callbackManager = CallbackManagerFactory.Create();

            var loginCallback = new FacebookCallback<LoginResult>
            {
                HandleSuccess = loginResult =>
                {
                    //HandlePendingAction();
                    //UpdateUI();
                },
                HandleCancel = () =>
                {
                    //if (pendingAction != PendingAction.NONE)
                    //{
                    //    ShowAlert(
                    //        GetString(Resource.String.cancelled),
                    //        GetString(Resource.String.permission_not_granted));
                    //    pendingAction = PendingAction.NONE;
                    //}
                    //UpdateUI();
                },
                HandleError = loginError =>
                {
                    //if (pendingAction != PendingAction.NONE
                    //    && loginError is FacebookAuthorizationException)
                    //{
                    //    ShowAlert(
                    //        GetString(Resource.String.cancelled),
                    //        GetString(Resource.String.permission_not_granted));
                    //    pendingAction = PendingAction.NONE;
                    //}
                    //UpdateUI();
                }
            };
            LoginManager.Instance.RegisterCallback(callbackManager, loginCallback);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
			callbackManager.OnActivityResult (requestCode, (int)resultCode, data);
        }
    }
}