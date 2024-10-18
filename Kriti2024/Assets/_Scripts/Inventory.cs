using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(10);

    public UIManager uIManager;
    
    public int currentIndex;


    private void Update() {
    
    }

    public float GetTotalWeight(){
        float weight = 0f;
        foreach(var item in items){
            weight+=item.weight;
        }
        return weight;
    }

    public void Add(Item item){
        int index = GetEmpySlot();
        if(index>0){

            items[index]=item;
            uIManager.SetInventorySlot(index,item.sprite);
        }
    }

    public void Remove(Item item){
        items.Remove(item);
    }

    int GetEmpySlot(){
        for(int i=0;i<10;i++){
            if(items[i]==null){

                return i;
            }
        }
        return -1;
    }
}


