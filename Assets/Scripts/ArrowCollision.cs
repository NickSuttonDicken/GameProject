using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    
    private int arrowDamage = 10;
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
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag ==  "Terrain")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyScript>().healthBar.TakeDamage(arrowDamage);
            }
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
