namespace MobiFix.Data
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int? Brandid { get; set; }
        public string? Model { get; set; }
        public string Color { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public string? Issue { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public decimal? NetRevenue { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Unpaid { get; set; }
        public int CustomerId { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Date { get; set; }
        public int FixStatusId { get; set; }
        public int PaidStatusId { get; set; }
        public string? Notes { get; set; }
        public bool isdeleted { get; set; } = false;
        public virtual Brand? Brand { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual PaidStatus? PaidStatus { get; set; }
        public virtual FixStatus? Status { get; set; }
    }
}
