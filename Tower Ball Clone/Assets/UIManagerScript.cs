using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Image currentLevelIMG;
    public Text currentLevelTXT;

    public Image nextLevelIMG;
    public Text nextLevelTXT;

    public Slider slider;
    public Image sliderIMG;

    public GameObject ttp;

    int level;

    float totalObs;
    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");

        currentLevelTXT.text = level.ToString();
        nextLevelTXT.text = (level + 1).ToString();

        totalObs = GameObject.FindGameObjectsWithTag("Obstacle").Length;

        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        Color newColor1 = new Color(Random.value, Random.value, Random.value, 1.0f);

        currentLevelIMG.color = newColor;
        nextLevelIMG.color = newColor;

        sliderIMG.color = newColor1;
    }


    void Update()
    {      
        if (GameManagerScript.playerState == GameManagerScript.PlayerState.Playing)
        {
            ttp.active = false;
        }
        Debug.Log("Total ---->" + totalObs);
        Debug.Log("Oran ---->"+ BallScript.currentObs / totalObs);


        slider.value = BallScript.currentObs / totalObs;

    }
}
