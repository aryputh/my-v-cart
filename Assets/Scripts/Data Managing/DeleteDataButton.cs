using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeleteDataButton : MonoBehaviour
{
    private string dataPath;

    private void Awake()
    {
        // Establish a path to save/load from
        dataPath = Path.Combine(Application.persistentDataPath, "_items.json");
    }

    // Delete the saved file, if it exists
    public void DeleteSave()
    {
        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);
            print("Save file deleted sucessfully.");
        }
        else
        {
            print("Save file doesn't exist or was moved.");
        }
    }
}
