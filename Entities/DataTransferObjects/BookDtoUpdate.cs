﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class BookDtoUpdate : BookDtoManipulation
    {
        [Required]
        public int ID { get; init; }
    }
}
