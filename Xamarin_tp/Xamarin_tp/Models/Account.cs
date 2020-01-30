using System;
using SQLite; 
using System.Collections.Generic;
using System.Text;

namespace Xamarin_tp.Models
{
    [Table("Students")]
    public class Message
    {

        [PrimaryKey, AutoIncrement , Column("_id")]
        public int ID { get; set; }
        public int id { get; set; }
        public int student_id { get; set; }
        public double gps_lat { get; set; }
        public double gps_long { get; set; }
        public string student_message { get; set; }
    }
    
}
