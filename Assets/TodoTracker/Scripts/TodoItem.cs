using System;
using TMPro;
using UnityEngine;

namespace TodoTracker
{
    public class TodoItem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI labelField = null;

        public void Initialize(string title, DateTime date)
        {
            labelField.text = $"{title} : {date.ToShortDateString()}";
        }
    }
}
