using System.Text;
using Lemmy.Net.Types;
using LemmyApi;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

var separator = string.Join("", Enumerable.Repeat("-", Console.BufferWidth));
await foreach (var post in api.GetAllPosts(new GetPosts()
               {
                   Sort = SortType.Hot
               }))
{
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.WriteLine(separator);
    
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(post.Post.Name);
    
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine(post.Post.Body);
    Console.WriteLine(post.Post.Url);

    var readInput = true;
    while (readInput)
    {
        switch (Console.ReadKey().KeyChar)
        {
            case 'n':
                readInput = false;
                break;

            case 'q':
                return;

            default:
                Console.WriteLine("Unknown command entered. Press 'n' to go to the next post or 'q' to quit.");
                break;
        }    
    }
}