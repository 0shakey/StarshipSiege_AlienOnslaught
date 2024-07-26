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

    private void OnEnable()
    {
        CharacterStats.onCharacterDied.AddListener(CharacterDied);
    }

    private void OnDisable()
    {
        CharacterStats.onCharacterDied.RemoveListener(CharacterDied);
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
                }
            }
        }
    }
    
    public void OnWaveEnded() 
    {
        currentRound = 0;
        waveStarted = false;
    }

    public void CharacterDied()
    {
        if (currentRound == maxRounds)
        {
            //Callback happens before destroyed so we check for 1 enemy left
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
            {
                OnWaveEnded();
            }
        }
    }
}
