using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float cameraspeed = 10f;
    public Transform Player;


    void LateUpdate()
    {
        Vector3 playerpos = new Vector3(Player.position.x, Player.position.y, -15f);
        transform.position = Vector3.Slerp(transform.position, playerpos, cameraspeed * Time.deltaTime);
    }
}
