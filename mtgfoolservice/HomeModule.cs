using Nancy;

namespace mtgfoolservice
{
	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			Get["/"] = _ =>
			{
				StaticConfiguration.DisableErrorTraces = false;
				dynamic viewBag = new DynamicDictionary();
				viewBag.WelcomeMessage = "Welcome to Nancy!";
				return View["home", viewBag];
			};
		}
	}
}