using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TodoTracker
{
    [RequireComponent(typeof(Button))]
    public class SubmitButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_InputField titleInput = null;
        [SerializeField] private TMP_Dropdown monthDropdown = null;
        [SerializeField] private TMP_InputField dayInput = null;
        [SerializeField] private TMP_InputField yearInput = null;
        [SerializeField] private TodoList todoList = null;

        private DateTime date;

        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();
        }

        public void UpdateActive()
        {
            button.interactable = TryGetDate();
        }

        private bool TryGetDate()
        {
            if (yearInput.text == "" || dayInput.text == "") return false;

            int year = int.Parse(yearInput.text);
            int month = monthDropdown.value + 1;
            int day = int.Parse(dayInput.text);

            try
            {
                date = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void OnClick()
        {
            todoList.CreateTodoItem(titleInput.text, date, true);
        }

        private bool IsValidDate(int month, int day, int year)
        {
            return false;
        }
    }
}
