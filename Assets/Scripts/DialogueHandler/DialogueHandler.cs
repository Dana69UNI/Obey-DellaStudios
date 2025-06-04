using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] dialogos;
    public float textSpeed;
   

    public bool InDialogue;
    private int index;
    private int contEnd;
   

    void Start()
    {
       
        textComp.text = string.Empty;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (index < contEnd)
        {

            StartCoroutine(NextLine());
                
        }
        else 
        {
            StartCoroutine(CloseDialogue());
        }
       

    }
    public void CallDialogue(int Index, int Cont)
    {
        gameObject.SetActive(true);
        index = Index;
        contEnd = Index + Cont;
        InDialogue = true;
        StartCoroutine(TypeLine(Index));
       
       
    }

    IEnumerator NextLine()
    {
        yield return new WaitForSeconds(10f);
        index++;
        textComp.text = string.Empty;
        StartCoroutine(TypeLine(index));
    }

    IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(10f);
        textComp.text = string.Empty;
        gameObject.SetActive(false);
    }

    IEnumerator TypeLine(int index)
    {
        foreach(char c in dialogos[index].ToCharArray())
        {
            textComp.text += c;

            yield return new WaitForSeconds(textSpeed);
        }
        
    }
}
