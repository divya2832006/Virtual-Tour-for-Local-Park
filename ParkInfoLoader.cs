using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class ParkInfo
{
    public string rose_garden;
    public string play_zone;
}

public class ParkInfoLoader : MonoBehaviour
{
    [Tooltip("URL to park_info.json, e.g. http://localhost:8080/park_info.json")]
    public string jsonUrl = "http://localhost:8080/park_info.json";

    [Tooltip("Assign the TMP text that should show the rose_garden message")]
    public TextMeshProUGUI infoText;

    IEnumerator Start()
    {
        // Basic request
        using (UnityWebRequest www = UnityWebRequest.Get(jsonUrl))
        {
            yield return www.SendWebRequest();

            // Unity 2020.1+ pattern
            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching JSON: " + www.error);
                yield break;
            }

            string json = www.downloadHandler.text;
            Debug.Log("Received JSON: " + json);

            // Parse with JsonUtility into our ParkInfo class
            ParkInfo info = JsonUtility.FromJson<ParkInfo>(json);

            if (info != null)
            {
                if (infoText != null)
                {
                    // Example: show the rose_garden message
                    infoText.text = info.rose_garden;
                }
                else
                {
                    Debug.Log("rose_garden: " + info.rose_garden);
                }
            }
            else
            {
                Debug.LogError("Failed to parse JSON into ParkInfo.");
            }
        }
    }
}
