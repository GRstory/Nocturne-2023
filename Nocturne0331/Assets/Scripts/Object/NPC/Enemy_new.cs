using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_new : MonoBehaviour
{
    public Transform[] patrolPoint;
    public Transform playerTarget;
    public float detectDistance = 3f;
    public float patorlSpeed = 1f;
    public float chaseSpeed = 1.5f;
    public float waitTime = 1f;
    public float chaseTime = 10f;

    private NavMeshAgent agent;
    private int index;
    private bool isChasing;
    private bool isReturn;
    private float waitTimer;
    private float chaseTimer;
    private Light spotLight;
    private float attackTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spotLight = this.transform.Find("Spot Light").gameObject.transform.GetComponent<Light>();
        index = 0;
        agent.SetDestination(patrolPoint[index].position);
        isChasing = false;
        isReturn = false;
        waitTimer = 0;
        agent.speed = patorlSpeed;
        Debug.Log(agent.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, playerTarget.transform.position)<=1.5f)
        {
            attackTimer +=Time.deltaTime;
            if(attackTimer >= 0.2)
            {
                attackTimer = 0;
                GameManager.Instance.HEALTH -= 2;
            }
        }
        if(isChasing)
        {
            ChaseTarget();
        }
        else
        {
            Patrol();
        }
    }
    private void Patrol()
    {

        if(Vector3.Distance(transform.position, patrolPoint[index].position)<=0.2f)
        {
            index = (index + 1) % patrolPoint.Length;
            agent.SetDestination(patrolPoint[index].position);
        }

        if(!isReturn&&Vector3.Distance(transform.position, playerTarget.position)<=detectDistance)
        {
            spotLight.color = new Color(1f,0.29f,0.135f);
            GameManager.Instance.BGM_INDEX_B = GameManager.Instance.BGM_INDEX;
            GameManager.Instance.BGM_INDEX = 4;
            chaseTimer = 0f;
            isChasing = true;
            agent.speed = chaseSpeed;
            agent.SetDestination(playerTarget.position);
        }
        
        else if (isReturn)
        {
            GameManager.Instance.BGM_INDEX = GameManager.Instance.BGM_INDEX_B;
            spotLight.color = new Color(1f, 0.75f, 0.25f);
            agent.SetDestination(transform.position);
            agent.speed = patorlSpeed;
            waitTimer += Time.deltaTime;
            if(waitTimer >= waitTime)
            {
                isReturn = false;
                agent.SetDestination(patrolPoint[index].position);
                spotLight.color = new Color(0.25f, 1f, 0.25f);
            }
        }
    }

    private void ChaseTarget()
    {
        chaseTimer += Time.deltaTime;
        if (!isReturn && ((Vector3.Distance(transform.position, playerTarget.position)>detectDistance+1f)||
        chaseTimer >= chaseTime))
        {
            isChasing = false;
            isReturn = true;
            waitTimer = 0f;
        }
        agent.SetDestination(playerTarget.position);
    }
}
