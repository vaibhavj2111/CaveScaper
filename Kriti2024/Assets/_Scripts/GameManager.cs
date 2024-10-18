using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public DungeonGenerator generator;

    public UIManager uIManager;
    GameObject tempParent;
    // private void Awake() {
    //      generator.SetSeedAndGenerate();
    //     generator.PlaceItems();
        
    //     // Debug.Log(possibleSpawnPoints.Count);
    //     DungeonState.PlayerInstance = Instantiate(Player,(Vector3Int)DungeonState.rooms[0].roomCenter,Quaternion.identity);
        
    //     generator.PlaceEnemies();
    //     // for(int i=0;i<DungeonState.rooms.Count;i++){
    //     //     GameObject temp = new GameObject(i.ToString());
    //     //     temp.transform.position = (Vector3Int)DungeonState.rooms[i].roomCenter;
    //     // }
    // }

    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.Space)){
    //         tempParent = new GameObject("parent");
    //         DungeonState.DebugWithObjects(DungeonState.openSpaces, tempParent);
    //     }
    //     if(Input.GetKeyUp(KeyCode.Space)){
    //         Destroy(tempParent);
    //     }
    // }

    public IEnumerator StartDungeon(int seed){
        
        Random.InitState(seed);
        // uIManager.ActivatePanel("loading");
        generator.SetSeedAndGenerate(seed);
        DungeonState.PlayerInstance = Instantiate(Player,(Vector3Int)DungeonState.rooms[0].roomCenter,Quaternion.identity);
        generator.PlaceItems();
        generator.PlaceEnemies();
        // uIManager.DeactivatePanel("loading");
        yield return null;

    }
}
