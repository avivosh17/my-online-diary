  class User{
    string username;
    string password;
    string firstpage;
    string secondpage;
    string id;
  
  public User(string username, string password, string firstpage, string secondpage, string id)
  {
    this.username = username;
    this.password = password;
    this.firstpage = firstpage;
    this.secondpage = secondpage;
    this.id = id;

  }
  }
class Program
{
  static void Main()
  {
    string[] usernames = [];
    string[] passwords = [];
    string[] userids = [];
   /* string[] rightpage = [];
    string[] leftpage = [];*/
    string[] users =[];
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
          else if (request.Path == "login")
          {
            (string username, string password) = request.GetBody<(string, string)>();

            string? userid = null;

            Console.WriteLine(username + "+ " + password);

            for (int i = 0; i < userids.Length; i++)
            {
              Console.WriteLine(usernames[i] + ", " + passwords[i]);
              if (username == usernames[i] && password == passwords[i])
              {
                userid = userids[i];
              }
            }

            response.Send(userid);
          }
      /*  else if (request.Path == "savediary")
          {
            (string diarypage2, string diarypage1, string userid) = request.GetBody<(string, string, string)>();
            
            for (int i = 0; i < userids.Length; ++i)
            {
              if (userids[i] == userid)
              {
                rightpage[i] = diarypage2;
                leftpage[i] = diarypage1;
              }
            }
          }
          else if (request.Path == "loaddiary")
          {
            string userid = request.GetBody<string>();
            for (int i = 0; i < userids.Length; ++i)
            {
              if (userids[i] == userid)
              {
                response.Send(rightpage[i]);
              }
            }
          }
          else if (request.Path == "loaddiary2")
          {
            string userid = request.GetBody<string>();
            for (int i = 0; i < userids.Length; ++i)
            {
              if (userids[i] == userid)
              {
                response.Send(leftpage[i]);
              }
            }
          }*/

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