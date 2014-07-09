using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using DuduCat.Config;

namespace TodayHistory
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void lunar_DoubleTap(object sender, GestureEventArgs e)
        {
            ActiveConfig.ClearCache();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            date.Text = DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
            ActiveConfig.GetTextAsync("lunar", "", (s) => lunar.Text = s);
            ActiveConfig.GetTextAsync("history", "", (s) =>
            {
                var lines = s.Split('\n');
                headline.Text = lines[0].Trim();
                rest.Text = string.Join("\n", lines.Skip(1).Select(x => x.Trim()));
            });
            ActiveConfig.GetImageAsync("cover", null, (p) =>
            {
                if (p != null)
                {
                    cover.Source = p;
                    loading.Visibility = System.Windows.Visibility.Collapsed;
                    headline_box.Visibility = System.Windows.Visibility.Visible;
                }
            });
        }
    }
}