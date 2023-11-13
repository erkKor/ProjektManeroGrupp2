﻿using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.ViewModels
{
    public class ReviewViewModel
    {


        [Display(Name = "Rating")]
        public int Rating { get; set; }


        [Display(Name = "Text")]
        public string Text { get; set; } = null!;

        public int ProductId { get; set; }

        public DateTime CreatedAt { get; set; }


        public static implicit operator ReviewEntity(ReviewViewModel review)
        {
            return new ReviewEntity
            {
                Text = review.Text,
                Rating = review.Rating,
                CreatedAt = DateTime.Now
            };
        }

    }
}
