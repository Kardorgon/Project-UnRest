using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionRange : MonoBehaviour {

    public Transform player;
    private EnemyMove enemyMove;
    public float lookRadius = 4;
    private float attackingDistance = 1.5f;


    // Use this for initialization
    void Start () {
        player = PlayerManager.instance.player.transform;
        enemyMove = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        /*Vector2 distanceToPlayer = new Vector2(Mathf.Abs(player.GetComponent<Transform>().position.x - transform.position.x), Mathf.Abs(player.GetComponent<Transform>().position.y - transform.position.y));
        float directDistanceToPlayer = Mathf.Sqrt(distanceToPlayer.x * 2 + distanceToPlayer.y * 2);
        if (directDistanceToPlayer < lookRadius)
        {
            enemyMove.state = EnemyMove.State.CHASE;
        }
        else
            enemyMove.state = EnemyMove.State.PATROL;
        }*/
        if (distance <= attackingDistance)
        {
            enemyMove.state = EnemyMove.State.ATTACK;
            attackingDistance = 2f;
        }
        else if (distance <= lookRadius)
        {
            enemyMove.state = EnemyMove.State.CHASE;
        } 
        else
        {
            enemyMove.state = EnemyMove.State.PATROL;
        }
    }

    public void OnDrawGizmos()
    {
        if(enemyMove.state == EnemyMove.State.CHASE)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }else if(enemyMove.state == EnemyMove.State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackingDistance);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, lookRadius +1);
        }

    }


}
