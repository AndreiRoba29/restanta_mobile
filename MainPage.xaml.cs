namespace ProgramareRevizie;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Ai reparat {count} masini";
		else
			CounterBtn.Text = $"Ai reparat {count} masini";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

