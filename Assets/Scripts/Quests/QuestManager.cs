using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Animator playerAnimator;
    public Quest quest;
    public Transform questmarkHolder;
    public DialogueTrigger triggerDialogue;
    public bool requiredActions= false;
    private GameObject nearTo;
    public delegate void OnQuestChanged();
    public OnQuestChanged OnQuestChangedCallback;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        triggerDialogue = gameObject.GetComponent<DialogueTrigger>();
        OnQuestChangedCallback += CheckState;
        CheckState();
    }
    private void FixedUpdate()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.Q))
        {
            StartQuest();
            Debug.Log("Key is pressed! Wait for Interaction...");
            nearTo = null;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            nearTo = other.gameObject;

        }
    }

      public  void StartQuest()
      {
      
        //  playerAnimator.SetBool("isTalking", true);
      
            Debug.Log("Checking progress in start quest");
            triggerDialogue.TriggerDialogue();
            StartCoroutine(ProgressQuest());



    }
      IEnumerator WaitForAnimationToFinish()
      {
            Debug.Log("Coroutine started");
            yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length + playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            playerAnimator.SetBool("isPicking", false);
            ProgressQuest();
      }
    IEnumerator ProgressQuest()
      {
        yield return new WaitUntil(() => DialogueManager.started == false);
        if (quest.state == Quest.ProgressState.InProgress && requiredActions)
        {
            FinishQuest();
        }
        else
        {
            quest.state = Quest.ProgressState.InProgress;
            if (OnQuestChangedCallback != null)
            {
                OnQuestChangedCallback.Invoke();
            }

        }

    }
      void FinishQuest()
      {
        //something
        quest.state = Quest.ProgressState.Completed;
        if (OnQuestChangedCallback != null)
        {
            OnQuestChangedCallback.Invoke();
        }
    }
    
    void CheckState()
    {
        Debug.Log("Checking state");
       if (quest.state == Quest.ProgressState.NotStarted)
        {
            Destroy(quest.progressSign);
            quest.progressSign = Instantiate(Resources.Load("QuestUI/exclamation", typeof(GameObject)),questmarkHolder) as GameObject;
        }
       else if (quest.state == Quest.ProgressState.InProgress)
        {
            Destroy(quest.progressSign);
            quest.progressSign=Instantiate(Resources.Load("QuestUI/questionmark", typeof(GameObject)), questmarkHolder) as GameObject;
        }
        else if (quest.state == Quest.ProgressState.Completed)
        {
            Destroy(quest.progressSign);
           
        }
    }
}
