namespace idkwaid;

public partial class SecPage : ContentPage
{
	public SecPage()
	{
		InitializeComponent();
	}

	public bool UstawLicznik(int? licznik)
	{
        switch (licznik)
        {
            case 1:
                LicznikInterakcji.Text = $"Wykonano interakcje {licznik} raz";
                break;
            default:
                LicznikInterakcji.Text = $"Wykonano interakcje {licznik} razy";
                break;
        }
        return true;
    }
}