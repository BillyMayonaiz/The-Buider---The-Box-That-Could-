using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerExit()
    {
        if (gameObject.CompareTag("Player"))
        {

        }
    }
}
