using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Technology", Schema = "Lookup")]
    public partial class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        [Unicode(false)]
        public string TechnologyName { get; set; }
    }
}
