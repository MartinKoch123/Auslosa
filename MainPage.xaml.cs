namespace Auslosa {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private async void OnAuslosaRequested(object sender, EventArgs e) {

            AuslosaButton.IsEnabled = false;
            AuslosaBildle.Source = "auslosa.gif";
            AuslosaBildle.IsAnimationPlaying = true;
            ThinkingIndicator.IsRunning = true;
            AppAiOutputLabel.Text = "Wart ...";

            Random rnd = new();
            int snuffSimulationTimeMs = rnd.Next(2000, 3000);  

            await Task.Delay(snuffSimulationTimeMs);

            AuslosaButton.IsEnabled = true;
            ThinkingIndicator.IsRunning = false;
            if (rnd.Next(0, 2) == 0)
            {
                AppAiOutputLabel.Text = "Bisch oba.";
                AuslosaBildle.IsAnimationPlaying = false;
                AuslosaBildle.Source = "oba.jpg";
            }
            else
            {
                AppAiOutputLabel.Text = "Bisch unta.";
                AuslosaBildle.IsAnimationPlaying = false;
                AuslosaBildle.Source = "unta.jpg";
            }
        }
    }
}
