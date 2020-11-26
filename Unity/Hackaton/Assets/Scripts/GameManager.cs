using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadScene("MenuScene");
    }

    public void ExportData(string data)
    {
        string filePath = Application.persistentDataPath + "/LevelData.json";
        if (!File.Exists(filePath))
            Debug.LogError("The path doesn't exist");

        using (StreamWriter sw = new StreamWriter(filePath))
            sw.Write(data);
        Debug.Log("Successfully saved file to :" + filePath + "\n" + data);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
