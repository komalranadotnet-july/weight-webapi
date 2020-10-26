using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeightWebApi.Models
{
    public class Community
    {
        [Key]
        public int id { get; set; }
        public string commenter { get; set; }
        public string comment { get; set; }
    }
}