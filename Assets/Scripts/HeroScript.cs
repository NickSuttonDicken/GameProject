using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroScript : MonoBehaviour
{
    public int maxHealth = 100;
    public PlayerHealthBar healthBar;
    public float originalSpeed;
    private float currentSpeed;
    private float modifiedSpeed;
    NavMeshAgent mesh;
    Animator anime;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>(); 
        mesh = GetComponent<NavMeshAgent>();
        currentSpeed = originalSpeed;
        mesh.speed = currentSpeed;
        PassHealth();
        Debug.Log("hero");

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit ray;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray, 500))
            {
                mesh.destination = ray.point;
                anime.SetInteger("HeroState", 2);
            }
        }*/

        if (mesh.hasPath == false && mesh.remainingDistance == 0)
        {
            anime.SetInteger("HeroState", 1);
        }

        if (healthBar.HealthDepleted() == true)
        {
            HeroDeath();
        }
        
    }

    public void WalkTo(Vector3 point)
    {
        mesh.destination = point;
        anime.SetInteger("HeroState", 2);
    }

    public void PassHealth()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void HeroDeath()
    {
        mesh.isStopped = true;
        anime.SetInteger("HeroState", 10);
    }

    public void SetSlowSpeed(float modifier)
    {
        currentSpeed = currentSpeed * modifier;
        mesh.speed = currentSpeed;
    }
    
    public void SetNormalSpeed()
    {
        currentSpeed = originalSpeed;
        mesh.speed = currentSpeed;
    }

}
