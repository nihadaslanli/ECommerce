﻿namespace ECommerce.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; internal set; }
}

public class ProductCreateDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
}
public class ProductDeleteDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

}
