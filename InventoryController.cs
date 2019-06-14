using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject Joystick;
    #region referencias
    [SerializeField]
    GameObject prefItem, prefSol, prefQUE_;
    [SerializeField]
    GameObject contentItem, contentSol, contentQue;

    public GameObject Main_Itens_Head;
    [SerializeField]
    GameObject NameItem_Text, Items_Description_Text, Icone_Big_Item_Img;

    public GameObject Main_Solutions_Head;
    public GameObject Main_Quests_Head;
    public GameObject Main_BackPack_Head;

    [SerializeField] AudioSource[] backpackSFX = new AudioSource[3];

    bool openedABackPackTab = true;
    #endregion

    public bool onContent0 = true; //false = content1
    public void closeInventoryTab()
    {
        
        foreach (Transform it in contentItem.transform)
        {
            Destroy(it.gameObject);
        }
        foreach (Transform it in contentQue.transform)
        {
            Destroy(it.gameObject);
        }
        foreach (Transform it in contentSol.transform)
        {
            Destroy(it.gameObject);
        }
        GameManager_Singleton.Instance.canPlay = true; openedABackPackTab = false;
        Joystick.SetActive(true);
        closeItens();closeQuests();closeSolutions();
        Main_BackPack_Head.SetActive(false);
    }

    public void ResetBagAnim()
    {
        openedABackPackTab = false;
        this.gameObject.GetComponent<Animator>().SetTrigger("Reset");
    }
    public void closeItens()
    {
        Main_Itens_Head.SetActive(false); ResetBagAnim();


    }
    public void closeQuests()
    {
        Main_Quests_Head.SetActive(false);ResetBagAnim();
        
    }
    public void closeSolutions()
    {
        Main_Solutions_Head.SetActive(false); ResetBagAnim();


    }
    // Start is called before the first frame update
    void Awake()
    {
        /*
        ////////teste
        for(int i=0; i < 4; i++) ///////////////////////////////          ITENS
        {
            SaveLoad.Item tempItem = new SaveLoad.Item();
            tempItem.AMOUNT = 0; tempItem.ICONTYPEID = (i ); tempItem.ID = 0;
            if (i == 0)
            {
                tempItem.NAME_PT = "Pedra de mão"; tempItem.NAME_EN = "Hand Stone";
                tempItem.DESCRIPTION_PT = "Pedras que cabem na mão, podem ser usadas para construir uma Solução.";
                tempItem.DESCRIPTION_EN = "Stones that fits in the hand, can be used to build a Solution";
                tempItem.ISTACKABLE = true;
            }
            else if (i == 1)
            {
                tempItem.NAME_PT = "Pedra de Fina"; tempItem.NAME_EN = "Smooth Stone";
                tempItem.DESCRIPTION_PT = "Pedras que de tamanho pequeno, podem ser usadas para construir uma Solução.";
                tempItem.DESCRIPTION_EN = "Very small and tiny stones, can be used to build a Solution";
                tempItem.ISTACKABLE = true;
            }
            else if (i == 2)
            {
                tempItem.NAME_PT = "Planta"; tempItem.NAME_EN = "Plant";
                tempItem.DESCRIPTION_PT = "Planta que pode ser usada para construir uma Solução.";
                tempItem.DESCRIPTION_EN = "Plant that can be used to build a Solution";
                tempItem.ISTACKABLE = true;
            }
            else if (i == 3)
            {
                tempItem.NAME_PT = "Folhagem"; tempItem.NAME_EN = "Dry Leaves";
                tempItem.DESCRIPTION_PT = "Folhas secas que podem ser usadas para construir uma Solução.";
                tempItem.DESCRIPTION_EN = "Dry leaves that can be used to build a Solution";
                tempItem.ISTACKABLE = true;
            }
            tempItem.TYPE = 1;
            SaveLoad.inventoryData.Add(tempItem);

        }*/
        for (int i = 0; i < 2; i++)///////////////////////////////          SOLUTIONS
        {
            SaveLoad.Solutions tempItem = new SaveLoad.Solutions();
            
            if (i  == 0)
            {
                tempItem.icone = 0;
                tempItem.NAME_PT = "Fossa Evapotranspiradora"; tempItem.NAME_EN = "Evapotranspiratory Tank";
                tempItem.DESCRIPTION_PT = "Solução Fossa Evapotranspiradora pode ser construída com 5xPedras de Mão, 5xFolhagens, 4xPlantas, 15xPedras Finas.";
                tempItem.DESCRIPTION_EN = "Solution Evapotranspiratory Tank can be builden with 5xHand Stones, 5xDryLeaves, 4xPlants, 15xSmooth Stones.";
            }
            else if(i==1)
            {

                tempItem.icone = 1;
                tempItem.NAME_PT = "Círculo de Bananeira"; tempItem.NAME_EN = "Banana Circle";
                tempItem.DESCRIPTION_PT = "Solução Círculo de Bananeira pode ser construída com 5xPedras de Mão, 5xFolhagens, 4xPlantas, 15xPedras Finas.";
                tempItem.DESCRIPTION_EN = "Solution Banana Circle can be builden with 5xHand Stones, 5xDryLeaves, 4xPlants, 15xSmooth Stones.";

            }
            SaveLoad.solutionsData.Add(tempItem);
        }
        for (int i = 0; i < 1; i++)///////////////////////////////          QUESTS
        {
            SaveLoad.QuestID tempItem = new SaveLoad.QuestID();

            if (i== 0)
            {
                tempItem.qProgress = SaveLoad.QuestID.questProgress.Started;tempItem.enumIndex = 1;
                tempItem.NAME_PT = "Purifique o rio!"; tempItem.NAME_EN = "Purify the river";
                tempItem.DESCRIPTION_PT = "Implemente todas as 8 Soluções!";
                tempItem.DESCRIPTION_EN = "Implement all the 8 Solutions!";
                //Debug.Log("PAR");
            }
            
            SaveLoad.questData.Add(tempItem);
        }
        
        /*TESTSaveLoad.AddItemOnInventory(0); SaveLoad.AddItemOnInventory(1); SaveLoad.AddItemOnInventory(2); SaveLoad.AddItemOnInventory(3);
        /*/SelfUpdate();
    }
    public void SelfUpdate()
    {
        QuestInventoryConstructor();
        ItemInventoryConstructor(); SolutionInventoryConstructor();
    }
    private void ItemInventoryConstructor()
    {
        //int contador = 0;
        foreach (SaveLoad.Item item in SaveLoad.inventoryData)// escreve graficos dados dos itens visualmente
        {
            GameObject childObject = Instantiate(prefItem) as GameObject;
            prefItem.GetComponent<prefItemWriter>().triggerDraw(item);
            childObject.transform.parent = contentItem.transform;
            childObject.gameObject.transform.localScale = new Vector3(1, 1, 1);
            //contador++;
        }
    }
    private void SolutionInventoryConstructor()
    {
        foreach (SaveLoad.Solutions solItem in SaveLoad.solutionsData)// escreve graficos dados dos itens visualmente
        {
            GameObject childObject = Instantiate(prefSol) as GameObject;
            prefSol.GetComponent<prefSolutionWritter>().triggerDraw(solItem);
            childObject.transform.parent = contentSol.transform;
            childObject.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void QuestInventoryConstructor()
    {
        foreach (SaveLoad.QuestID queItem in SaveLoad.questData)// escreve graficos dados dos itens visualmente
        {
            GameObject childObject = Instantiate(prefQUE_) as GameObject;
            prefQUE_.GetComponent<prefQuestWritter>().triggerDrawA(queItem);
            childObject.transform.parent = contentQue.transform;
            childObject.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }
    public void Ended_OpenBookCover()
    {

    }
    public void Ended_UpAba()
    {
        
        Main_Itens_Head.SetActive(true);
    }
    public void Ended_UpBook()
    {
        
        Main_Solutions_Head.SetActive(true);

    }
    public void Ended_UpPapper()
    {
        
        Main_Quests_Head.SetActive(true);
    }
    public void Open_Quests()
    {
        if (openedABackPackTab) return;
        if (Main_BackPack_Head.active == false) { return; }
        openedABackPackTab = true;
        this.gameObject.GetComponent<Animator>().SetTrigger("UpPapper");
        backpackSFX[0].Play();
    }
    public void Open_Solutions()
    {
        if (openedABackPackTab) return;
        if (Main_BackPack_Head.active == false) { return; }
        openedABackPackTab = true;
        this.gameObject.GetComponent<Animator>().SetTrigger("UpBook");
        backpackSFX[1].Play();
    }
    public void Open_Itens()
    {
        if (openedABackPackTab) return;
        if (Main_BackPack_Head.active == false) { return; }
        openedABackPackTab = true;
        this.gameObject.GetComponent<Animator>().SetTrigger("UpAba");
        backpackSFX[2].Play();
    }
    public void setOpenedTabTrue()
    {
        openedABackPackTab = true;
    }
    public void setOpenedTabOff()
    {
        openedABackPackTab = false;
    }
}
