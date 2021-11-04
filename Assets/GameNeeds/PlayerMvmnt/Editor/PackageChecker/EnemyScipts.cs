using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScipts : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whitIsGround, whitIsPlayer;


    public Vector3 walkPoint;
    bool walkPoitSet;
    public float walkPointRange;


    public float TimeBetweenAttacks;
    bool alreadyAttacked;


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackedRange;


    public GameObject projectile;

    public float health;



    private void Awake()
    {
        player = GameObject.Find("playerobj").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whitIsPlayer);
        playerInAttackedRange = Physics.CheckSphere(transform.position, attackRange, whitIsPlayer);


        if (!playerInSightRange && !playerInAttackedRange) Patroling();
        if (playerInSightRange && playerInAttackedRange) ChasePlayer();
        if (playerInSightRange && !playerInAttackedRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPoitSet) SearchWalkPoint();

        if (walkPoitSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPoitSet = false;
        }
    }



    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whitIsGround))
        {
            walkPoitSet = true;
        }
    }


    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }




    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);



            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    public void TakeDamage(int damage)
    {
        health = damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }


    private void DestroyEnemy()
    {
        Destroy(gameObject);

    }

}
