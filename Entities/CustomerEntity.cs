﻿using System.ComponentModel.DataAnnotations;

namespace Data_Bas123.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;

}