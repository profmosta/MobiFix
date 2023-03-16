namespace MobiFix.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MobileNumber { get; set; }
        public string? Description { get; set; }
        public bool isdeleted { get; set; } = false;
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
