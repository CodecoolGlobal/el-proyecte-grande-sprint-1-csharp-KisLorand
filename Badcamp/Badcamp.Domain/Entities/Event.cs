﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Badcamp.Domain.Entities
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Artist Artist { get; set; } = new Artist();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Upvote { get; set; } = 0;

    }
}
