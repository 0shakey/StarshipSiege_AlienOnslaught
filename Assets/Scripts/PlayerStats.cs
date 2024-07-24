using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public float armor = 10.0f;

    public override void OnEnable()
    {
        base.OnEnable();
        inputActions.gameplay.SceneChanger.started += SceneChanger;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        inputActions.gameplay.SceneChanger.started -= SceneChanger;
    }   

    public override void LoseHealth()
    {     
        if (armor > 0)
        {
            armor -= 5.0f;
        }
        else
        {
            base.LoseHealth();
        }
    }

    public override void Die()
    {
        Debug.Log("Player Death");
        Debug.Log("You Lost");

        DisplayResults.Kills = 5;
        DisplayResults.Waves = 3;

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);        
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
