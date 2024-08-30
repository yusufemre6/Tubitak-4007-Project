using System;
namespace Tubitak_4007_Project.Models
{
	public static class ProductService
	{
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "İskambil Kartları", Price=100,Description="Minecraft lisanslı iskambil kağıtları ile eğlenceyi yakalayın",amount=0,imgPath="minecraft_p1.webp" },
            new Product { Id = 2, Name = "Hediye Kartı", Price=70,Description="Minecraft hediye kartı ile sevdiklerinizi mutlu edin",amount=0,imgPath="minecraft_p2.webp" },
            new Product { Id = 3, Name = "Minecraft Karakter", Price=150,Description="Minecraft lisanslı karakter maskotu ile kendinizi gösterin",amount=0,imgPath="minecraft_p3.webp" },
            new Product { Id = 4, Name = "LEGO Minecraft", Price=250,Description="Minecraft lego ile dünyanızı gerçeğe dökün",amount=0,imgPath="minecraft_p4.jpg" },
            new Product { Id = 5, Name = "PS4 Minecraft", Price=500,Description="Playstation 4 minecraft ile daha akıcı oyun fırsatı",amount=0,imgPath="minecraft_p5.jpg" },
            new Product { Id = 6, Name = "Kılıç", Price=100,Description="Minecraft lisanslı kılıç ile gerçek bit oyuncu olduğunuzu gösterin",amount=0,imgPath="minecraft_p6.webp" },
        };

        
        public static List<Product> GetAllProducts()
        {
            return products;
        }
	}
}

