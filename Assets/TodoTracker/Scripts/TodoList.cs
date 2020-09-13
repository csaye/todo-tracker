using System;
using UnityEngine;

namespace TodoTracker
{
    public class TodoList : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject todoItemPrefab = null;

        public void CreateTodoItem(string title, DateTime date)
        {
            GameObject todoObj = Instantiate(todoItemPrefab, transform.position, Quaternion.identity, transform);
            todoObj.GetComponent<TodoItem>().Initialize(title, date);
        }
    }
}
