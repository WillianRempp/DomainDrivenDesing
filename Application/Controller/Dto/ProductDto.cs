﻿using System.ComponentModel.DataAnnotations;

namespace Application.Controller.Dto;

public class ProductDto
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}