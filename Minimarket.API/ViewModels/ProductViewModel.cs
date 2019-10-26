
namespace Minimarket.API.ViewModels
{
    public class ProductViewModel
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryViewModel Category {get;set;}
    }
}