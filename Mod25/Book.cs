﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mod25
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }

        // Внешний ключ
        public int? UserId { get; set; }
        // Навигационное свойство
        public User User { get; set; }
    }
}