namespace Logic.Interfaces
{
    public  interface IProductLinkDAL
    {
        public bool AddProductLinkToProduct(int productID, string productLinkURL);
        public bool EditProductLinkFromProduct(int productID, int productLinkID, string productLinkURL);
    }
}
