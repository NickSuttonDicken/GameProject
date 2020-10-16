using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawn;
    public List<GameObject> spawnSpots = new List<GameObject>();
    public GameObject hero;
    public HeroScript heroScript;
    public UIController UI;
    private string enemyCount;
    private string waveCount;
    private string gemCount;

    // Start is called before the first frame update
    void Start()
    {
        spawnSpots[0] = spawn.transform.GetChild(0).gameObject;
        spawnSpots[1] = spawn.transform.GetChild(1).gameObject;
        spawnSpots[2] = spawn.transform.GetChild(2).gameObject;

        hero.transform.position = spawnSpots[2].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, transform.position.y, hero.transform.position.z);
    }

}
