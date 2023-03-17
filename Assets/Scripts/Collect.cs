using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    //private int score = 0;
    public Text scoreText;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Progress.Instance.playerInfo.Coins++;
            scoreText.text = Progress.Instance.playerInfo.Coins.ToString();
            Destroy(gameObject);
        }
    }
}
