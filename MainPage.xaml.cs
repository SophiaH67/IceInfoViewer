using IceInfoViewer.Utils;

namespace IceInfoViewer
{
    public partial class MainPage : ContentPage
    {
        private bool isRefreshing;
        private IDispatcherTimer refreshTimer;
        

        public MainPage()
        {
            InitializeComponent();

            // Initialize refresh timer
            refreshTimer = Application.Current.Dispatcher.CreateTimer();
            refreshTimer.Interval = TimeSpan.FromSeconds(2);
            refreshTimer.Tick += (s, e) => _ = RefreshAsync();
            refreshTimer.Start();

        }

        private void SetRefreshing(bool value)
        {
            isRefreshing = value;
            RefreshingLabel.IsVisible = value;
        }

        private async Task RefreshAsync() { 
            if (isRefreshing)
                return;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                SetRefreshing(true);
            });

            IceInfo iceInfo;
            try {
                iceInfo = await IceInfoHelper.GetIceInfoAsync();

                if (iceInfo == null)
                    throw new Exception("Failed to fetch ice info");

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IceInfoSpeedLabel.Text = $"Speed: {iceInfo.Speed} km/h";
                    IceInfoClassLabel.Text = $"Class: {Util.UppercaseFirstChar(iceInfo.WagonClass)} Class";
                    IceInfoInternetSpeedLabel.Text = $"Internet Speed: {Util.UppercaseFirstChar(iceInfo.Internet)}";
                    IceInfoInternetStabilityLabel.Text = $"Internet Connectivity: {Util.CapitalizeEachWord(iceInfo.Connectivity.CurrentState.Replace('_', ' '))}";
                });
            } catch (Exception ex) {
                refreshTimer.Stop();
                await DisplayAlert("Error", ex.Message, "OK");
                refreshTimer.Start();

            } finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    SetRefreshing(false);
                });
            }

        }
    }

}
