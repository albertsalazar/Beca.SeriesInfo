﻿namespace Beca.SeriesInfo.API.Models
{
    public class SeriesWithoutCapitulosDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
