using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 force;
    bool isCollide;
    public GameObject[] obs;

    float x1, y, z;

    public static int currentObs = 0;
    private void OnCollisionEnter(Collision collision)
    {

        x1 = Random.Range(-30, 30);
        y = Random.Range(10, 20);
        z = Random.Range(20, 40);

        force = new Vector3(x1, y, z);


        if (GameManagerScript.playerState == GameManagerScript.PlayerState.Playing && collision.transform.tag == "enemy")
        {
            // Bazen colliderEnter 2 kere çalıştığı için isCollide bool'u kullanarak üst üste çalışmasını engelledim. Ilk çarpışmadan sonra collider'ı kapatarak da çözülebilirdi.

            if (!isCollide)
            {
                Destroy(gameObject);

                GameObject x = collision.transform.parent.gameObject;
                x.AddComponent<Rigidbody>();
                x.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

                Destroy(x, 1);
                GameObject turner = GameObject.FindGameObjectWithTag("Turner");

                turner.transform.position -= new Vector3(0, 1, 0);

                currentObs++;

                isCollide = true;               
            }            
        }

        if (GameManagerScript.playerState == GameManagerScript.PlayerState.Playing && collision.transform.tag == "plane")
        {
            Destroy(gameObject);

            GameManagerScript.playerState = GameManagerScript.PlayerState.Death;

            Debug.Log("Death");

            BallScript.currentObs = 0;
        }

        try
        {
            if (GameManagerScript.playerState == GameManagerScript.PlayerState.Playing && collision.transform.parent.name == "Finish")
            {

                Destroy(gameObject);
                GameManagerScript.playerState = GameManagerScript.PlayerState.Death;
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                Debug.Log("Finish");

                BallScript.currentObs = 0;


            }
        }
        catch { }
        

    }

    
}
