using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliberateCreation.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PancakeTextInput : ContentView
    {
        public static BindableProperty OpenTextInputCommandProperty =
            BindableProperty.Create(nameof(OpenTextInputCommand), typeof(ICommand), typeof(PancakeTextInput), null, BindingMode.OneWayToSource);

        public ICommand OpenTextInputCommand
        {
            get { return (ICommand)GetValue(OpenTextInputCommandProperty); }
            set { SetValue(OpenTextInputCommandProperty, value); }
        }
        
        
        public PancakeTextInput()
        {
            InitializeComponent();
            
            OpenTextInputCommand = new Command(OpenTextInput);
        }
        
        // private void OpenCloseTextInput(object sender, EventArgs e)
        // {
        //
        //     var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        //
        //
        //     if (MyDraggableView.Height == 0)
        //     {
        //         Action<double> callback = input => MyDraggableView.HeightRequest = input;
        //         double startHeight = 0;
        //         double endHeight = mainDisplayInfo.Height / 6;
        //         uint rate = 32;
        //         uint length = 500;
        //         Easing easing = Easing.CubicOut;
        //         MyDraggableView.Animate("anim", callback, startHeight, endHeight, rate, length, easing);
        //     }
        //     else
        //     {
        //         Action<double> callback = input => MyDraggableView.HeightRequest = input;
        //         double startHeight = mainDisplayInfo.Height / 6;
        //         double endiendHeight = 0;
        //         uint rate = 32;
        //         uint length = 500;
        //         Easing easing = Easing.SinOut;
        //         MyDraggableView.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
        //
        //     }
        // }

        private void OpenTextInput()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            Action<double> callback = input => MyDraggableView.HeightRequest = input;
            double startHeight = 0;
            double endHeight = mainDisplayInfo.Height / 4;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            MyDraggableView.Animate("anim", callback, startHeight, endHeight, rate, length, easing);

            txtEntry.Focus();
        }
        
        //private void CloseTextInput()
        private void CloseTextInput(object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            Action<double> callback = input => MyDraggableView.HeightRequest = input;
            double startHeight = mainDisplayInfo.Height / 4;
            double endHeight = 0;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            MyDraggableView.Animate("anim", callback, startHeight, endHeight, rate, length, easing);
        }
    }
}