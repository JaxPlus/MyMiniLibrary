﻿using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class BookDto : CommonDto
{
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public Models.Author Author { get; set; } = new();
    public int Volume { get; set; }
}