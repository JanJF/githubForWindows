using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Model
{
    public class Seats
    {
        public int restaurant_ID { get; set; }
        public int seat_style { get; set; }
        public int seat_all { get; set; }
        public int seat_use { get; set; }
        public int seat_left { get; set; }
    }
}
