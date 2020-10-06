using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public HeroScript hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit ray;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray, 500))
            {
                if (ray.collider.gameObject.tag == "Tower")
                {
                    ray.collider.gameObject.GetComponent<PlaceTower>().TowerPlacing(ray.collider, ray.point);
                }
                else
                {
                    hero.WalkTo(ray.point);
                }
            }
        }
    }
}
