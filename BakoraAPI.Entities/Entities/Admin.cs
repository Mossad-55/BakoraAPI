﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakoraAPI.Entities.Entities;

public class Admin
{
    [Key]
    public Guid? UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
}
