using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private PlayerControls inputActions;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public bool isFiring;
    public bool isAutomatic;
    public float remainingTime = 1.0f;
    public float totalTime = 1.0f;

    public void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.gameplay.Enable();
        inputActions.gameplay.fire.started += Shoot;
        inputActions.gameplay.fire.canceled += Shoot;
    }
   
    public void OnDisable()
    {
        inputActions.gameplay.fire.started -= Shoot;
        inputActions.gameplay.fire.canceled -= Shoot;
    }

    public void Update()
    {
        if (isFiring && isAutomatic)
        {
            if (remainingTime > 0.0f)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                remainingTime = totalTime;
            }
        }
    }

    private void Shoot(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (!isAutomatic)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
            isFiring = true;            
        }

        if (value.canceled)
        {
            isFiring = false;
        }
    }
}
