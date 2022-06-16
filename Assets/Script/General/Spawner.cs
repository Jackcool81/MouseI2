using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Spawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public int count = 0;
    public int roundCount = 0;

    public GameObject[] walls;
    public GameObject[] turrets;
    public GameObject player;

    public TMP_Text counterText;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f; //time before searches

    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        AkSoundEngine.PostEvent("siren", gameObject); //must include specfic name of even

    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                // Begin a new round give points and stuff
                WaveCompleted();

                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Current Wave" + waves[nextWave].name);
        int hell = nextWave + roundCount + 1;
        counterText.text = hell.ToString();

        //respawn turrets and walls if they are dead
        for (int u = 0; u < walls.Length; u++)
        {
            if (walls[u].activeSelf == false)
            {
                walls[u].SetActive(true);
                turrets[u].SetActive(true);
            }
            if (count == 0)
            {
                walls[u].GetComponent<Wall>().lifeMax = walls[u].GetComponent<Wall>().lifeMax + 25f;
            }
            walls[u].GetComponent<Wall>().life = walls[u].GetComponent<Wall>().lifeMax;

        }

        //regen HP
        if (count == 0) //checks if the game has been won S
        {
            player.GetComponent<CharacterController2D>().lifeMax = player.GetComponent<CharacterController2D>().lifeMax + 1f;
        }
        player.GetComponent<CharacterController2D>().life = player.GetComponent<CharacterController2D>().lifeMax;

        state = SpawnState.SPAWNING;

        int x = (_wave.count + count) / 2;


        for (int i = 0; i < x; i++)
        {
            SpawnEnemyRight(_wave.enemy);
            SpawnEnemyLeft(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate); // _wave.delay
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemyRight(Transform _enemy)
    {
        //spawn enemy

        Transform sp = spawnPoints[1]; //need at least one spawn point in array
        Instantiate(_enemy, sp.position, sp.rotation);
    }

    void SpawnEnemyLeft(Transform _enemy)
    {
        //spawn enemy

        Transform sp = spawnPoints[0]; //need at least one spawn point in array
        Instantiate(_enemy, sp.position, sp.rotation);
    }

    void WaveCompleted()
    {
        Debug.Log("WAVE COMPLETED");

        state = SpawnState.COUNTING;
        AkSoundEngine.PostEvent("siren", gameObject); //must include specfic name of even
        waveCountdown = timeBetweenWaves;
        Debug.Log("this is the waves length" + waves.Length);


        //Game State Complete
        if (nextWave + 1 > waves.Length - 1)
        {
            //add stat multiplier 
            //game done screen
            nextWave = waves.Length - 1;
            count = count + 2;
            roundCount++;
            Debug.Log("Completed All Waves looping");
        }
        else
        {
            nextWave++;

        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f; //reset search countdown
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
}
