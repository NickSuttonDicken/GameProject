using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public HeroScript hero;
    public UIController UI;
    private string enemyCount;
    private string waveCount;
    private string gemCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, transform.position.y, hero.transform.position.z);
    }

}
