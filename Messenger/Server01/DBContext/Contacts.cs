namespace Server01.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contacts
    {
        public int Id { get; set; }

        public int? OwnerId { get; set; }

        public int? ContactId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Account Account1 { get; set; }
    }
}
