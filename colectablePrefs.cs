using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectablePrefs : MonoBehaviour
{
    [SerializeField] AudioSource coletado1, coletado2;
    [SerializeField] int indiceItemTabela = 0;
    [SerializeField] int quantity = 0; bool wait = false;
    private void OnMouseDown()
    {
        if (GameManager_Singleton.Instance.canPlay == false)
        {
            return;
        }
        if (wait)
        {
            return;
        }
        if (Vector3.Distance(GameManager_Singleton.Instance.Player.transform.position, this.gameObject.transform.position) >7)
        {
            return;
        }
        wait = true;
        if (coletado2 != null)
        {
            coletado1.Play(); coletado2.Play();
        }
        else
        {
            coletado1.Play();
        }
        for(int i = 0; i < quantity; i++)
        {
            
           SaveLoad.AddItemOnInventory(indiceItemTabela); 
            
        }
        
        Invoke("selfDestruct",0.5f);

        //SaveLoad.inventoryData.ad
    }
    void selfDestruct()
    {
        wait = false;
        GameManager_Singleton.Instance.temporarayItensCount++;
        if (!GameManager_Singleton.Instance.tutorialColetandoSapoDone)
        {
            if (GameManager_Singleton.Instance.temporarayItensCount >= 4)
            {
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Clear();
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Muito bom! Agora me siga!");
                GameManager_Singleton.Instance.MessageWindow.npcTalking = GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>();
                GameManager_Singleton.Instance.MessageWindow.StartDialog();

                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Clear();
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Toque nesse chão cinza!");

                GameManager_Singleton.Instance.Frog.GetComponent<Follow>().waypointNum = 0;
                GameManager_Singleton.Instance.Frog.GetComponent<Follow>().toLocalPoint = true;
            }
        }
        Destroy(this.gameObject);
    }
}
