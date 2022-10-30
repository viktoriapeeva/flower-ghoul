using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
      new public string name = "New Quest";
      public string description = "Default description";
      public string nextQuest = "next";
      public GameObject progressSign;
      public ProgressState state = ProgressState.NotStarted;
      public bool requiredActionsCompleted;
      public enum ProgressState
        {
            NotStarted, InProgress, Completed
        }


}
