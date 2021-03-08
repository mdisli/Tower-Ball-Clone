using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreaterScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Obstacles;

    public int level;

    int obstacleNumber;
    public Vector3 startPos;
    public Vector3 startRot;



    private void Awake()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        obstacleNumber = (level * 2) + 10;
        for (int i = 0; i <= obstacleNumber; i++)        
        {
            GameObject obstacle = Instantiate(Obstacles[Random.Range(0, 2)], startPos, Quaternion.Euler(startRot));
            obstacle.transform.parent = GameObject.FindGameObjectWithTag("Turner").transform;
            obstacle.transform.tag = "Obstacle";
            startPos.y += 1f;
            startRot.y += 20f;
            if (i == obstacleNumber)
            {
                obstacle.name = "Finish";
            }
        }
    }


}
