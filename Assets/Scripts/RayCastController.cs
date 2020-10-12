using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastController : MonoBehaviour
{
    public HeroScript hero;
    public UIController UI;
    private int select;
    public EventSystem eventSystem;

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
                    
                    if (UI.ButtonClicked() == true)
                    {
                        Debug.Log("Tower Spawned");
                        select = UI.ButtonSelect();
                        Debug.Log(select);
                        ray.collider.gameObject.GetComponent<PlaceTower>().TowerPlacing(ray.collider, ray.point, select);
                        select = 0;
                    }
                    
                }
                else if (!eventSystem.IsPointerOverGameObject())
                {
                    hero.WalkTo(ray.point);
                }
            }
        }
    }
}
