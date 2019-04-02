namespace REZCores
{
    public class VendorModel : CommonModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GSTIN { get; set; }
        public bool IsActive { get; set; }
        public int TaxClassId { get; set; }
    }

    public class VendorCatalogModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public int ItemCode { get; set; }
        public int FixedorVariable { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
    }
}
