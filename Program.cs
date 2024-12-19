class Program
{
  static void Main()
  {
    string[] usernames = [];
    string[] passwords = [];
    string[] userids = [];
    int port = 5000;

    var server = new Server(port);


    Console.WriteLine("The server is running");
    Console.WriteLine($"Main Page: http://localhost:{port}/website/pages/index.html");

    while (true)
    {
      (var request, var response) = server.WaitForRequest();

      Console.WriteLine($"Recieved a request with the path: {request.Path}");

      if (File.Exists(request.Path))
      {
        var file = new File(request.Path);
        response.Send(file);
      }
      else if (request.ExpectsHtml())
      {
        var file = new File("website/pages/404.html");
        response.SetStatusCode(404);
        response.Send(file);
      }
      else
      {
        try
        {
          if (request.Path == "signup")
          {
            (string username, string password) = request.GetBody<(string, string)>();

            string userid = Guid.NewGuid().ToString();

            usernames = [.. usernames, username];
            passwords = [.. passwords, password];
            userids = [.. userids, userid];

            response.Send(userid);
          }
          response.SetStatusCode(405);
        }
        catch (Exception exception)
        {
          Log.WriteException(exception);
        }
      }

      response.Close();
    }
  }
}