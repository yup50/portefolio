using UnityEngine;
using TMPro;
using System.Collections;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    void Start()
    {
        StartCoroutine(UpdateClock());
    }

    IEnumerator UpdateClock()
    {
        while (true)
        {
            System.DateTime currentTime = System.DateTime.Now;
            clockText.text = currentTime.ToString("HH:mm:ss");
            yield return new WaitForSeconds(1); // Update elke seconde
        }
    }
}
