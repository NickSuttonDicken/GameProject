using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTowerController : MonoBehaviour
{
    private List<GameObject> enemyList = new List<GameObject>();
    private Vector3 velocity;
    private bool canFire = false;
    public float SpeedModifier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count != 0)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }

    public float GetSpeedMod()
    {
        return SpeedModifier;
    }

    private void SlowEnemy()
    {
        if (canFire == true)
        {

        }

    }
}
