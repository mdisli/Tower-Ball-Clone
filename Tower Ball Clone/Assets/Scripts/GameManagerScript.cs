using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static PlayerState playerState;

    public GameObject ttp;
    public enum PlayerState
    {
        Preparing,
        Playing,
        Death,
        Finish
    }
    private void Start()
    {
        playerState = PlayerState.Preparing;

    }
    private void Update()
    {
        if (playerState == PlayerState.Preparing && Input.GetMouseButtonUp(0))
        {
            playerState = PlayerState.Playing;
        }

        if (playerState == PlayerState.Death || playerState == PlayerState.Finish)
        {
            BallScript.currentObs = 0;

            SceneManager.LoadScene(0);
            
        }
    }
}
