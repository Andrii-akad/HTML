namespace Server01.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chat")]
    public partial class Chat
    {
        public int Id { get; set; }

        public string Participants { get; set; }

        public int? MessageId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ImageId { get; set; }

        public virtual ChatImages ChatImages { get; set; }

        public virtual Message Message { get; set; }
    }
}
