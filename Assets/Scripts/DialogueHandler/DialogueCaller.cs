using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour
{
    public DialogueHandler dialogueHandler;
    public int DialogoIndex;

    void Start()
    {
        StartCoroutine(WaitForMessage());
    }

    IEnumerator WaitForMessage()
    {
        yield return new WaitForSeconds(5f);
        llamarMensaje();
    }
    private void llamarMensaje()
    {
        dialogueHandler.CallDialogue(DialogoIndex, 0);

    }
}
