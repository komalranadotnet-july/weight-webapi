using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeightWebApi.Models
{
    public class Weight
    {
        [Key]
        public int id { get; set; }
        public int weight { get; set; }
        public DateTime date { get; set; }
        public double bodyfat { get; set; }
    }
}