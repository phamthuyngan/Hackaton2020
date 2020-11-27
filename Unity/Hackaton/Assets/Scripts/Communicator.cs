using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine;

public class Communicator : MonoBehaviour 
{
    [DllImport("__Internal")]
    private static extern void LevelData(string pseudo, int score);

    public static void SaveResult (string pseudo, int score) {
        LevelData(pseudo, score);
    }
}