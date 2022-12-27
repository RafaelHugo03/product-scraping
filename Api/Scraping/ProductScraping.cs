using Api.Entities;
using Api.Repositories;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Api.Scraping
{
    public class ProductScraping
    {
        private readonly IProductRepository productRepository;

        public ProductScraping(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteScraping()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://world.openfoodfacts.org/");

            var urls = driver.FindElements(By.ClassName("list_product_a"))
            .Select(u => u.GetAttribute("href"))
            .ToList();

            if(urls.Count >= 100){
                var count = urls.Count - 100;
                urls.RemoveRange(100, count);
            }

            foreach(var url in urls)
            {
                try{
                    var product = new Product{
                        Code = null, 
                        BarCode = null, 
                        Imported_at = DateTime.Now, 
                        Status =  Api.enums.Status.imported, 
                        Packaging = null,
                        Url =  null, 
                        ProductName = null, 
                        Quantity = null, 
                        Categories = null, 
                        Brands = null, 
                        ImageUrl = null
                    };

                    driver.Navigate().GoToUrl(url);

                    product.Url = driver.Url;
                    if(IsElementPresent(By.Id("barcode"), driver)){
                        product.Code = long.Parse(driver.FindElement(By.Id("barcode")).Text);
                    }
                    if(IsElementPresent(By.Id("barcode_paragraph"), driver)){
                        var barCode = driver.FindElement(By.Id("barcode_paragraph")).Text;
                        product.BarCode = barCode.Remove(0, barCode.IndexOf(" ")).Trim();
                    }
                    if(IsElementPresent(By.Id("field_generic_name_value"), driver)){
                        product.ProductName = driver.FindElement(By.Id("field_generic_name_value")).Text;
                    }
                    if(IsElementPresent(By.Id("field_quantity_value"), driver)){
                        product.Quantity = driver.FindElement(By.Id("field_quantity_value")).Text;
                    }
                    if(IsElementPresent(By.Id("field_packaging_value"), driver)){
                        product.Packaging = driver.FindElement(By.Id("field_packaging_value")).Text;
                    }
                    if(IsElementPresent(By.Id("field_brands_value"), driver)){
                        product.Brands = driver.FindElement(By.Id("field_brands_value")).Text;
                    }
                    if(IsElementPresent(By.Id("field_categories_value"), driver)){
                        product.Categories = driver.FindElement(By.Id("field_categories_value")).Text;     
                    }

                    if(product.Code.ToString().Length <= 8) {
                        product.ImageUrl = $"https://static.openfoodfacts.org/images/products/{product.Code}/front_fr.3.400.jpg";
                    }
                    else if(product.Code == null) {
                        product.ImageUrl = null;
                    }   
                    else {
                        product.ImageUrl = $"https://static.openfoodfacts.org/images/products/{FormatString(product.Code.ToString())}/front_fr.3.400.jpg";
                    }
                    await productRepository.AddAsync(product);
                }
                catch(DbUpdateException ex){
                }
            }

        }

        private string FormatString(string value){
            var endLenght = value.Remove(0,9);
            return $"{value.Substring(0,3)}/{value.Substring(3,3)}/{value.Substring(6,3)}/{value.Substring(9, endLenght.Length)}";
        }
        private bool IsElementPresent(By by, ChromeDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}