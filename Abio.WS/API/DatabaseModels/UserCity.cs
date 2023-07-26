using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("UserCities", Schema = "Player")]
    public partial class UserCity
    {
        public UserCity()
        {
            UserCitiesLeaders = new HashSet<UserCitiesLeader>();
        }

        [Key]
        public Guid CityId { get; set; }
        public Guid? UserId { get; set; }
        [Column("XCoord")]
        public int? Xcoord { get; set; }
        [Column("YCoord")]
        public int? Ycoord { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserCities")]
        public virtual User User { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<UserCitiesLeader> UserCitiesLeaders { get; set; }
    }
}
