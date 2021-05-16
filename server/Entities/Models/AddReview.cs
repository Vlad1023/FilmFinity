using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class AddReview
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public ReviewContentType ContentType { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(150)]
        public string ReviewTitle { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength(2000)]
        public string ReviewContent { get; set; }
        public DateTime PublishTime { get; set; }
        [Required]
        [Range(0.0, 5.0)]
        public float DirectingRating { get; set; }
        [Required]
        [Range(0.0, 5.0)]
        public float PlotRating { get; set; }
        [Required]
        [Range(0.0, 5.0)]
        public float SpectacleRating { get; set; }
        [Required]
        [Range(0.0, 5.0)]
        public float ActorsRating { get; set; }
    }
}

