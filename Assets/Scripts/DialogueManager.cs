using Ink.Runtime;
using Ink.UnityIntegration;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink")]
    [SerializeField] private TextAsset inkJSON;
    [Header("Dialogue UI")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    //[SerializeField] private Button nextButton;
    [Header("Choice UI")]
    [SerializeField] private Transform choiceContainer;
    [SerializeField] private Button choicePrefab;
    [Header("Typing Effect")]
    [SerializeField] private float typeSpeed = 0.04f;

    [SerializeField] private CharacterManager characterManager;
    private string fullDialogueText;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private Story story;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        story = new Story(inkJSON.text);

        //nextButton.onClick.AddListener(NextDialogue);
        ShowDialogue();
    }
    void Update()
    {

        bool spacePressed = Keyboard.current != null &&
       Keyboard.current.spaceKey.wasPressedThisFrame;

        bool mousePressed = Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame;

        if (spacePressed || mousePressed)
        {
            NextDialogue();
        }
    }
    void NextDialogue()
    {
        if (story.currentChoices.Count > 0)
        {
            return;
        }
        if (isTyping)
        {
            SkipTyping();
            return;
        }
        if (story.canContinue)
        {
            ShowDialogue();
        }
    }
    void ShowDialogue()
    {
        //del old choices
        ClearChoices();
        while (story.canContinue)
        {
            string line = story.Continue().Trim();
            HandleInkTag();
            if (!string.IsNullOrEmpty(line))
            {
                DisplayDialogue(line);
                break;
            }
        }
        //display choices if any
        if (story.currentChoices.Count > 0)
        {

            ShowChoices();

        }
        //else
        //{
        //    nextButton.gameObject.SetActive(true);
        //}
    }
    void DisplayDialogue(string line)
    {
        //name: text
        int index = line.IndexOf(':');
        if (index >= 0)
        {
            //Erik: Hello there!
            //index(:)= 5 ,0 - 5 = Erik, 6 - end = Hello there!
            string characterName = line.Substring(0, index).Trim();
            nameText.text = characterName;
            fullDialogueText = line.Substring(index + 1).Trim();

        }
        else
        {
            nameText.text = "";
            fullDialogueText = line;

        }
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        typingCoroutine = StartCoroutine(TypeText(fullDialogueText));

    }
    void ShowChoices()
    {
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            int choiceIndex = i;
            Button choiceButton = Instantiate(choicePrefab, choiceContainer);
            choiceButton.GetComponentInChildren<TMP_Text>().text = story.currentChoices[i].text;
            //player click choice 
            choiceButton.onClick.AddListener(()
                => OnChoiceSelected(story.currentChoices[choiceIndex]));
        }
    }
    void OnChoiceSelected(Choice choice)
    {
        // Hide all choices 
        foreach (Transform child in choiceContainer)
        {
            child.gameObject.SetActive(false);
        }
        // Tell the story to choose this choice
        story.ChooseChoiceIndex(choice.index);
        //display the next line of dialogue
        ShowDialogue();
    }
    void ClearChoices()
    {
        foreach (Transform child in choiceContainer)
        {
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }
    }
    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = text;
        dialogueText.maxVisibleCharacters = 0;
        dialogueText.ForceMeshUpdate();
        int totalVisibleCharacters = dialogueText.textInfo.characterCount;

        for (int i = 0; i < totalVisibleCharacters; i++)
        {
            dialogueText.maxVisibleCharacters = i + 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;
        typingCoroutine = null;
    }
    void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        dialogueText.maxVisibleCharacters = int.MaxValue;
        isTyping = false;
    }

    void HandleInkTag()
    {
        foreach (string tag in story.currentTags)
        {
            string[] parts = tag.Split(':');

            string key = parts[0].Trim().ToLower();

            switch (key)
            {
                case "show":
                    if (parts.Length >= 3)
                    {
                        string characterId = parts[1].Trim();
                        string position = parts[2].Trim();

                        string expression = parts.Length >= 4
                            ? parts[3].Trim()
                            : "normal";

                        characterManager.ShowCharacter(
                            characterId,
                            position,
                            expression
                        );
                    }
                    break;

                case "hide":
                    if (parts.Length >= 2)
                    {
                        string characterName = parts[1].Trim();

                        characterManager.HideCharByName(
                            characterName
                        );
                    }
                    break;

                case "hideall":
                    characterManager.HideAll();
                    break;

                default:
                    Debug.LogWarning("Unknown Ink Tag: " + tag);
                    break;
            }
        }
    }

}

