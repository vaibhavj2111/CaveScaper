using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// attach this script to the enemy's fireball that it will throw, set layer as of grid's layer
public class BallCollisionHandler : MonoBehaviour
{
     public LayerMask gridLayer; // Specify the grid layer in the Inspector.
      public float overlapRadius = 0.1f; // Adjust the radius based on your bullet size.

       private void Update()
    {
         Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius, gridLayer);

        // Check if any of the colliders belong to the grid layer.
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Grid"))
            {
                // Destroy the bullet upon collision with the grid.
                Destroy(gameObject);
                return; // Exit the loop after destroying the bullet.
            }
        }
    }
}
 

