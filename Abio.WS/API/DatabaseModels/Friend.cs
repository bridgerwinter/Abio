﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Friends", Schema = "Player")]
    public partial class Friend
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid? FriendsWith { get; set; }

        [ForeignKey("FriendsWith")]
        [InverseProperty("Friends")]
        public virtual User FriendsWithNavigation { get; set; }
    }
}
