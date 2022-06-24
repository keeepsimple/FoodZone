using System;

namespace FoodZone.Models.BaseEntities
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        DateTime InsertedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
