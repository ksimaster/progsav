using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

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
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] TextMeshProUGUI _playerInfoText;

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

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            LoadExtern();
#endif
    }

    private void Update()
    {
        //обнуление, желательно использовать с префами и перезагрузкой сцены
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            playerInfo = new PlayerInfo();
            Save();
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfo);
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveExtern(jsonString);
#endif
    }

    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = "Coins: " + playerInfo.Coins + "\n" + playerInfo.X + "\n" + playerInfo.Z + "\n" + "Level: " + playerInfo.Level;
    }
}
