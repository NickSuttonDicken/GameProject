using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroScript : MonoBehaviour
{
    private List<GameObject> enemyList = new List<GameObject>();
    public DeathMenu deathMenu;
    public int maxHealth = 100;
    public PlayerHealthBar healthBar;
    public float originalSpeed;
    private float currentSpeed;
    private float modifiedSpeed;
    NavMeshAgent mesh;
    Animator anim;

    public int damage;
    public float attackRate;
    public float attackRange;
    private float inRange;

    public float timer;
    Ray attackRay;
    RaycastHit attackHit;

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

        if (enemyList.Count != 0)
        {
            if (enemyList[0] == null)
            {
                Debug.Log("Null");
                enemyList.RemoveAt(0);
            }
            else
            {
                Vector3 direction = enemyList[0].transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;

                //mesh.destination = enemyList[0].transform.position;
                timer += Time.deltaTime;
                if (timer > attackRate)
                {
                    Debug.Log("Attacking");
                    anim.Play("Male Attack 1");
                    Attack();
                    timer = 0;
                }
            }
        }
    }

    public void WalkTo(Vector3 point)
    {
        mesh.destination = point;
        anim.SetInteger("HeroState", 2);
    }

    public void Attack()
    {
        attackRay.origin = transform.position;
        attackRay.direction = transform.up;

        if (enemyList.Count != 0)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toTarget = enemyList[0].transform.position - transform.position;
            inRange = Vector3.Dot(forward, toTarget);

            if (inRange > 0f && inRange < 1f)
            {
                attackRay.direction = enemyList[0].transform.position;
                Physics.Raycast(attackRay, out attackHit, attackRange);
                enemyList[0].GetComponent<EnemyScript>().healthBar.TakeDamage(damage);
            }
        }
    }

    public void PassHealth()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void HeroDeath()
    {
        mesh.isStopped = true;
        anim.SetInteger("HeroState", 10);
        deathMenu.DeathOccurs();
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
}
