using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRadiusCollider : MonoBehaviour
{
    public HeroScript hero;
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
        if (other.gameObject.tag == "Enemy")
        {
            hero.AddEnemy(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hero.RemoveEnemy(other.gameObject);
        }

    }
}
