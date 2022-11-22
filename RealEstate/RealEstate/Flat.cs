namespace RealEstate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flat")]
    public partial class Flat
    {
        [Key]
        public int FlatSK { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Vendor { get; set; }

        [Required]
        [StringLength(4)]
        public string Side { get; set; }

        public byte District { get; set; }

        public bool Elevator { get; set; }

        public decimal NumberOfRooms { get; set; }

        public short FloorArea { get; set; }

        public decimal Price { get; set; }
    }
}
