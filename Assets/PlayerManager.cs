using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject CurrentPlayer;

    private FollowPlayer followPlayer;

    private bool isPrimary = true;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
    }

    //deactivate current player movement script, and set new selected player as CurrentPlayer
    public void ChangePlayer()
    {
        if (isPrimary)
        {
            GameObject.Find("Cat").GetComponent<CatMovement>().enabled = false;
            isPrimary = false;
            GameObject.Find("Dog").GetComponent<DogMovement>().enabled = true;

            followPlayer.player = GameObject.Find("Dog");
        }
        else if (!isPrimary)
        {
            GameObject.Find("Cat").GetComponent<CatMovement>().enabled = true;
            isPrimary = true;
            GameObject.Find("Dog").GetComponent<DogMovement>().enabled = false;

            followPlayer.player = GameObject.Find("Cat");
        }

    }
}
