using HtmlAgilityPack;

Console.WriteLine("Let's get scraping!");

var pageContent = await CallUrl("https://en.wikipedia.org/wiki/List_of_programmers");
var parsedHtml = ParseHtml(pageContent);

foreach (var item in parsedHtml)
{
    Console.WriteLine(item);
}

static Task<string> CallUrl(string url)
{
    HttpClient httpClient = new();
    return httpClient.GetStringAsync(url);
}

static List<string> ParseHtml(string html)
{
    HtmlDocument htmlDoc = new();
    htmlDoc.LoadHtml(html);

    var programmerLinkNodes = htmlDoc.DocumentNode.Descendants("li")
        .Where(node => !node.GetAttributeValue("class", "").Contains("tocsection"))
        .ToList();

    List<string> wikiLinks = new();

    foreach (var node in programmerLinkNodes)
    {
        if (node.FirstChild.Attributes.Count > 0)
        {
            wikiLinks.Add(node.FirstChild.Attributes[0].Value);
        }
    }

    return wikiLinks;
}
