using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{

    private GameManager gameManager;
    private Robot robot;
    private LevelData lvlData;
    private Coroutine cor;
    private List<Action>[] timelines;
    [SerializeField] private float secondsBetweenTurns = 1.0f;
    private int currentTurn;
    private int NbrOfTurns;
    public bool isReading { get; private set; }
    public UIManager()
    {
        isReading = false;
        NbrOfTurns = 0;
    }
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        robot = FindObjectOfType<Robot>();
        lvlData = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));

        //test
        //Action test = (Action)ScriptableObject.CreateInstance(typeof(Action));
        timelines = new List<Action>[5];
        for (int i = 0; i < 5; i++)
        {
            timelines[i] = new List<Action>();
        }
        //timelines[3].Add(test);
        //ReadTimeline();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(lvlData);
        gameManager.ExportData(data);
    }
    public void AddAction(int objIndex, Action action)
    {
        timelines[objIndex].Add(action);
    }
    public void ReadTimeline()
    {
        if (!isReading)
        {
            for (int i = 0; i < timelines.Length; i++) // checks the maximum nuber of turn to read
                NbrOfTurns = (timelines[i].Count > NbrOfTurns) ? timelines[i].Count : NbrOfTurns;

            cor = StartCoroutine(PlayActions());// start the reading coroutine
        }
    }

    private IEnumerator PlayActions()
    {
        isReading = true;
        while (currentTurn < NbrOfTurns)
        {
            for (int i = 0; i < timelines.Length; i++)
            {
                if (timelines[i].Count > 0)
                {
                    Action action = timelines[i][currentTurn];
                    if (action != null)
                    {
                        robot.MovePart(i, action);
                    }
                }
            }
            currentTurn++;
            yield return new WaitForSeconds(secondsBetweenTurns);
        }
        isReading = false;
    }
}
