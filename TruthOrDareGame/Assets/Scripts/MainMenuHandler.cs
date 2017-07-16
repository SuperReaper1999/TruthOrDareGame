using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public InputField playerNameInput;

    public Text playerListTextbox;

    public Button addButton;

    // Use this for initialization.
    void Start() {
        GameMaster.players.Clear();
    }

    // Update is called once per frame.
    void Update() {
        if (playerNameInput.text == "" || playerNameInput.text == null) {
            addButton.interactable = false;
        }
        else {
            addButton.interactable = true;
        }
    }

    // This is the function that the play button calls.
    public void PlayButton() {
        SceneManager.LoadScene("MainScene");
    }

    // Responsible for adding players to the list and displaying them on the menu.
    public void AddPlayerToList() {
        addButton.interactable = false;
        //Debug.Log("Player added to list");
        GameMaster.players.Add(playerNameInput.text);
        playerListTextbox.text += playerNameInput.text + "\n";
        playerNameInput.text = "";
    }

}
