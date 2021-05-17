using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UserInfoDTO
    {
        [Required]
        public int meanMark { get; set; }
        [Required]
        public int countOfFavourites { get; set; }
    }
}
