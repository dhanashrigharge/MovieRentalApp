using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte DiscountRate { get; set; }

        public byte DurationInMonths { get; set; }

        public short SignupFee { get; set; }
    }
}