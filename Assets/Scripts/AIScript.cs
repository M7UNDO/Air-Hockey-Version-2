using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    
    public float acceleration = 10f; 

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;

   
    private Vector2 velocity = Vector2.zero;

 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        MaxMovementSpeed = Save.instance.maxMovementSpeed;
        Save.instance.SaveData();

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);
    }

    private void FixedUpdate()
    {
        float movementSpeed;

        if (Puck.position.y < puckBoundary.Down)
        {
            if (isFirstTimeInOpponentsHalf)
            {
                isFirstTimeInOpponentsHalf = false;
                offsetXFromTarget = Random.Range(-1.2f, 1.2f);
            }

            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetXFromTarget, playerBoundary.Left,
                                                    playerBoundary.Right),
                                        startingPosition.y);
        }
        else
        {
            isFirstTimeInOpponentsHalf = true;

            movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                        playerBoundary.Right),
                                        Mathf.Clamp(Puck.position.y, playerBoundary.Down,
                                        playerBoundary.Up));
        }
        
        Vector2 moveDirection = (targetPosition - rb.position).normalized;

       
        Vector2 desiredVelocity = moveDirection * movementSpeed;
        Vector2 force = (desiredVelocity - rb.velocity) * acceleration;

        
        rb.AddForce(force, ForceMode2D.Force);

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                movementSpeed * Time.fixedDeltaTime));
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
        rb.velocity = Vector2.zero; 
    }
}

