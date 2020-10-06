using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject[] TowerBalistaArray;
    public GameObject[] TowerMagicArray;
    public GameObject[] TowerCannonArray;
    private GameObject towerBalista;
    private GameObject towerMagic;
    private GameObject towerCannon;
    public int selection = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CanPlaceTower()
    {
        return towerBalista == null;
    }

    public void TowerPlacing(Collider collision, Vector3 point)
    {
        if (collision.isTrigger)
        {
            Debug.Log("Confirmed");
            if (CanPlaceTower())
            {
                if (selection == 1)
                {
                    Debug.Log("TowerBalista");
                    towerBalista = (GameObject)
                        Instantiate(TowerBalistaArray[0], transform.position, Quaternion.identity);
                }
                else if (selection == 2)
                {
                    towerCannon = (GameObject)
                        Instantiate(TowerCannonArray[0], transform.position, Quaternion.identity);
                }
                else if (selection == 3)
                {
                    towerMagic = (GameObject)
                        Instantiate(TowerMagicArray[0], transform.position, Quaternion.identity);
                }
            }
        }
    }


}
