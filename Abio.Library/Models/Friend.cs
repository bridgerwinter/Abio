﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.Models;

public partial class Friend
{
    public Guid UserId { get; set; }

    public Guid? FriendsWith { get; set; }

    public virtual User FriendsWithNavigation { get; set; }
}