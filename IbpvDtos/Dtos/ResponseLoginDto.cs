using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos
{
    public class RespondeLoginDto
    {
        public bool status {get; set;}        
        public string? jwtToken{get; set;}
    }
}