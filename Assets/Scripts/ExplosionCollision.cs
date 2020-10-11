using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollision : MonoBehaviour
{
    public BombCollision bomb;
    private int damage;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetDamage();   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            DestroySelf();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Terrain")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<HeroScript>().healthBar.TakeDamage(damage);
            }
        }
    }

    public void GetDamage()
    {
        damage = bomb.bombDamage;
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
