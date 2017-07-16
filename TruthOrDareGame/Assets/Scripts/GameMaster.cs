using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static List<string> players = new List<string>();

    private int currentPlayerIndex = 0;

    public Text currentPlayerNameText;
    public GameObject mainPanel;
    public GameObject truthOrDarePanel;
    public GameObject forfeitPanel;

    public Text task;
    public Text forfeit;

    public List<string> truths = new List<string>();
    public List<string> dares = new List<string>();
    public List<string> forfeits = new List<string>();

    // Chooses the current player.
    public void ChooseCurrentPlayer() {
        if (currentPlayerIndex < players.Count) {
            currentPlayerNameText.text = players[currentPlayerIndex];
            currentPlayerIndex += 1;
            //Debug.Log("Current player chosen without changing index to 0");
        }
        else {
            currentPlayerIndex = 0;
            currentPlayerNameText.text = players[currentPlayerIndex];
            currentPlayerIndex += 1;
        }
        //Debug.Log(currentPlayerNameText.text + currentPlayerIndex);
    }

    // Use this for initialization.
    void Start() {
        ChooseCurrentPlayer();
    }

    // Update is called once per frame.
    void Update() {

    }

    string ChooseRandomPlayer()
    {

        List<string> tempList = new List<string>();

        for (int i = 0; i < players.Count; i++)
        {
            if (currentPlayerNameText.text != players[i])
            {
                tempList.Add(players[i]);
            }
        }

        int chosenRandomPlayer = Random.Range(0, tempList.Count);
        Debug.Log(tempList[chosenRandomPlayer]);
        return tempList[chosenRandomPlayer];
    }

    // Called When the Complete button is pressed.
    public void CompleteButton() {
        truthOrDarePanel.SetActive(true);
        ChooseCurrentPlayer();
        mainPanel.SetActive(false);
        forfeitPanel.SetActive(false);
    }

    // TODO : Fix the picking of random players names.

    // Called When the Forfeit button is pressed.
    public void ForfeitButton()
    {
        forfeitPanel.SetActive(true);
        truthOrDarePanel.SetActive(false);
        mainPanel.SetActive(false);
        // Do forfeit picking things here.
        int chosenForfeit = Random.Range(0, forfeits.Count);
        string currentForfeit = forfeits[chosenForfeit];
        if (currentForfeit.Contains("{NameOfPlayerHere}")) {
            currentForfeit.Replace("{NameOfPlayerHere}", "Test Player Name");
            Debug.Log(currentForfeit);
        }
        forfeit.text = currentForfeit;
    }

    // Called When the Truth button is pressed.
    public void TruthButton()
    {
        mainPanel.SetActive(true);
        truthOrDarePanel.SetActive(false);
        forfeitPanel.SetActive(false);
        // Do Truth picking things here.
        int chosenTruth = Random.Range(0, truths.Count);
        task.text = truths[chosenTruth];
        if (task.text.Contains("{NameOfPlayerHere}"))
        {
            task.text.Replace("{NameOfPlayerHere}", ChooseRandomPlayer());
        }
    }

    // Called When the Dare button is pressed.
    public void DareButton()
    {
        mainPanel.SetActive(true);
        truthOrDarePanel.SetActive(false);
        forfeitPanel.SetActive(false);
        // Do Dare picking things here.
        int chosenDare = Random.Range(0, dares.Count);
        task.text = dares[chosenDare];
        if (task.text.Contains("{NameOfPlayerHere}"))
        {
            task.text.Replace("{NameOfPlayerHere}", ChooseRandomPlayer());
        }
    }

}
