using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemButton : MonoBehaviour
{
    private DataManager dataManager;

    [SerializeField] private GameObject itemToDelete;

    private void OnEnable()
    {
        // Find and assign the dataManager value
        dataManager = GameObject.FindWithTag("DataManager").GetComponent<DataManager>();
    }

    // Remove the item from the DataManager's data and the scene
    public void DeleteItem()
    {
        dataManager.RemoveItem(itemToDelete);
        Destroy(itemToDelete, 0.5f);
    }
}
