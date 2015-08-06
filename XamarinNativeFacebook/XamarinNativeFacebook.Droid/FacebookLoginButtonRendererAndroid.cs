using System;
using Android.App;
using Android.Content;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNativeFacebook;
using XamarinNativeFacebook.Droid;
using Object = Java.Lang.Object;
using View = Android.Views.View;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Share;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererAndroid))]
namespace XamarinNativeFacebook.Droid
{

	public class FacebookLoginButtonRendererAndroid : ViewRenderer<Button, LoginButton>
    {
        private static Activity _activity;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            _activity = this.Context as MainActivity;
			var loginButton = new LoginButton (this.Context);
				var facebookCallback = new FacebookCallback<LoginResult> {
				HandleSuccess = shareResult => {
                    Action<string> local = App.PostSuccessFacebookAction;
                    if (local != null)
                    {
                        local(shareResult.AccessToken.Token);
                    }
                }
			,
			HandleCancel = () => {
				Console.WriteLine ("HelloFacebook: Canceled");
			},
			HandleError = shareError => {
				Console.WriteLine ("HelloFacebook: Error: {0}", shareError);
				}
			};
			loginButton.RegisterCallback (MainActivity.CallbackManager, facebookCallback);
			base.SetNativeControl (loginButton);
        }
    }
}