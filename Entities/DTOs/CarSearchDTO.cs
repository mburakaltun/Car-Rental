using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarSearchDTO : IDto
    {
        public int? colorId { get; set; }
        public int? brandId { get; set; }
    }
}
