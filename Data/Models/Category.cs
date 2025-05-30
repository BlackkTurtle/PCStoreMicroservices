﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }= null!;
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = null!;
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
