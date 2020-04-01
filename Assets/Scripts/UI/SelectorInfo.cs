using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SilverPhoenixGames.Escape.UI
{   
    [RequireComponent(typeof(TextMeshPro))]
    public class SelectorInfo : MonoBehaviour
    {
        private string currentText = "";
        public static TextMeshProUGUI selectionInfoText;

        private void Start()
        {
            selectionInfoText = GetComponent<TextMeshProUGUI>();
        }

        public static void ChangeText(string newText)
        {
            selectionInfoText.text = newText;
        }

        public static void ClearText()
        {
            selectionInfoText.text = "";
        }

    }
}
