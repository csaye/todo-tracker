using System;
using TMPro;
using UnityEngine;

namespace TodoTracker
{
    public class TodoItem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI labelField = null;

        private string title;
        private DateTime date;

        public void Initialize(string title, DateTime date)
        {
            this.title = title;
            this.date = date;
            labelField.text = $"{title} due {date.ToShortDateString()}";
        }

        public void DestroyItem()
        {
            FileHandler.RemoveTodo($"{title}\\{date.ToShortDateString()}");
            Destroy(gameObject);
        }
    }
}
