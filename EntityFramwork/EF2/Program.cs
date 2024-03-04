using EF2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            using (var context = new EFContext())
            {
                foreach (var item in context.Articles.FirstOrDefault().ArticleTags)
                {
                    await Console.Out.WriteLineAsync(item.ArticleTagId + "");
                }
            }
        }
    }
}
