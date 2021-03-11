using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo_List.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace ToDo_List.iOS
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
                return;
            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = Color.Transparent.ToCGColor();
        }
    }
}