﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreBestPractices.API.DTO.Category
{
    public class CategoryDto
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
