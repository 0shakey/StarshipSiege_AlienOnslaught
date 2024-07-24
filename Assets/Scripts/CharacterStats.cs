using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public PlayerControls inputActions;
    public float health = 10.0f;

    public virtual void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.gameplay.Enable();
        inputActions.gameplay.Test.started += Test;
    }

    public virtual void OnDisable()
    {
        inputActions.gameplay.Test.started -= Test;
    }

    public virtual void Test(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (value.started)
        {
            LoseHealth();                  
        }
    }

    public virtual void LoseHealth()
    {
        health -= 5.0f;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {     
        Debug.Log("Alien Death");     
        Destroy(gameObject);
    }

    //gmaeObject is referring to the game object that this script is attached to
    //other is referring to anything that touches the game object that the script is attached to
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            LoseHealth();
        }
    }   
}
