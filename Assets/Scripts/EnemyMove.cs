using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    BoxCollider2D boxCollider;
    private float moveSpeed = 3f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Vertical;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;
    public float moveAllowed = 1f;

    public LayerMask blockingLayer;
    public SpriteRenderer bodySpriteRenderer;
    public GameObject player;

    public enum State
    {
        PATROL,
        CHASE,
        ATTACK
    }
    public State state;
    public void Start()
    {
        state = EnemyMove.State.PATROL;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        bodySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        state = State.PATROL;
    }
    public void Update()
    {
        moveAllowed -= Time.deltaTime;
        if (state == State.PATROL)
        {
            if (moveAllowed <= 0)
            {
                if (!isMoving)
                {
                    boxCollider.enabled = false;
                    input = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    if (input.x < 0)
                    {
                        bodySpriteRenderer.flipX = false;
                    }
                    else if (input.x > 0)
                    {
                        bodySpriteRenderer.flipX = true;
                    }
                    if (!allowDiagonals)
                    {
                        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                        {
                            input.y = 0;
                        }
                        else
                        {
                            input.x = 0;
                        }
                    }

                    if (input != Vector2.zero)
                    {
                        AttemptMove(input);
                    }
                    boxCollider.enabled = true;
                }
            }
        }
        else if(state == State.CHASE)
        {
            print("mam go!");
        }
        else if(state == State.ATTACK)
        {
            FaceTarget();
            print("Atakuje go");
        }
    }


    public void AttemptMove(Vector2 direction)
    {
        Vector2 startPosition = transform.position;
        if (Physics2D.Raycast(startPosition, direction, 1, blockingLayer))
        {
            print("nie moge sie ruszyc");
        }
        else
        {
            StartCoroutine(move(transform));
        }

    }
    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
        moveAllowed = 1f;
        yield return 0;
    }
    public void FaceTarget()
    {
        Vector2 direction = (PlayerManager.instance.player.transform.position - transform.position).normalized;
        print(direction);
        if(direction.x >= 0.6 && direction.x <= 1 && direction.y >= 0.6 && direction.y <= 0.8)
        {
            bodySpriteRenderer.flipX = true;
            print("a obrocenie");
        }
        else if ((direction.x >= -1 && direction.x <= -0.1) || (direction.y <= 1 && direction.y >= 0.1))
        {
            bodySpriteRenderer.flipX = false;
            print("b obrocenie");
        }
        else
        {
            bodySpriteRenderer.flipX = true;
            print("c obrocenie");
        }

    }
}
