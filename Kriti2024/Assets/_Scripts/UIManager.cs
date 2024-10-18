using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public PanelObject[] panels;

    public TMP_Text loadingSeed;
    public GameManager gameManager;

    public Transform inventory;

    public Image image;

    public Sprite vacantSprite;
    private void Start() {
        foreach(PanelObject panel in panels){
            DeactivatePanel(panel.name);
        }
        ActivatePanel("main");
    }
    private  GameObject GetPanel(string name){
        foreach(PanelObject item in panels){
            if(item.name == name){
                return item.panel;
            }
        }
        return null;
    }
    public void ActivatePanel(string name){
        GameObject panel = GetPanel(name);
        panel.SetActive(true);
    }
    public void DeactivatePanel(string name){
        GameObject panel = GetPanel(name);
        panel.SetActive(false);
    }

    public void StartGame(){

        
        // gameManager.StartDungeon(DungeonState.DungeonSeed);

        StartCoroutine(Generate());

    }
    
    IEnumerator SetSeedChangeUI(){
        DungeonState.DungeonSeed = Random.Range(100000,1000000);
        loadingSeed.text = DungeonState.DungeonSeed.ToString();
        DeactivatePanel("main");
        ActivatePanel("loading");
        yield return null;
    }
    IEnumerator Generate(){
        yield return SetSeedChangeUI();
        yield return StartCoroutine(gameManager.StartDungeon(DungeonState.DungeonSeed));

        DeactivatePanel("loading");
    }

    public void SetInventorySlot(int index, Sprite pickedItem){
        Image slot= inventory.GetChild(index).gameObject.GetComponent<Image>();
        slot.sprite = pickedItem;
    }
    public void EmptyInventorySlot(int index){
        SetInventorySlot(index,vacantSprite);

    }
}

[System.Serializable]
public class PanelObject{
    public GameObject panel;

    public string name;


}