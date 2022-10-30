using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerUI : MonoBehaviour
{
    public GameObject dialogueUI;
    // Start is called before the first frame update
    public void EnableUI()
    {
        dialogueUI.SetActive(!dialogueUI.activeSelf);
    }
}
