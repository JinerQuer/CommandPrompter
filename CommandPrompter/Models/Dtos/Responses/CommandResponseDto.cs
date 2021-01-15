﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Models.Dtos.Responses
{
    public class CommandResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlateformId { get; set; }
        public string Template { get; set; }
        public string Version { get; set; }
        public string CreatorId { get; set; }
    }
}
