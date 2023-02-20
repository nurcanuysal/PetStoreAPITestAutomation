using System;
namespace PetStoreAPI.Models
{
    public partial class Pet
    {
        public long Id { get; set; }
        public Category? Category { get; set; }
        public string? Name { get; set; }
        public string[]? PhotoUrls { get; set; }
        public Category[]? Tags { get; set; }
        public string? Status { get; set; }
    }

    public partial class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public enum PetStatus
    {
        available,
        pending,
        sold
    }
}



