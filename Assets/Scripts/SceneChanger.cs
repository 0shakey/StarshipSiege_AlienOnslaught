using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {    
        SceneManager.LoadScene(sceneIndex);
    }
}
    

//Start scene to game scene (use scene changer script with timer set to 0)
//Game scene to end scene with Y button
//Use scene changer script with timer of 10 seconds to go from end scene to start scene
