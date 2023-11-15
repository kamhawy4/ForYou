﻿namespace ForYou.Domain.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
    }
}
