using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour {
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

    public LayerMask blockingLayer;
    public SpriteRenderer bodySpriteRenderer;

    public void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        bodySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void Update()
    {
        if (!isMoving)
        {
            boxCollider.enabled = false;
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(input.x < 0)
            {
                bodySpriteRenderer.flipX = true;
            }
            else if (input.x > 0)
            {
                bodySpriteRenderer.flipX = false;
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
        yield return 0;
    }
}
