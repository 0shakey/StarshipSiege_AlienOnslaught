using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public PlayerStats playerStats;

    public bool justAttacked;

    public float timeUntilNextAttack = 3.0f;
    public float remainingTime;
    public float attackDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        playerStats = player.GetComponent<PlayerStats>();
        remainingTime = timeUntilNextAttack;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (justAttacked == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                justAttacked = false;
                remainingTime = timeUntilNextAttack;
            }
        }

        if (CanEnemyAttack())
        {
            Attack();
        }
    }

    //Check distance and make sure justAttacked is false through timer
    public bool CanEnemyAttack()
    {
        if (attackDistance >= Vector3.Distance(transform.position, player.transform.position))
        {
            if (!justAttacked)
            {
                return true;
            }
        }
        return false;
    }

    //Use player reference to do damage
    public void Attack()
    {
        playerStats.LoseHealth();
        justAttacked = true;
    }
}
