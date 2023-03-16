namespace MobiFix.Data
{
    public partial class Brand
    {
        public Brand()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool isdeleted { get; set; } = false;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
