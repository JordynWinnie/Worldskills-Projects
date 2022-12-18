using System;
using System.Collections.Generic;

namespace KazanBackend
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public byte[] Name { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentType { get; set; } = null!;
    }
}
