namespace MobiFix.Data
{
    public partial class FixStatus
    {
        public FixStatus()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public bool isdeleted { get; set; } = false;
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
