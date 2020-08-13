namespace SalesTaxes.BusinessLayer
{
    public interface ICart
    {
        int CartNo { get; set; }
        decimal GrandTotal { get; }
        decimal TotalSalesTaxes { get; }

        ICartItem AddCartItem(int quantity, string productName, decimal shelfPrice);
        string GenerateReceipt();
        void LogReceipt();
    }
}