using System;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalStore.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }


        [Range(1, 20)]
        public byte NumberInStock { get; set; }


        public GenreDto Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}