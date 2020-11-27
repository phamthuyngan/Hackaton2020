using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    private GameManager gameManager;
    private Robot robot;
    private LevelData lvlData;
    private Coroutine cor;
    [SerializeField] private Text cyclesDisplay;

    [SerializeField] private GameObject timelinePanel;
    private List<Action>[] timelines;
    private List<Image>[] timelinesImages;

    private int currentTurn;
    private int NbrOfTurns;
    private int NbrOfCycles;
    private int NbrOfParts = 6;
    [SerializeField] private float secondsBetweenTurns = 1.0f;
    [SerializeField] private GameObject timelineElement;
    [SerializeField] private GameObject winScreen;
    private LanguagueBalls[] ballsInScene;
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
        ArraysInit();
        ballsInScene = FindObjectsOfType<LanguagueBalls>();

    }
    public void AddAction(int objIndex, Action action, Image image)
    {
        timelines[objIndex].Add(action);

        GameObject newIcon = Instantiate(timelineElement, timelinePanel.transform.position, Quaternion.identity);
        newIcon.transform.SetParent(timelinePanel.transform);
        RectTransform rectTrs = newIcon.GetComponent<RectTransform>();
        rectTrs.localPosition = new Vector3(30.0f * timelinesImages[objIndex].Count - 835.0f, 30.0f * -objIndex + 75.0f, 0.0f);
        Image newImage = newIcon.GetComponent<Image>();
        newImage.sprite = image.sprite;
        timelinesImages[objIndex].Add(newImage);
    }
    public void RemoveAction(int objIndex)
    {
        if (timelines[objIndex].Count > 0)
        {
            timelines[objIndex].Remove(timelines[objIndex][timelines[objIndex].Count - 1]);
            GameObject lastObj = timelinesImages[objIndex][timelinesImages[objIndex].Count - 1].gameObject;
            timelinesImages[objIndex].Remove(timelinesImages[objIndex][timelinesImages[objIndex].Count - 1]);
            Destroy(lastObj);
        }
    }
    public void Clear()
    {
        Transform[] elementsToDelete = timelinePanel.GetComponentsInChildren<Transform>();
        for (int i = 0; i < elementsToDelete.Length; i++)
            if (elementsToDelete[i].transform != timelinePanel.transform)
            {
                Destroy(elementsToDelete[i].gameObject);
            }

        ArraysInit();
        robot.ResetRotation();
        foreach (LanguagueBalls ball in ballsInScene)
        {
            ball.Reset();
        }
    }
    public void ReadTimeline()
    {
        if (!isReading)
        {
            currentTurn = 0;
            isReading = true;
            for (int i = 0; i < NbrOfParts; i++)
            { // checks the maximum nuber of turn to read
                NbrOfTurns = (timelines[i].Count > NbrOfTurns) ? timelines[i].Count : NbrOfTurns;
            }
                if (NbrOfTurns == 0)
                    return;
            NbrOfCycles = NbrOfTurns;
        cor = StartCoroutine(PlayActions());// start the reading coroutine
        }
    }
    public void Win()
    {
        winScreen.SetActive(true);
        gameManager.Pause();
        cyclesDisplay.text = "Number of cycles : " + NbrOfCycles;
    }
    public void SaveData(Text pseudo)
    {
        lvlData.pseudo = pseudo.text;
        lvlData.cycles = NbrOfCycles;
        string data = JsonUtility.ToJson(lvlData);
        gameManager.ExportData(data);
        Communicator.SaveResult(lvlData.pseudo, lvlData.cycles);
    }
    private void ArraysInit()
    {
        timelines = new List<Action>[NbrOfParts];
        timelinesImages = new List<Image>[NbrOfParts];
        for (int i = 0; i < NbrOfParts; i++)
        {
            timelines[i] = new List<Action>();
            timelinesImages[i] = new List<Image>();
        }
    }
    private IEnumerator PlayActions()
    {
        while (currentTurn < NbrOfTurns)
        {
            for (int i = 0; i < timelines.Length; i++)
            {
                if (timelines[i].Count > 0 && currentTurn < timelines[i].Count)
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
        robot.ResetRotation();
        foreach (LanguagueBalls ball in ballsInScene)
        {
            ball.Reset();
        }
        isReading = false;
    }


}
