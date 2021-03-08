using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerScript : MonoBehaviour
{
    private Vector3 turn;
    public Vector3 turn1;
    void Update()
    {
        transform.rotation = Quaternion.Euler(turn);
        turn += turn1 * Time.deltaTime;
    }
}
