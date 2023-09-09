using Unity.Collections;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    public GameObject itemParent;

    [Header("Do NOT edit:")]
    [SerializeField] private ItemData itemData;

    private string dataPath;

    private void Awake()
    {
        // Establish a path to save/load from
        dataPath = Path.Combine(Application.persistentDataPath, "_items.json");

        // Prints out where the data is saved
        //print("Saved at: " + Application.persistentDataPath + "_items.json");
    }

    private void OnEnable()
    {
        LoadData();
    }

    public void SaveData()
    {
        // Save the data to a file
        string jsonData = JsonUtility.ToJson(itemData, true);
        File.WriteAllText(dataPath, jsonData);
    }

    public void LoadData()
    {
        // Check if the file exists
        if (File.Exists(dataPath))
        {
            string jsonData = File.ReadAllText(dataPath);
            itemData = JsonUtility.FromJson<ItemData>(jsonData);
        }
        else
        {
            // Create a new list if the data doesn't exist
            itemData = new ItemData();
        }

        // Create items
        InstantiateItems();
    }

    private void InstantiateItems()
    {
        // Destroy any existing items
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new items
        foreach (Item currentItem in itemData.items)
        {
            GameObject item = Instantiate(itemPrefab, itemParent.transform);
            ItemManager itemManager = item.GetComponent<ItemManager>();
            item.name = currentItem.title;

            // Fill in the fields for each item
            itemManager.SetFields(currentItem.title, currentItem.description, currentItem.link);
        }
    }

    public void RemoveItem(GameObject itemToDelete, string descText, string linkText)
    {
        // Remove the item from the data
        Item itemToRemove = itemData.items.Find(item => item.title == itemToDelete.name);
        Item itemToRemove2 = itemData.items.Find(item2 => item2.description == descText);
        Item itemToRemove3 = itemData.items.Find(item3 => item3.link == linkText);

        if (itemToRemove != null && (itemToRemove == itemToRemove2 && itemToRemove == itemToRemove3))
        {
            itemData.items.Remove(itemToRemove);
        }

        // Save the updated data
        SaveData();
    }

    public void AddItem(Item newItem)
    {
        // Add the new item to the data
        itemData.items.Add(newItem);

        // Save the updated data
        SaveData();
    }
}