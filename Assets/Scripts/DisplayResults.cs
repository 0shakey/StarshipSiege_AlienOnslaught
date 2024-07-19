using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayResults : MonoBehaviour
{
    public static int Kills;
    public static int Waves;
    public TMP_Text displayText;

    public void ShowResults()
    {
        displayText.text = "Kills:" + Kills.ToString() + "\nWaves:" + Waves.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowResults();
    }
}
