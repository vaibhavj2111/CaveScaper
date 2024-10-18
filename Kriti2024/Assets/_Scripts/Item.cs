using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public float value;

    public GameObject itemObject;
    public float weight;

    public Sprite sprite;
    public Vector2Int size = new Vector2Int();

    public PlacementType type ;
    private float textRange = 5f;

    [SerializeField]

    private TMP_Text nameText;
    [SerializeField]
    //private GameObject textObject;
    LayerMask playerLayer;

    public Inventory PlayerInventory;
    private void OnEnable() {
        
        playerLayer = LayerMask.GetMask("Player");
        
    }
    public abstract void Use();

    public void PickUp(){

        PlayerInventory.Add(this);
        itemObject.SetActive(false);
        DungeonState.AddOpenSpace(Vector2Int.RoundToInt(transform.position));
    }

    public void Drop(){
        PlayerInventory.Remove(this);
        itemObject.SetActive(true);
        Transform player = DungeonState.PlayerInstance.transform;
        transform.position = Vector3Int.RoundToInt(player.position+player.forward);
        DungeonState.RemoveSpace(Vector2Int.RoundToInt(transform.position));
        // itemObject.transform= 
    }

    private void FixedUpdate() {
        if(PlayerInventory == null){
            PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,textRange,playerLayer);

        if(colliders!=null){
            nameText.text = itemName;
        }
        else{
            nameText.text="";
        }
    }
}



