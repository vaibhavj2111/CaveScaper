using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAndTransformScript : MonoBehaviour

{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float attackRadius = 1.5f;
    private float moveSpeedConst;
    public float rotationModifier;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        moveSpeedConst = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > attackRadius)
        {
            moveSpeed = moveSpeedConst;
            Vector3 direction = player.position - transform.position;
            Debug.Log(distanceToPlayer);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            moveSpeed = 0f;
        }


    }


    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
