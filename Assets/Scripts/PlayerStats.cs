using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public PlayerControls inputActions;
    public float health = 10.0f;
    public float armor = 10.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.gameplay.Enable();
        inputActions.gameplay.Test.started += value => Test(value);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }
}
