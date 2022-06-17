using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Our Script Variables. Some are class variables, like GameObject, and some are Type Variables, like Vector3.
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -9);

    // Update is called once per frame
    void LateUpdate()
    {
        //offset camera position from player by adding a Vector3 offset every frame
        transform.position = player.transform.position + offset;
    }
}
