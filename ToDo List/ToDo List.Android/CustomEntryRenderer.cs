using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Lab1.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(MyRenderer))]
namespace Lab1.Droid
{
    class MyRenderer : EntryRenderer
    {
        public MyRenderer(Context context) : base(context)
        {

        }

        void SetColor(Android.Graphics.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(color);
            }
            else
            {
                Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            Control.SetPadding(35, 25, 25, 25);

            if (Control != null)
            {
                SetColor(Android.Graphics.Color.Transparent);

                this.EditText.FocusChange += (sender, ee) => {
                    SetColor(Android.Graphics.Color.Transparent);
                };
            }
        }
    }
}