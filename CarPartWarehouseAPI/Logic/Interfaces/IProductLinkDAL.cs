namespace Logic.Interfaces
{
    public  interface IProductLinkDAL
    {
        // Create
        public bool AddProductLinkToProduct(int productID, string productLinkURL);
        
        // Update
        public bool EditProductLinkFromProduct(int productID, int productLinkID, string productLinkURL);
    }
}
