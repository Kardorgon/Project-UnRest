using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionRange : MonoBehaviour {

    public GameObject player;
    private EnemyMove enemyMove;

    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMove = GetComponent<EnemyMove>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 distanceToPlayer = new Vector2(Mathf.Abs(player.GetComponent<Transform>().position.x - transform.position.x), Mathf.Abs(player.GetComponent<Transform>().position.y - transform.position.y));
        float directDistanceToPlayer = Mathf.Sqrt(distanceToPlayer.x * 2 + distanceToPlayer.y * 2);
        if (directDistanceToPlayer < 4)
        {
            enemyMove.state = EnemyMove.State.CHASE;
        }
        else
            enemyMove.state = EnemyMove.State.PATROL;
    }
}
