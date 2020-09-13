﻿using System;
using UnityEngine;

namespace TodoTracker
{
    public class TodoList : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject todoItemPrefab = null;
        [SerializeField] private Transform contentTransform = null;

        public void Initialize(string[] todos)
        {
            foreach (string todo in todos)
            {
                string title;
                DateTime date;

                try
                {
                    string[] titleDate = todo.Split('\\');
                    title = titleDate[0];
                    string[] dateDigits = titleDate[1].Split('/');
                    
                    int year = int.Parse(dateDigits[0]);
                    int month = int.Parse(dateDigits[1]);
                    int day = int.Parse(dateDigits[2]);
                    date = new DateTime(year, month, day);
                }
                catch
                {
                    Debug.LogError($"Invalid todo {todo}!");
                    continue;
                }

                CreateTodoItem(title, date);
            }
        }

        public void CreateTodoItem(string title, DateTime date)
        {
            GameObject todoObj = Instantiate(todoItemPrefab, transform.position, Quaternion.identity, contentTransform);
            todoObj.GetComponent<TodoItem>().Initialize(title, date);
        }
    }
}
