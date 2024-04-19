namespace Scryfall
{
    public record Scrapper
    {
        static void Main(string[] args)
        {

            try
            {
                // carregando o site
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://scryfall.com/card/otj/2/archangel-of-tithes");

                // capturando informações
                var titleNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"main\"]/div[1]/div/div[3]/h1/span[1]");
                var typeCardNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"main\"]/div[1]/div/div[3]/p[1]");
                var descriptionNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"main\"]/div[1]/div/div[3]/div[1]");

                {
                    // mostrando informações
                    Console.WriteLine(titleNode.InnerText.Trim());
                    Console.WriteLine(typeCardNode.InnerText.Trim());
                    Console.WriteLine(descriptionNode.InnerText.Trim());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
                throw;
            }
        }
    }
}
