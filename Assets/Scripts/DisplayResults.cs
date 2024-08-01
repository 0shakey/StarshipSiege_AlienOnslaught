using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayResults : MonoBehaviour
{
    // Static variables are variables that are shared between every instance of the class. 
    // Variables are always the same for each instance of the class.
    // Static variables can be referenced without a reference to an instance of the class 
    public static int Kills;
    public static int Waves;

    public TMP_Text displayText;

    public void ShowResults()
    {
        displayText.text = "Kills:" + Kills.ToString() + "\nWaves:" + Waves.ToString();

        //Resets kills and waves after displaying the game results
        Kills = 0;
        Waves = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowResults();
    }
}
