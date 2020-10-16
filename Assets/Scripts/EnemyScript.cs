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
    private int pointCounter = 0;
    private NavMeshAgent mesh;
    Animator anim;
    private List<GameObject> heroList = new List<GameObject>();

    public int damage;
    public float attackRate;
    public float attackRange;
    private float inRange;

    public float timer;
    Ray attackRay;
    RaycastHit attackHit;

    void Start()
    {
        mesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentSpeed = originalSpeed;
        mesh.speed = currentSpeed;
        PassHealth();
        mesh.autoBraking = true;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        anim.SetInteger("MonsterState", 2);

        mesh.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        
        
    }

    private void GotoCurrentPoint()
    {
        destPoint = pointCounter;
        anim.SetInteger("MonsterState", 2);
        mesh.destination = points[destPoint].position;
    }


    void Update()
    {
        if (heroList.Count != 0)
        {
            if (heroList[0] == null)
            {
                Debug.Log("Null");
                heroList.RemoveAt(0);
            }
            else
            {
                mesh.destination = heroList[0].transform.position;
                timer += Time.deltaTime;
                if (timer > attackRate)
                {
                    anim.SetInteger("MonsterState", 3);
                    Attack();
                    timer = 0;
                }
            }
        }
        if (!mesh.pathPending && mesh.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            if (pointCounter != 12)
            {
                pointCounter += 1;
            }
            else
            {
                pointCounter = 0;
            }
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


    public void Attack()
    {
        attackRay.origin = transform.position;
        attackRay.direction = transform.up;

        if (heroList.Count != 0)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toTarget = heroList[0].transform.position - transform.position;
            inRange = Vector3.Dot(forward, toTarget);

            if (inRange > 0f && inRange < 1f)
            {
                attackRay.direction = heroList[0].transform.position;
                Physics.Raycast(attackRay, out attackHit, attackRange);
                heroList[0].GetComponent<HeroScript>().healthBar.TakeDamage(damage);
            }
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

    public void AddHero(GameObject other)
    {
        Debug.Log("Added to List");
        heroList.Add(other);
    }

    public void RemoveHero(GameObject other)
    {
        Debug.Log("Removed from List");
        heroList.Remove(other);
        GotoCurrentPoint();
    }
}
