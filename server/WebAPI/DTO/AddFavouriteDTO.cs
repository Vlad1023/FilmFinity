using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Entities.Models;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class AddFavouriteDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public ContentType ContentType { get; set; }
        [Required]
        public int ContentId { get; set; }
    }
}
