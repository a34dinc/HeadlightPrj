﻿namespace HeadlightPrj.Data.Models
{
    public class HeadLight
    {
        public int HeadLightId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string ThumbNailImageURL { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
