﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class UserCity
{
    public Guid CityId { get; set; }

    public Guid? UserId { get; set; }

    public int? XCoord { get; set; }

    public int? YCoord { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<UserCitiesLeader> UserCitiesLeaders { get; } = new List<UserCitiesLeader>();
}