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
        // [SerializeField] private TMP_InputField titleField = null;
        [SerializeField] private TMP_Dropdown monthDropdown = null;
        [SerializeField] private TMP_InputField dayField = null;
        [SerializeField] private TMP_InputField yearField = null;

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
            if (yearField.text == "" || dayField.text == "") return false;

            int year = int.Parse(yearField.text);
            int month = monthDropdown.value + 1;
            int day = int.Parse(dayField.text);

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
            
        }

        private bool IsValidDate(int month, int day, int year)
        {
            return false;
        }
    }
}
