using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
      public TextMeshProUGUI nameText;
      public TextMeshProUGUI dialogueText;
      public Animator anim;
      private Queue<string> sentences;
      public static bool started;
      public GameObject dialogueUI;
    public Button continueButton;

      void Start()
      {
        sentences = new Queue<string>();
        dialogueUI = GameObject.Find("Canvas").gameObject.transform.Find("DialogueBox").gameObject;
        anim = dialogueUI.GetComponent<Animator>();
        continueButton = dialogueUI.transform.Find("Box").gameObject.transform.Find("Continue").GetComponent<Button>();
        dialogueText =  dialogueUI.transform.Find("Box").gameObject.transform.Find("Description").GetComponentInChildren<TextMeshProUGUI>();
        nameText = dialogueUI.transform.Find("Box").gameObject.transform.Find("Name").GetComponentInChildren<TextMeshProUGUI>();

        continueButton.onClick.AddListener(DisplayNext);
    }
      public void StartDialogue(Dialogue dialogue)
      {
        dialogueUI.SetActive(true);
        started = true;
        anim.SetBool("IsOpen", true);
            nameText.text = dialogue.name;
            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
            {
                  sentences.Enqueue(sentence);
            }
            DisplayNext();
      }
      public void DisplayNext()
      {
            if (sentences.Count == 0)
            {
                  EndDialogue();
                  return;
            }
            string sentence = sentences.Dequeue();
            // dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
      }
      IEnumerator TypeSentence(string sentence)
      {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                  dialogueText.text += letter;
                  yield return null;
            }
      }
      void EndDialogue()
      {
        started = false;
        anim.SetBool("IsOpen", false);

        dialogueUI.SetActive(!dialogueUI.activeSelf);
    }
}
