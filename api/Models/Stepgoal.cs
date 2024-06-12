using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    public class Stepgoal
    {
        public int ID { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
       
       //default of proprty datetime is today's date
        public DateTime Date { get; set; } = DateTime.Today;

        public int Progress { get; set; } 

        public bool Achieved { get; set; }
    }
}