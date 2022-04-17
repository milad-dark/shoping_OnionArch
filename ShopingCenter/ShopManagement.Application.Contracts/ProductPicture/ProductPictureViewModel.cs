namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        private long Id { get; set; }
        public string Product { get; private set; }
        public string Picture { get; private set; }
        public string CreationDate { get; set; }
    }
}
