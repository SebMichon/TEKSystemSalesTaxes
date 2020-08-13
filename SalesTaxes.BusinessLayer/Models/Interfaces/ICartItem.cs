namespace SalesTaxes.BusinessLayer
{
    public interface ICartItem
    {
        decimal ImportTaxes { get; }
        IProduct Product { get; }
        int Quantity { get; set; }
        decimal SalesTaxes { get; }
        decimal ShelfPrice { get; set; }
        decimal TotalBeforeTaxes { get; }
        decimal TotalOfTaxes { get; }
        decimal TotalWithTaxes { get; }

        string GenerateReceiptLine();
    }
}