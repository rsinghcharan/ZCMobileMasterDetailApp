using System;

using Xamarin.Forms;

namespace ZCMobileMasterDetailApp.Model
{
    public class ZCMobileNavigationData     {
        #region Public Properties         public Page CurrentPage { get; set; }         public Page NextPage { get; set; }         public string CurrentPageTitle { get; set; }         public string NextPageTitle { get; set; }         public RightButtonNavigationData NextToNavigate { get; set; }         public RightButtonNavigationData CurrentToNavigate { get; set; }
        #endregion     }
}

