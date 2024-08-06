﻿using System.Text.Json.Serialization;

namespace APITest.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore] public ICollection<Product> Products { get; set; }
}