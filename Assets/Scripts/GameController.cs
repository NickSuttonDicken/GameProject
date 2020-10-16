using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawn;
    public GameObject transformPoints;
    public List<GameObject> spawnSpots = new List<GameObject>();
    public List<GameObject> waveOne = new List<GameObject>();
    public List<GameObject> waveTwo = new List<GameObject>();
    public List<GameObject> waveThree = new List<GameObject>();
    public GameObject hero;
    public HeroScript heroScript;
    public UIController UI;
    private int enemyCount = 0;
    private int waveCount = 0;
    private int gemCount = 0;
    private float timer = 0;
    private float waveTimer = 0;
    private float waitTime = 60;
    private float waveTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        gemCount = 150;
        UI.UpdateGem(gemCount);
        spawnSpots[0] = spawn.transform.GetChild(0).gameObject;
        spawnSpots[1] = spawn.transform.GetChild(1).gameObject;
        spawnSpots[2] = spawn.transform.GetChild(2).gameObject;
        hero.transform.position = spawnSpots[2].transform.position;
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, transform.position.y, hero.transform.position.z);
        if (waveCount != 3)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                StartWave();
                timer = 0;
            }
        }

    }

    private void StartWave()
    {
        Debug.Log("Start Wave");
        waveCount += 1;
        UI.UpdateWave(waveCount);
        if (waveCount == 1)
        {
            Debug.Log("Wave One");
            foreach (var mob in waveOne)
            {
                for (int i = 0; i < 13; i++)
                {
                    mob.gameObject.GetComponent<EnemyScript>().points[i] = transformPoints.transform.GetChild(i);
                }
                Debug.Log("Spawned Mob");
                GameObject monster = Instantiate(mob, spawnSpots[0].transform.position, Quaternion.identity);
                
            }
        }
        if (waveCount == 2)
        {
            Debug.Log("Wave Two");
            foreach (var mob in waveTwo)
            {
                for (int i = 0; i < 13; i++)
                {
                    mob.gameObject.GetComponent<EnemyScript>().points[i] = transformPoints.transform.GetChild(i);
                }
                Debug.Log("Spawned Mob");
                GameObject monster = Instantiate(mob, spawnSpots[0].transform.position, Quaternion.identity);

            }
        }
        if (waveCount == 3)
        {
            Debug.Log("Wave Three");
            foreach (var mob in waveThree)
            {
                for (int i = 0; i < 13; i++)
                {
                    mob.gameObject.GetComponent<EnemyScript>().points[i] = transformPoints.transform.GetChild(i);
                }
                Debug.Log("Spawned Mob");
                GameObject monster = Instantiate(mob, spawnSpots[0].transform.position, Quaternion.identity);

            }
        }  
    }
}
