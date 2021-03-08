using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballSpeed;

    bool crRunning;
    private void Update()
    {
        if (GameManagerScript.playerState == GameManagerScript.PlayerState.Playing && Input.GetMouseButton(0))
        {
            if (!crRunning)
            {
                StartCoroutine(Shoot());
            }

        }
    }

    IEnumerator Shoot()
    {
        crRunning = true;
        GameObject ball2 = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        ball2.AddComponent<Rigidbody>();
        ball2.GetComponent<Rigidbody>().useGravity = false;
        ball2.GetComponent<Rigidbody>().AddForce(ballSpeed, ForceMode.Impulse);

        yield return new WaitForSeconds(.3f);
        crRunning = false;

    }
}
