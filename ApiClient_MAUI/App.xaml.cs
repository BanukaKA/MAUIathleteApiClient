using ApiClient_MAUI.Models;

namespace ApiClient_MAUI;

public partial class App : Application
{
	public bool needSportRefresh;
	public List<Sport> AllSports;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
