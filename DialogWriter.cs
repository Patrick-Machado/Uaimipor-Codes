using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogWriter : MonoBehaviour
{
    public List<string> Dialogo;
    public Fala_NPC npcTalking; public Quest chatfromquest;
    public GameObject foto;
    public AudioSource audioBook;
    [SerializeField]
    Text windowText;
    Animator dialogAnim;
    int contador = 0;
    bool canskipMessage = false;

    private void Start()
    {
        dialogAnim = this.gameObject.GetComponent<Animator>();
    }

    public void write(string text)
    {
        windowText.text = text;
    }

    public virtual void StartDialog()
    {
        npcTalking.interacting = true;
        if(SaveLoad.saverData[0].Language == false)//português
            Dialogo = npcTalking.ListaFalas;
        if (SaveLoad.saverData[0].Language == true)//english
            Dialogo = npcTalking.ListChats;
        write(Dialogo[0]); contador = 0;
        dialogAnim.SetTrigger("ShowDialog");
    }
    public virtual void StartDialogQuestEnded()
    {
        npcTalking.interacting = true;
        if (SaveLoad.saverData[0].Language == false)//português
            Dialogo = chatfromquest.ListaConclusao;
        if (SaveLoad.saverData[0].Language == true)//english
            Dialogo = chatfromquest.listConclusion;
        write(Dialogo[0]); contador = 0;
        dialogAnim.SetTrigger("ShowDialog");
    }
    public virtual void StartDialogQuestLoading()
    {
        npcTalking.interacting = true;
        Dialogo = null;
        if (SaveLoad.saverData[0].Language == false)//português
            Dialogo[0] = chatfromquest.esperando;
        if (SaveLoad.saverData[0].Language == true)//english
            Dialogo[0] = chatfromquest.loading;
        write(Dialogo[0]); contador = 0;
        dialogAnim.SetTrigger("ShowDialog");
    }
    public void onBtnPressed()
    {
        if (canskipMessage)
        {

            if (contador + 1 < Dialogo.Count)//pode prosseguir
            {
                contador++;
                write(Dialogo[contador]);

            }
            else // chegou no final das falas
            {
                EndDialog();
            }
        }
        
    }

    public void EndDialog()
    {
        //Invoke("resetFalas", 3f);
        contador = 0;
        audioBook.Play();
        dialogAnim.SetTrigger("HideDialog");
        npcTalking.ended();
        //npcTalking = null;

    }
    #region resetfalas
    void resetFalas()
    {
        //Dialogo = null;
        Dialogo.RemoveAll(removeanystring);
        Dialogo.Add("...");
    }
    private static bool removeanystring(string s)
    {
        return true;
    }

    void CAN_skipmessages()
    {
        canskipMessage = true;
        audioBook.Play();
    }
    void CANNOT_skipmessages()
    {
        canskipMessage = false;
    }
    #endregion
}
