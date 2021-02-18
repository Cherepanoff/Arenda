using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HowToFileDisplay.Services
{
    public class FileManager
    {
        private IHostingEnvironment _env;
        private List<File> Files;
        private int Id;

        private readonly List<(int Width, int Height)> imgSizes = new List<(int, int)>
            {
                (480, 270),
                (640, 360),
                (1280, 720),
                (1920, 1080)
            };

        public FileManager(IHostingEnvironment env)
        {
            _env = env;
            Files = new List<File>();
        }

        public File GetFile(int id) => Files.FirstOrDefault(x => x.Id == id);

        public File GetFile(int id, int width) => Files.FirstOrDefault(x => x.Id == id && x.Width == width);

        public IEnumerable<File> GetFiles() => Files;

        public IEnumerable<int> GetOptimizedFiles() =>
            Files
            .Where(x => x.Width > 0)
            .Select(x => x.Id)
            .Distinct();     
    }

    public class File
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public string RelativePath { get; set; }
        public string GlobalPath { get; set; }
    }
}
