using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saneamentoPlace : MonoBehaviour
{
    [SerializeField] GameObject bananas; bool wait = false; bool done=false;
    private void OnMouseDown()
    {
        if (GameManager_Singleton.Instance.canPlay == false)
        {
            return;
        }
        if (wait || done)
        {
            return;
        }
        if (Vector3.Distance(GameManager_Singleton.Instance.Player.transform.position, this.gameObject.transform.position) > 7)
        {
            Debug.Log("Muito longe");
            return;
        }
        wait = true;

        /*bool pedrafina = false, plantas = false, folhassecas = false, pedrademao = false;
        foreach (SaveLoad.Item i in SaveLoad.inventoryData)
        {
            if (i.ID == 1)//pedra fina
            {
                if (i.AMOUNT >= 15)
                {
                    pedrafina = true;
                }
            }
            if (i.ID == 2)//plantas
            {
                if (i.AMOUNT >= 4)
                {
                    plantas = true;
                }
            }
            if (i.ID == 3)//Folhas secas
            {
                if (i.AMOUNT >= 5)
                {
                    folhassecas = true;
                }
            }
            if (i.ID == 4)//Pedra de mao
            {
                if (i.AMOUNT >= 5)
                {
                    folhassecas = true;
                }
            }
        }//checa se tem requisitos
        if(pedrafina==true && plantas==true && folhassecas == true && pedrademao == true)
        {
            foreach (SaveLoad.Item i in SaveLoad.inventoryData)//remover custo
            {
                if (i.ID == 1)//pedra fina
                {
                    if (i.AMOUNT >= 15)
                    {
                        for (int j = 0; j < 15; j++)
                        {

                            SaveLoad.RemoveItemOnInventory(1);
                        }
                    }
                }
                if (i.ID == 2)//plantas
                {
                    if (i.AMOUNT >= 4)
                    {
                        for (int j = 0; j < 4; j++)
                        {

                            SaveLoad.RemoveItemOnInventory(2);
                        }
                    }
                }
                if (i.ID == 3)//Folhas secas
                {
                    if (i.AMOUNT >= 5)
                    {
                        for (int j = 0; j < 5; j++)
                        {

                            SaveLoad.RemoveItemOnInventory(3);
                        }
                    }
                }
                if (i.ID == 4)//Pedra de mao
                {
                    if (i.AMOUNT >= 5)
                    {
                        for (int j = 0; j < 5; j++)
                        {

                            SaveLoad.RemoveItemOnInventory(4);
                        }
                    }
                }
            }//remove custo*/

        if (GameManager_Singleton.Instance.temporarayItensCount >=4) {
            removerCusto();

            bananas.SetActive(true);
            done = true;
            GameManager_Singleton.Instance.Audio_Master_Scpt.SFX_2D[3].Play();
            GameManager_Singleton.Instance.Audio_Master_Scpt.SFX_2D[4].Play();
            GameManager_Singleton.Instance.Audio_Master_Scpt.SFX_2D[5].Play();
            GameManager_Singleton.Instance.temporarayItensCount = 0;
            GameManager_Singleton.Instance.temporarySolutionsSaverCount++;
            GameManager_Singleton.Instance.tutorialColetandoSapoDone = true;

            if (GameManager_Singleton.Instance.temporarySolutionsSaverCount == 1)
            {
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Clear();
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Excelente! Faltam 7! Explore pelos recursos e implemente as Soluções restantes!");
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Toque duas vezes na mochila em suas costas para abri-la!");
                GameManager_Singleton.Instance.MessageWindow.npcTalking = GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>();
                GameManager_Singleton.Instance.MessageWindow.StartDialog();
                GameManager_Singleton.Instance.Frog.GetComponent<Follow>().toLocalPoint = false;
            }
            else if(GameManager_Singleton.Instance.temporarySolutionsSaverCount > 1 && GameManager_Singleton.Instance.temporarySolutionsSaverCount <8)
            {
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Clear();
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Excelente! Faltam "+(8- GameManager_Singleton.Instance.temporarySolutionsSaverCount) +"! Continue assim!");
                GameManager_Singleton.Instance.MessageWindow.npcTalking = GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>();
                GameManager_Singleton.Instance.MessageWindow.StartDialog();
                GameManager_Singleton.Instance.Frog.GetComponent<Follow>().toLocalPoint = false;
            }
            else if (GameManager_Singleton.Instance.temporarySolutionsSaverCount >=8)
            {
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Clear();
                GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>().ListaFalas.Add("Muito obrigado por nos ajudar a clarear a água! Somos eternamente gratos!");
                GameManager_Singleton.Instance.MessageWindow.npcTalking = GameManager_Singleton.Instance.Frog.GetComponent<Fala_NPC>();
                GameManager_Singleton.Instance.MessageWindow.StartDialog();
                GameManager_Singleton.Instance.Frog.GetComponent<Follow>().toLocalPoint = false;
                GameManager_Singleton.Instance.ClearWater();
            }

        }
        else
        {
            Debug.Log("Não tem requisitos");
        }
        

        
        
        
    }
    void removerCusto()

    {
        Debug.Log("removendo custo");
        for (int j = 0; j < 15; j++)
        {

            SaveLoad.RemoveItemOnInventory(1);
        }
        for (int j = 0; j < 4; j++)
        {

            SaveLoad.RemoveItemOnInventory(2);
        }
        for (int j = 0; j < 5; j++)
        {

            SaveLoad.RemoveItemOnInventory(3);
        }
        for (int j = 0; j < 5; j++)
        {

            SaveLoad.RemoveItemOnInventory(4);
        }
    }
}
