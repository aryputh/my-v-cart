using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddItemButton : MonoBehaviour
{
    private DataManager dataManager;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private TMP_InputField titleField;
    [SerializeField] private TMP_InputField descField;
    [SerializeField] private TMP_InputField linkField;

    private void OnEnable()
    {
        // Find and assign the dataManager value
        dataManager = GameObject.FindWithTag("DataManager").GetComponent<DataManager>();
    }

    // Reset all the input fields
    public void ResetFields()
    {
        titleField.text = "";
        descField.text = "";
        linkField.text = "";
    }

    // Will ensure at least something is entered
    public void ValidateField(TMP_InputField inputField)
    {
        if (inputField.text.Length == 0)
        {
            inputField.text = "N/A";
        }
    }

    // Add an item to the saved file and scene
    public void AddItem()
    {
        Item newItem = new Item
        {
            title = titleField.text,
            description = descField.text,
            link = linkField.text
        };

        dataManager.AddItem(newItem);
        GameObject newItemObject = Instantiate(itemPrefab, dataManager.itemParent.transform);
        ItemManager item = newItemObject.GetComponent<ItemManager>();
        item.SetFields(newItem.title, newItem.description, newItem.link);
    }
}
