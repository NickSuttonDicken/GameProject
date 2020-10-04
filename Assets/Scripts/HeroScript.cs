using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroScript : MonoBehaviour
{
    public int maxHealth = 100;
    public PlayerHealthBar healthBar;
    NavMeshAgent mesh;
    Animator anime;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>(); 
        mesh = GetComponent<NavMeshAgent>();
        Debug.Log("hero");
        healthBar.SetMaxHealthBar(maxHealth);
        //healthBar.SetHealthBar(maxHealth);
        healthBar.SetHealthBar(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit ray;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray, 500))
            {
                mesh.destination = ray.point;
                anime.SetInteger("HeroState", 2);
            }
        }
        // healthBar.SetHealthBar(10);
    }
}
