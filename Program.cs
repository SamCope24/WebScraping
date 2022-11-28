Console.WriteLine("Let's get scraping!");

var pageContent = await CallUrl("https://en.wikipedia.org/wiki/List_of_programmers");
Console.WriteLine(pageContent);

static async Task<string> CallUrl(string url)
{
    HttpClient httpClient = new();
    var response = await httpClient.GetStringAsync(url);
    return response;
}
