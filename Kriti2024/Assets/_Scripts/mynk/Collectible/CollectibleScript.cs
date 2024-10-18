using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private KeyCode collectKey = KeyCode.Space; // Set your desired key
    private float decreasingSpeedUnit = 1; // Adjust the speed decrease value as needed
    private collectibleItem item; // Reference to the collectibleItem component

    private bool canCollect; // Flag to track whether collection is allowed

    GameObject player;

    private void Start()
    {
        // Get the collectibleItem component from the current GameObject
        item = GetComponent<collectibleItem>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check for collect key input outside of OnTriggerStay2D
        if (canCollect && Input.GetKeyDown(collectKey))
        {
            Collect(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = true; // Set flag when player enters trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false; // Reset flag when player exits trigger
        }
    }

    private void Collect(GameObject player)
    {
        // Collectible logic
        if (player.TryGetComponent(out PlayerController playerController))
        {
                decreasingSpeedUnit = item.weight;
                playerController.movementSpeed -= decreasingSpeedUnit;
                playerController.movementSpeed = Mathf.Max(playerController.movementSpeed, 1);
                item.PickUp(); // Call the item's pickup();
                //Destroy(gameObject);
                // Disable collider
                Collider2D collider = GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                
                // Disable sprite renderer
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }

        }
        else
        {
            Debug.LogWarning("PlayerController component not found on player object.");
        }
    }
}
