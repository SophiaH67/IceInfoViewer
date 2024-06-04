using IceInfoViewer.Utils;

namespace IceInfoViewer
{
    public partial class MainPage : ContentPage
    {
        private bool isRefreshing;
        

        public MainPage()
        {
            InitializeComponent();

            // Do initial fetching of ice info
            //Task.Run(async () => { 
            //    await Refresh();
            //    LoadingLabel.IsVisible = false;
            //});

            SetRefreshing(false);
   
        }

        private void SetRefreshing(bool value)
        {
            isRefreshing = value;
            RefreshButton.Text = value ? "Refreshing..." : "Refresh";
            RefreshButton.IsEnabled = !value;
            IceInfoContainer.IsVisible = !value;
        }

        private async void OnRefreshClicked(object sender, EventArgs e) => await Refresh();

        private async Task Refresh() { 
            if (isRefreshing)
                return;

            SetRefreshing(true);
            IceInfo iceInfo;
            try {
                iceInfo = await IceInfoHelper.GetIceInfoAsync();
            IceInfoSpeedLabel.Text = $"Speed: {iceInfo.Speed} km/h";
            } catch (Exception ex) {
                _ = DisplayAlert("Error", ex.Message, "OK");
            } finally
            {
                SetRefreshing(false);
            }

        }
    }

}
