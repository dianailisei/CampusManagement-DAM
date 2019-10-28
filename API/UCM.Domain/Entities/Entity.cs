using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UCM.Domain.Entities
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public bool IsAvailable { get; private set; } = true;

        [Required]
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;

        public void Delete()
        {
            IsAvailable = false;
        }
    }
}
