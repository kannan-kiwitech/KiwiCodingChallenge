using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallenge1.Models
{
    public class Property
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }
        public double Latilatitude { get; set; }
        public double Longitude { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

    }
}