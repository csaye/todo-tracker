using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TodoTracker
{
    public class FileHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TodoList todoList = null;

        private static string path;

        private static List<string> todos = new List<string>();

        public static void AddTodo(string todo)
        {
            todos.Add(todo);
        }

        public static void RemoveTodo(string todo)
        {
            todos.Remove(todo);
        }

        private static void WriteFile()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (string todo in todos) writer.WriteLine(todo);
            writer.Close();
        }

        private static void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            todos.Clear();
            string content = reader.ReadToEnd();
            string[] list = content.Split('\n');
            foreach (string todo in list)
            {
                if (!string.IsNullOrWhiteSpace(todo)) todos.Add(todo);
            }
            reader.Close();
        }
        
        private void GetPath()
        {
            path = $"{Application.persistentDataPath}/todo.txt";
            if (!File.Exists(path)) File.WriteAllText(path, "");
        }

        private void Start()
        {
            GetPath();
            ReadFile();
            todoList.Initialize(todos.ToArray());
        }

        private void OnApplicationQuit()
        {
            WriteFile();
        }
    }
}
