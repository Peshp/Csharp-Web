using MVC_Intro_Demo.Models;

namespace MVC_Intro_Demo.Seeding
{
    public static class DataProvider
    {
        public static IEnumerable<ProductViewModel> Products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheese",
                    Price = 10.20m,
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham",
                    Price = 5.50m,
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bread",
                    Price = 2.20m,
                },
            };
    }
}
