using Xamarin.Forms;

namespace ZCMobileMasterDetailApp
{
    public class DetailPage : ContentPage
    {
        public DetailPage()
        {
            SideContentVisible = true;
        }

        public bool SideContentVisible { get; set; }
    }
}