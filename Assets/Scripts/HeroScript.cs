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
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        mesh = GetComponent<NavMeshAgent>();
        currentSpeed = originalSpeed;
        mesh.speed = currentSpeed;
        PassHealth();
        Debug.Log("hero");

    }

    // Update is called once per frame
    void Update()
    {
        if (mesh.hasPath == false && mesh.remainingDistance == 0)
        {
            anim.SetInteger("HeroState", 1);
        }

        if (healthBar.HealthDepleted() == true)
        {
            HeroDeath();
        }
    }

    public void WalkTo(Vector3 point)
    {
        mesh.destination = point;
        anim.SetInteger("HeroState", 2);
    }

    public void PassHealth()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void HeroDeath()
    {
        mesh.isStopped = true;
        anim.SetInteger("HeroState", 10);
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
