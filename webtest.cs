class Program
	{
		
		public static bool WebSiteIsAvailable(string Url)
		{
			string Message = string.Empty;
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
			
			//var isSecured=request.Scheme;
			//Console.WriteLine(isSecured);
//			if(isSecured)
//				Console.WriteLine(true.ToString());
//			else
//				Console.WriteLine(false.ToString());

			
			request.Credentials = System.Net.CredentialCache.DefaultCredentials;
			request.Method = "GET";

			try
			{
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					
				}
			}
			catch (WebException ex)
			{
				Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
			}

			return (Message.Length == 0);
		}
		
		public static void Main(string[] args)
		{
			System.Console.WriteLine(WebSiteIsAvailable("http://www.youtube.com/"));
			System.Console.WriteLine(WebSiteIsAvailable("https://www.youtube.com/"));
			System.Console.WriteLine(WebSiteIsAvailable("http://www.try.dot.net/"));
			System.Console.WriteLine(WebSiteIsAvailable("https://www.try.dot.net/"));
			System.Console.WriteLine(WebSiteIsAvailable("https://csharp-video-tutorials.blogspot.com"));
			System.Console.WriteLine(WebSiteIsAvailable("http://csharp-video-tutorials.blogspot.com"));
			System.Console.WriteLine(WebSiteIsAvailable("https://onecognizant.cognizant.com"));
			System.Console.WriteLine(WebSiteIsAvailable("http://onecognizant.cognizant.com"));
			System.Console.ReadLine();
		
		}
	}
