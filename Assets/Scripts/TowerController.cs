using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Turret;
    public GameObject Spawn;
    public GameObject Ammo;
    public int fireRate;
    public int damage;
    public float ammoSpeed;
    private List<GameObject> enemyList = new List<GameObject>();
    private Vector3 velocity;
    private bool canFire = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count != 0)
        {
            if (enemyList[0] == null)
            {
                //Debug.Log("Null");
                EnemyDeath();
            }
            else
            {
                Vector3 direction = enemyList[0].transform.position - Turret.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                Turret.transform.rotation = rotation;

                canFire = true;

                timer += Time.deltaTime;
                if (timer > fireRate)
                {
                    FireAtEnemy();
                    timer = 0;
                }
            }
        }
        else
        {
            canFire = false;
        }
    }

    public void AddEnemy(GameObject other)
    {
        Debug.Log("Added to List");
        enemyList.Add(other);
    }
    
    public void RemoveEnemy(GameObject other)
    {
        Debug.Log("Removed from List");
        enemyList.Remove(other);
    }

    private void FireAtEnemy()
    {
        if (canFire == true)
        {
            GameObject ammo = Object.Instantiate(Ammo, Spawn.transform.position, Spawn.transform.rotation);
            velocity = enemyList[0].transform.position - Spawn.transform.position;
            ammo.GetComponent<Rigidbody>().velocity = velocity * ammoSpeed;
        }
        
    }

    public void EnemyDeath()
    {
        enemyList.RemoveAt(0);
    }
}
