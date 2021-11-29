﻿using System.Collections.Generic;

namespace ATIL.FeeCalculator.Models
{
    public class Category
    {
        public string Description { get; set; }
        public List<string> Tiltakstype { get; set; }
        public List<string> Bygningstype { get; set; }
        public List<Area> CategoryAreas { get; set; }
    }
}
