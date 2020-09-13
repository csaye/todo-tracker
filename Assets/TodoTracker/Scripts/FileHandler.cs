using UnityEditor;
using UnityEngine;
using System.IO;

namespace TodoTracker
{
    public class FileHandler
    {
        private static string path = "Assets/Resources/todo.txt";

        [MenuItem("Tools/Write File")]
        public static void WriteFile()
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("testing");
            writer.Close();

            // TextAsset file = (TextAsset)Resources.Load("todo");
        }

        [MenuItem("Tools/Read File")]
        public static void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            Debug.Log(reader.ReadToEnd());
            reader.Close();
        }
    }
}
