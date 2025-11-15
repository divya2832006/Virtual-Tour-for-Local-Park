using UnityEngine;
using TMPro;

public class InfoBoard : MonoBehaviour
{
    [Tooltip("Assign the TextMeshProUGUI component that will display messages.")]
    public TextMeshProUGUI infoText;

    [TextArea]
    public string message = "Welcome to the park⛲...";

    void Start()
    {
        if (infoText != null) infoText.text = ""; // ensure hidden at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && infoText != null)
        {
            infoText.text = message;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && infoText != null)
        {
            infoText.text = "";
        }
    }
}
