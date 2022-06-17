using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject[] Players;

    [SerializeField] public GameObject CurrentPlayer;

    private FollowPlayer followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].GetComponent<PlayerController>().enabled = false;
        }

        CurrentPlayer = Players[0];

        followPlayer = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
    }

    //deactivate current player movement script, and set new selected player as CurrentPlayer
    public void ChangePlayer(GameObject player)
    {
        CurrentPlayer.GetComponent<PlayerController>().enabled = false;
        CurrentPlayer = player;

        followPlayer.player = CurrentPlayer;
    }
}
