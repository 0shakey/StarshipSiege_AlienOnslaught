using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public static int money;
    public float armor = 10.0f;
    public Image image;
    public float remainingTime;
    public float totalTime = 1.5f;

    private void Start()
    {
        remainingTime = totalTime;
    }

    private void Update()
    {
        DamageIndicator();
    }
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
        image.color = new Color(214f / 255f, 0f / 255f, 0f / 255f, 140f / 255f); // 140/255 is approximately 0.55
    }

    public override void Die()
    {
        Debug.Log("Player Death");
        Debug.Log("You Lost");

        money = 0;
       
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);         
    }

    public void DamageIndicator()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = totalTime;
            image.color = new Color(214, 0, 0, 0);
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
