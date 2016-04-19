///By: Salvatore Stone Mele
///4/19/16


namespace PeopleSearch
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class that describes the Person object for the dataBase. 
    /// </summary>
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
        [StringLength(300)]
        public string ImagePath { get; set; }
    }
}
