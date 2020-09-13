using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TodoTracker
{
    public class FileHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TodoList todoList = null;

        private static string path = "Assets/Resources/todo.txt";

        private static List<string> todos = new List<string>();

        public static void AddTodo(string todo)
        {
            todos.Add(todo);
        }

        [MenuItem("Tools/Write File")]
        public static void WriteFile()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (string todo in todos) writer.WriteLine(todo);
            writer.Close();
        }

        [MenuItem("Tools/Read File")]
        public static void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            todos.Clear();
            string[] list = reader.ReadToEnd().Split('\n');
            foreach (string todo in list) todos.Add(todo);
            reader.Close();
        }

        private void Start()
        {
            ReadFile();
            todoList.Initialize(todos.ToArray());
        }

        private void OnApplicationQuit()
        {
            WriteFile();
        }
    }
}
