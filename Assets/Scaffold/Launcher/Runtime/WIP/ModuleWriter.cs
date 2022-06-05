using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEditor;
using Newtonsoft.Json;
using Scaffold.Launcher;
using Scaffold.Launcher.Utilities;

namespace Scaffold.Launcher.ModuleHandler
{
    public class ModuleWriter
    {
        public ModuleWriter(ModuleReader reader, string path)
        {
            _reader = reader;
            _moduleFilePath = path;
        }

        private ModuleReader _reader;
        private string _moduleFilePath;

        public void Write(PackagePath[] paths)
        {
            var file = _reader.ReadFile();
            foreach(var entry in paths)
            {
                file.Add(entry.Name, entry.Path);
            }

            string json = JsonConvert.SerializeObject(file, Formatting.Indented);
            File.WriteAllText(_moduleFilePath, json);
        }
    }
}

