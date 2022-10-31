using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public ICommand LongPressCommand { get; set; }
        private bool isPinching = false;
        private bool isPanning = false;
        public bool IsLongPress { get; set; }
        public MainPage()
        {
           
            InitializeComponent();           
            LongPressCommand = new Command<string>(LongPress);
            BindingContext = this;
        }
        public void LongPress(string flag)
        {
            if (isPinching || isPanning)
                return;
                status.Text = "Long Press";

        }
        private  void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:                   
                    isPinching = true;
                    isPanning = false;
                    break;

                case GestureStatus.Running:
                    if (!isPinching || isPanning)
                        return;
                    status.Text = "PINCH";
                    break;

                case GestureStatus.Completed:
                    isPinching = false;
                    break;
            }

         }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    isPanning = true;
                    isPinching = false;
                    break;

                case GestureStatus.Running:
                    if (isPinching || !isPanning)
                        return;
                    status.Text = "PAN";
                    break;

                case GestureStatus.Completed:
                    isPanning = false;
                    break;
            }

        }
    }
}
