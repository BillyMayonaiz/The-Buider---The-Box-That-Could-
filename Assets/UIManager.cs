using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI maxCharacterText;
    public TMP_InputField nameInput;
    public TextMeshProUGUI nameInpurt;
    public TextMeshProUGUI currentPlayerText;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
           
    }

    public void ChangeTitleName(string playername)
    {
        nameInpurt.maxVisibleCharacters = 12;

        if (nameInpurt.textInfo.characterCount > 12)
        {
            maxCharacterText.gameObject.SetActive(true);
        }
        else 
        {
            titleText.text = "Builder " + playername + " and the Box that Could!";
            maxCharacterText.gameObject.SetActive(false);
        }
        
    }

    public void StartNew()
    {
        if (nameInpurt.textInfo.characterCount <= 12)
        {
            SceneManager.LoadScene(1);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        MainManager.Instance.SaveName();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            currentPlayerText.text = "Builder " + MainManager.Instance.playerName + ", get the box to the other side!";
        }
    }
}
