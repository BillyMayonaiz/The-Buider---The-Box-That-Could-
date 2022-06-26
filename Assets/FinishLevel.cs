using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLevel : MonoBehaviour
{

    public TextMeshProUGUI finishLevelText;
    public Button tryAgainButton;
    public Button quitButton;

    public DogMovement dogMovement;
    public CatMovement catMovement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dog")
        {
            dogMovement.isGameWon = true;
            catMovement.isGameWon = true;
            tryAgainButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            finishLevelText.gameObject.SetActive(true);
        }
    }

    
}
