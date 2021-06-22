namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTilte { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "xml")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifieldBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
    }
}
