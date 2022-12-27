using Api.Repositories;
using Api.Scraping;
using Quartz;

namespace Api.Job
{
    public class ScrapingJob : IJob
    {
        private readonly IProductRepository productRepository;

        public ScrapingJob(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Iniciando scraping");
            var scraping = new ProductScraping(productRepository);
            await scraping.ExecuteScraping();
        }
    }
}