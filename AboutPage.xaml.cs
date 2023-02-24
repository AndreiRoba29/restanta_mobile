using System.Diagnostics;

namespace ProgramareRevizie;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private void DeschideSite1(object sender, EventArgs e)
    {
        var url = "https://www.pieseauto.ro/";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void DeschideSite2(object sender, EventArgs e)
    {
        var url = "https://www.autokarma.ro/ ";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void DeschideSite3(object sender, EventArgs e)
    {
        var url = "https://www.autolux.ro/";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    

}