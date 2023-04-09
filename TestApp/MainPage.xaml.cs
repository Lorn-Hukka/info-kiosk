namespace idkwaid;

public partial class MainPage : ContentPage
{
	int count = 0;
    static SecPage secPage = new SecPage();

    public MainPage()
	{
		InitializeComponent();
        Window secondWindow = new Window(secPage);
        Application.Current.OpenWindow(secondWindow);
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
        count++;
        if (secPage.UstawLicznik(count)) { Zwrot.Text = $"otrzymano wiadomosc zwrotną {count} razy"; }
    }
}

