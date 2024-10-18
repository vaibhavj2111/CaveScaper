using UnityEngine;

public class HealthKit : Item
{
    GameObject playerobject;
    // Constructor to initialize fields
    public void OnEnable()
    {
        playerobject = GameObject.FindGameObjectWithTag("Player");
        itemName = "HealthKit";
        value = 10;
        weight = 1;
        PlayerInventory = playerobject.GetComponent<Inventory>();
    }


    public override void PickUp()
    {
        // Debug.Log("Add function called from Item abstract class");
        if (PlayerInventory.Add(this))
        {

            itemObject.SetActive(false);
            DungeonState.AddOpenSpace(Vector2Int.RoundToInt(transform.position));
        }
    }
    public override void Drop()
    {
        PlayerInventory.Remove(this);
        itemObject.SetActive(true);
        Transform player = DungeonState.PlayerInstance.transform;
        transform.position = Vector3Int.RoundToInt(player.position+player.forward);
        DungeonState.RemoveSpace(Vector2Int.RoundToInt(transform.position));
        // itemObject.transform= 
    }
    public override void Use()
    {
        playerobject.GetComponent<CharacterStats>().HealthUpgrade((int)value);
        // Implement the specific use behavior for collectibleItem
        Debug.Log("HealthKit used.");
    }
}

