using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    private void Awake()
    {
        if (Instance == null)
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
    public void OpenLevel()
    {
        
        SceneManager.LoadScene("Level_" + Progress.Instance.playerInfo.Level);
    }

    public void ToNextLevel()
    {
        Progress.Instance.playerInfo.Level++;
        Progress.Instance.Save();
        OpenLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToNextLevel();
        }
    }

}
