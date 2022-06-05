using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJsonFile;
    [SerializeField]
    private Story currentStory;

    public TextMeshProUGUI textBox;
    public TextMeshProUGUI nameTag;

    [SerializeField] private GameObject instPanel;
    [SerializeField] private GameObject chapterFirst;
    [SerializeField] private GameObject shopPanel;

    void Start()
    {
        LoadStory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }
    void LoadStory()
    {

        currentStory = new Story(inkJsonFile.text);
        currentStory.BindExternalFunction("Name", (string charName) => ChangeName(charName));
    }

    public void DisplayNextLine()
    {

        if (currentStory.canContinue)
        {

            string text = currentStory.Continue();
            text = text?.Trim();
            textBox.text = text;

        }
        else 
        {
            //textBox.text = " ";
            shopPanel.SetActive(true);
            instPanel.SetActive(true);

            chapterFirst.SetActive(false);
        }

    }

    public void ChangeName(string name)
    {

        string currentSpeaker = name;
        nameTag.text = currentSpeaker;
    
    }
}
