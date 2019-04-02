namespace REZCores
{
    public  class StoreModel: CommonModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int MasterStoreId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Manager { get; set; }
        public bool IsActive { get; set; }    

    }
}
