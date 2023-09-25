namespace CodeQuotes;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
        base.OnAppearing();

        await LoadMauiAsset();
    }

	Random random = new Random();
	List<string> quotes = new List<string>();

    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

        while (reader.Peek() != -1)
		{
            quotes.Add(reader.ReadLine());
        }
    }

    private void btnGenerateQuote_Clicked(object sender, EventArgs e)
    {
		var startColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        var endColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        var colors = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);

		float stopOffset = 0.0f;
		var stops = new GradientStopCollection();

		foreach (var color in colors)
		{
			stops.Add(new GradientStop(Color.FromArgb(color.Name), stopOffset));
			stopOffset += 0.2f;
		}

		var gradient = new LinearGradientBrush(stops, new Point(0,0), new Point(1,1));

		background.Background = gradient;


		int index = random.Next(quotes.Count);
		quote.Text = quotes[index];
    }
}

