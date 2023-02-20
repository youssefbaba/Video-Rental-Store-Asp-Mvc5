using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VideoRentalStore.Models;

namespace VideoRentalStore.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
        public string Title
        {
            get
            {
                if (Id == 0)
                {
                    return "New Customer";
                }
                return "Edit Customer";
            }

        }

        public MovieFormViewModel()
        {
            Id = 0;

        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}
