using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Interactable
{
    public Pathway pathway;
    public Animator transition;
    public float transitionTime = 1f;
    public override void Interact()
    {
        base.Interact();

        //StartCoroutine(WaitForAnimationToFinish());
        ChangeScene();
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(pathway.targetScene);

    }
    IEnumerator WaitForAnimationToFinish()
    {
        transition.SetTrigger("Start");
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(transitionTime);
        ChangeScene();
    }

}
