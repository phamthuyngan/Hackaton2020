using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LevelData))]
public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    private LevelData lvlData;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        lvlData = GetComponent<LevelData>();
    }

    void Update()
    {
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(lvlData);
        gameManager.ExportData(data);
    }

}
