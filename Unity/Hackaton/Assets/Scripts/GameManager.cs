using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ExportData(string data)
    {
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/LevelData.json", data);
        string filePath = Application.persistentDataPath + "/LevelData.json";
        if (!File.Exists(filePath))
            Debug.LogError("The path doesn't exist");

        using (StreamWriter sw = new StreamWriter(filePath))
            sw.Write(data);
        Debug.Log("Successfully saved file to :" + filePath + "\n" + data);

        //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
        //{
        //    Arguments = Application.persistentDataPath,
        //    FileName = "explorer.exe"
        //};

        //System.Diagnostics.Process.Start(startInfo);
    }
}
