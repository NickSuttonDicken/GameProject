using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadiusCollider : MonoBehaviour
{
    public EnemyScript Mob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Mob.AddHero(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Mob.RemoveHero(other.gameObject);
        }

    }
}
