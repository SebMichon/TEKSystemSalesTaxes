namespace SalesTaxes.BusinessLayer
{
    public interface IProduct
    {
        bool IsImported { get; }
        string ProductName { get; set; }

        decimal ImportTaxRate();
        decimal SalesTaxRate();
    }
}