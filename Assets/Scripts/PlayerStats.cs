using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public PlayerControls inputActions;
    public float health = 10.0f;
    public float armor = 10.0f;

    public void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.gameplay.Enable();
        inputActions.gameplay.Test.started += Test;
        inputActions.gameplay.SceneChanger.started += SceneChanger;
    }

    public void OnDisable()
    {
        inputActions.gameplay.Test.started -= Test;
        inputActions.gameplay.SceneChanger.started -= SceneChanger;
    }   

    private void Test(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (armor > 0)
            {
                armor -= 5.0f;
            }
            else
            {
                health -= 5.0f;

                if (health <= 0)
                {
                    Debug.Log("You Lost");

                    DisplayResults.Kills = 5;
                    DisplayResults.Waves = 3;

                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(2);                   
                }
            }
        }        
    }

    public void SceneChanger(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (value.started) 
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
}
