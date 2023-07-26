﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("UserCitiesLeaders", Schema = "Player")]
    public partial class UserCitiesLeader
    {
        [Key]
        public Guid UserCityLeadersId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HiredLeaderId { get; set; }
        public Guid? CityId { get; set; }

        [ForeignKey("CityId")]
        [InverseProperty("UserCitiesLeaders")]
        public virtual UserCity City { get; set; }
        [ForeignKey("HiredLeaderId")]
        [InverseProperty("UserCitiesLeaders")]
        public virtual HiredLeader HiredLeader { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserCitiesLeaders")]
        public virtual User User { get; set; }
    }
}
