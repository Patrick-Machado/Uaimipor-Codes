using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string esperando;
    public string loading;
    [SerializeField]
    string DescricaoQuest;
    [SerializeField]
    string DescrptionQuest;
    public
    List<string> ListaConclusao;
    public
    List<string> listConclusion;
    int questID;
    [SerializeField] int IconeQuest;
    [SerializeField] bool isSwitchTriggerQuest = false, isDecreaseType = false, isRewardType = false, isSolutionRewardType = false, isCompletableQuest = true;
    [SerializeField] int decreseitemID, qtdD, rewardItemID, qtdR;
    public int solutionTypeInstance;// CirculoDeBananeira, FossaVapotranspirante

    public void setQuestID(int id)
    {
        questID = id;
    }
    public void addQuest()
    {
        SaveLoad.QuestID qid = new SaveLoad.QuestID();
        qid.QuestID_Class = questID; qid.DESCRIPTION_PT = DescricaoQuest; qid.DESCRIPTION_EN = DescrptionQuest;
        qid.qProgress = SaveLoad.QuestID.questProgress.Started;
        SaveLoad.questData.Add(qid);
    }
    public bool hasRequest()
    {
        if (isDecreaseType)
        {
            foreach (SaveLoad.Item element in SaveLoad.inventoryData)
            {
                if (element.ID == decreseitemID)// tem item
                {
                    if (element.AMOUNT >= qtdD)// quantidade do item é a requerida
                    {
                        for (int i = 0; i < qtdD; i++)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public bool checkCompleted()
    {

        foreach(SaveLoad.QuestID qid in SaveLoad.questData)
        {
            if(qid.QuestID_Class == questID)
            {
                if(qid.qProgress == SaveLoad.QuestID.questProgress.Completed)
                {
                    return true;
                }
            }
        }

        return false;
    }
    public void completeQuest()
    {
        if (isDecreaseType)
        {
            foreach (SaveLoad.Item element in SaveLoad.inventoryData)
            {
                if (element.ID == decreseitemID)// tem item
                {
                    if (element.AMOUNT >= qtdD)// quantidade do item é a requerida
                    {
                        for (int i = 0; i < qtdD; i++)
                        {
                            SaveLoad.RemoveItemOnInventory(decreseitemID);
                        }
                    }
                }
            }
        }

        if (isRewardType)
        {
            for (int i = 0; i < qtdR; i++)
            {
                SaveLoad.AddItemOnInventory(rewardItemID);
            }
            GameManager_Singleton.Instance.IconManager.showAnimReceiveReward(IconeQuest);
            
        }
        else if (isSolutionRewardType)
        {
            bool hassolution =false;
            foreach(SaveLoad.Solutions si in SaveLoad.solutionsData)
            {
                if(si.SolutionID_Class == questID)
                {
                    hassolution = true;
                }
            }
            if (!hassolution)
            {
                SaveLoad.Solutions s = new SaveLoad.Solutions();

                if(solutionTypeInstance == 0)s.setDesc(SaveLoad.Solutions.solutionType.FossaVapotranspirante);
                if (solutionTypeInstance == 1) s.setDesc(SaveLoad.Solutions.solutionType.CirculoDeBananeira);
            }
            
        }
        if (isCompletableQuest)
        {
            bool hasquest2 = false;
            foreach (SaveLoad.QuestID qid in SaveLoad.questData)
            {
                if (qid.QuestID_Class == questID)
                {
                    hasquest2 = true;
                    qid.qProgress = SaveLoad.QuestID.questProgress.Completed;
                }
            }
            if (!hasquest2)
            {
                Debug.Log("ERROR: Quest Not Found.");
            }
        }
        SaveLoad.Save();
    }
}
