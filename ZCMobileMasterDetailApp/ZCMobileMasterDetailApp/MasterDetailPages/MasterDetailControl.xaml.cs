using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZCMobileMasterDetailApp.Model;
using ZCMobileMasterDetailApp.ViewModel;

namespace ZCMobileMasterDetailApp.MasterDetailPages
{
    public partial class MasterDetailControl
    {

        public static readonly BindableProperty SideContentProperty = BindableProperty.Create("SideContent",
            typeof(View), typeof(MasterDetailControl), null, propertyChanged: (bindable, value, newValue) =>
            {
                var control = (MasterDetailControl)bindable;
                //control.SideContentContainer.Children.Clear();
                //control.SideContentContainer.Children.Add(control.SideContent);
            });

        public readonly BindableProperty DetailProperty = BindableProperty.Create("Detail",
            typeof(ContentPage), typeof(MasterDetailControl),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                masterPage.DetailContainer.Content = newValue != null ?
                    ((ContentPage)newValue).Content : null;
                masterPage.OnPropertyChanged("SideContentVisibility");
            });
        public ContentPage Detail
        {
            get { return (ContentPage)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        public View SideContent
        {
            get { return (View)GetValue(SideContentProperty); }
            set { SetValue(SideContentProperty, value); }
        }

        public bool SideContentVisible
        {
            get
            {
                var detailPage = Detail as DetailPage;
                if (detailPage != null)
                {
                    return detailPage.SideContentVisible;
                }
                return true;
            }
        }

        public static Page Create<TView, TViewModel>(bool userLoggedIn = true, Page page = null) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel, new()
        {
            return Create<TView, TViewModel>(new TViewModel(), userLoggedIn, page);
        }

        public static Page Create<TView, TViewModel>(TViewModel viewModel, bool userLoggedIn = true, Page page = null) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel
        {
            var masterDetail = new TView();
            var navigationPage = new NavigationPage(masterDetail);
            viewModel.SetNavigation(navigationPage.Navigation);
            masterDetail.BindingContext = viewModel;
            App.MasterDetailVM = viewModel;
            var navigationData = new ZCMobileNavigationData
            {
                CurrentPage = page,
                //CurrentPageTitle = page.Title
            };
            App.MasterDetailVM.PushAsync1(navigationData);
            return navigationPage;
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MasterDetailControlViewModel;
            if (viewModel != null)
            {
                var navigation = (INavigation)viewModel;
                navigation.PopAsync();
                return true;
            }
            return base.OnBackButtonPressed();
        }

        public MasterDetailControl()
        {
            InitializeComponent();
            SetBinding(DetailProperty, new Binding("Detail", BindingMode.OneWay));
        }

    }

}
