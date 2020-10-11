using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollision : MonoBehaviour
{
    public int bombDamage = 20;
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = Resources.Load("Sphere") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Terrain")
        {
            Explosion();
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    private void Explosion()
    {
        GameObject obj = Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
