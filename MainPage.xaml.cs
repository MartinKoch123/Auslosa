namespace Auslosa;
public partial class MainPage : ContentPage
{

    private int _obaCounter = 0;
    private int _untaCounter = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAuslosaRequested(object sender, EventArgs e)
    {
        if (!Int32.TryParse(AppAiInputEntry.Text, out int wieVielMitmachet))
        {
            AppAiOutputLabel.Text = "Gib a Zahl ei, Seckel.";
            return;
        }
        if(wieVielMitmachet < 2)
        {
            AppAiOutputLabel.Text = "Zu wenig Leut.";
            return;
        }
        if (wieVielMitmachet > 100)
        {
            AppAiOutputLabel.Text = "Zu viel Leut.";
            return;
        }
        if(_obaCounter + _untaCounter >= wieVielMitmachet)
        {
            AppAiOutputLabel.Text = "Sind scho älle ausglost!";
            WieVielObaSind.Text = $"Oba: {_obaCounter}";
            WieVielUntaSind.Text = $"Unta: {_untaCounter}";
            return;
        }
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

        if (_obaCounter >= wieVielMitmachet / 2.0)
        {
            Zuedoila("unta");
        }
        else if (_untaCounter >= wieVielMitmachet / 2.0)
        {
            Zuedoila("oba");
        }
        else if (rnd.Next(0, 2) == 0)
        {
            Zuedoila("oba");
        }
        else
        {
            Zuedoila("unta");
        }
    }

    private void Zuedoila(string obaOderUnta)
    {
        AppAiOutputLabel.Text = $"Bisch {obaOderUnta}.";
        AuslosaBildle.IsAnimationPlaying = false;
        AuslosaBildle.Source = $"{obaOderUnta}.jpg";
        if (obaOderUnta == "oba")
        {
            _obaCounter++;
        }
        else
        {
            _untaCounter++;
        }
        WieVielObaSind.Text = $"Oba: {_obaCounter}";
        WieVielUntaSind.Text = $"Unta: {_untaCounter}";
    }
}
