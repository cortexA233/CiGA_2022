using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Index : MonoBehaviour
{
    Button newGameButton;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        newGameButton = transform.Find("NewGameButton").GetComponent<Button>();

        newGameButton.onClick.AddListener(NewGame);
    }

    void NewGame()
    {
        SceneManager.LoadScene("level");
    }
}
