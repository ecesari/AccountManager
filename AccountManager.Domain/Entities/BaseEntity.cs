﻿using System.ComponentModel.DataAnnotations;

namespace AccountManager.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}