namespace PeopleSearch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Interests { get; set; }

        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }
    }
}
