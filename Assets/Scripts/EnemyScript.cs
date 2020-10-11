using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 50;
    public EnemyHealthBar healthBar;
    public float originalSpeed;
    private float currentSpeed;
    private float modifiedSpeed;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent mesh;
    Animator anim;


    void Start()
    {
        mesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentSpeed = originalSpeed;
        mesh.speed = currentSpeed;
        PassHealth();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        mesh.autoBraking = true;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }

        anim.SetInteger("MonsterState", 2);
        // Set the agent to go to the currently selected destination.
        mesh.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!mesh.pathPending && mesh.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        if (mesh.hasPath == false && mesh.remainingDistance == 0)
        {
            anim.SetInteger("MonsterState", 1);
        }
        if (healthBar.HealthDepleted() == true)
        {
            MonsterDeath();
        }
    }

    public void PassHealth()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void MonsterDeath()
    {
        mesh.isStopped = true;
        anim.SetInteger("MonsterState", 10);
        Destroy(this.gameObject);

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
