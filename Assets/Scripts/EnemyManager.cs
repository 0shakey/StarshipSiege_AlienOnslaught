using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: 
//Spawn points
//Enemy moves to player
//Each wave, enemies spawn in rounds per wave. 3 rounds in a wave
//Each round spawns after 10 seconds

public class EnemyManager : MonoBehaviour
{
    public List<Transform> spawnPointList;
    public GameObject baseAlien;
    public float roundRemainingTime;
    public float roundTotalTime = 10.0f;
    public float waveRemainingTime;
    public float waveTotalTime = 10.0f;
    public bool waveStarted;
    public int maxRounds = 3;
    public int currentRound;

    // Start is called before the first frame update
    void Start()
    {
        roundRemainingTime = roundTotalTime;
        waveRemainingTime = waveTotalTime;
    }

    // Update is called once per frame
    void Update()
    {
        OnWaveStarted();
        AlienSpawner();       
    }

    public void OnWaveStarted()
    {
        if (!waveStarted)
        {
            if (waveRemainingTime > 0)
            {
                waveRemainingTime -= Time.deltaTime;
            }
            else
            {
                waveStarted = true;
                waveRemainingTime = waveTotalTime;
            }
        }
    }

    public void AlienSpawner()
    {   
        if (waveStarted) 
        {
            if (currentRound < maxRounds)
            {
                if (roundRemainingTime > 0)
                {
                    roundRemainingTime -= Time.deltaTime;
                }
                else
                {
                    int index = UnityEngine.Random.Range(0, spawnPointList.Count);
                    Transform spawnPoint = spawnPointList[index];
                    Instantiate(baseAlien, new Vector3(spawnPoint.position.x + Random.Range(-2, 2), spawnPoint.position.y, spawnPoint.position.z + Random.Range(-2, 2)), spawnPoint.rotation);
                    roundRemainingTime = roundTotalTime;
                    currentRound++;

                    if (currentRound == maxRounds)
                    {
                        OnWaveEnded();
                    }
                }
            }
        }
    }
    
    public void OnWaveEnded() 
    {
        currentRound = 0;
        waveStarted = false;
    }
}
