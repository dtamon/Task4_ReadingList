﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_ReadingList.Service.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
    }
}
