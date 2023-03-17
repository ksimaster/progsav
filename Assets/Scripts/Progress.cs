using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int X;
    public int Z;
    public int Level = 1;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
