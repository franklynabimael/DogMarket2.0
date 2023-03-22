﻿namespace Dog_Market_2._0.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> CategoryProduct { get; set; }
}