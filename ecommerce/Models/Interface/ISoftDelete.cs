namespace ecommerce.Models.Interface
{
    public interface ISoftDelete
    {
        public DateTime LastModified { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
