 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public static class SaveLoad
{
    //SaveLoad.Inventory.
    //SaveLoad.Save();
    //SaveLoad.AddItemOnInventory(55);
    
    public static List<Item> inventoryData = new List<Item>();
    public static List<ProgressSaver> saverData = new List<ProgressSaver>();
    public static List<QuestID> questData = new List<QuestID>();
    public static List<Solutions> solutionsData = new List<Solutions>();
    public static List<ChatPtkObj> dialogosData = new List<ChatPtkObj>();

    [System.Serializable]
    public class Item
    {
        public int ID = 0;
        public string NAME_PT = "";
        public string NAME_EN = "";
        public int AMOUNT = 0;
        public bool ISTACKABLE = true;
        //public bool MANARECOVER = false;
        //public string IMG_Name;// path of icon
        public int TYPE;
        #region type_Description <=refatorar
        //1: Item, 2: Solution.
        #endregion
        public int ICONTYPEID = 0;// IconsTypes
        public int VALUE = 0;
        public string DESCRIPTION_PT = "";//Texto de referencia no inventário em Português.
        public string DESCRIPTION_EN = "";// Texto de referencia no inventário em Inglês.

    }

    [System.Serializable]
    public class DataThatWillBeSaved
    {
        public List<Item> inventoryData = new List<Item>();
        public List<ProgressSaver> saverData = new List<ProgressSaver>();
        public List<QuestID> questData = new List<QuestID>();
        public List<Solutions> solutionsData = new List<Solutions>();
        public List<ChatPtkObj> dialogosData = new List<ChatPtkObj>();
    }
    [System.Serializable]
    public class ProgressSaver
    {
        public int GameProgress = 0;
        public int Choices = 0;
        public int Level = 0;
        public int TeamMember = 1;// 2: + panqueca, 3: + Poderosa, 4: +Elf1e.
        public int itensShop = 0; //itens colecionavels (não tackables) armaduras, armas... 
        public int Gold = 0;
        public bool Language = false; // false = português, true = english 
        //public bool[] SwitchsSaved = new bool[] {/*0-pá*/ false, /*1-...*/ false, /*2-...*/ false, /*3-...*/ false,
        //                                        /*4-...*/ false, /*5-...*/ false, /*6-...*/ false};

    }

    //it's static so we can call it from anywhere
    public static void Save()
    {
        return;
        DataThatWillBeSaved data = new DataThatWillBeSaved();

        data.inventoryData = inventoryData;
        data.saverData = saverData;
        data.questData = questData;
        data.solutionsData = solutionsData;
        data.dialogosData = dialogosData;
        //------------------------------
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create("Assets/Scripts" + "/savedGame.txt"); //you can call it anything you want

        bf.Serialize(file, data);

        file.Close();

    }
    public static bool TestFile()
    {
        if (File.Exists("Assets/Scripts" + "/savedGame.txt"))
        {
            return true;
        }
        else{
            return false;
        }
    }
    public static void Load()
    {
        if (File.Exists("Assets/Scripts" + "/savedGame.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Assets/Scripts" + "/savedGame.txt", FileMode.Open);
            DataThatWillBeSaved data = (DataThatWillBeSaved)bf.Deserialize(file);

            saverData = data.saverData; //Language = saverData[0].Language;
            inventoryData = data.inventoryData;
            questData = data.questData;
            solutionsData = data.solutionsData;
            dialogosData = data.dialogosData;
            file.Close();
            //Debug.Log("Loaded Sucessfull");
        }

    }
    #region DialogObj
    [System.Serializable]
    public class ChatPtkObj
    {
        public int ChatID;
        public int progress = 0;
    }
    [System.Serializable]
    public class QuestID
    {
        public int QuestID_Class;
        public questProgress qProgress = questProgress.NotStarted;
        public int enumIndex =0;
        public enum questProgress
        {
            NotStarted, Started, HasAllRequests, Failed, Completed
        }
        public string DESCRIPTION_PT = "";//Texto de referencia no inventário em Português.
        public string DESCRIPTION_EN = "";// Texto de referencia no inventário em Inglês.
        public string NAME_PT = ""; public string NAME_EN = "";
    }
    [System.Serializable]
    public class Solutions
    {
        public string NAME_PT = "";
        public string NAME_EN = "";
        public int SolutionID_Class;
        public int icone;
        public string DESCRIPTION_PT = "";//Texto de referencia no inventário em Português.
        public string DESCRIPTION_EN = "";// Texto de referencia no inventário em Inglês.
        public enum solutionType
        {
            FossaVapotranspirante, CirculoDeBananeira
        }
        public void setDesc(solutionType type)
        {
            if(type == solutionType.FossaVapotranspirante)
            {
                DESCRIPTION_PT = "inserir descrição da fossa evapotranspiradora";
                DESCRIPTION_EN = "insert description here";
            }
            else if (type == solutionType.CirculoDeBananeira)
            {
                DESCRIPTION_PT = "inserir descrição do circulo de bananeira";
                DESCRIPTION_EN = "insert description here";
            }
        }
    }
    #endregion
    public static void AddItemOnInventory(int ItemID)
    {
        #region CriarItem
        //esse bloco abaixo cria a tabela e o item de acordo com os parametros da tabela
        ItemTable TabelaDeItens = new ItemTable();
        Item iTemp = new Item();
        TabelaDeItens.ChangeAtt(ItemID);
        iTemp = TabelaDeItens.newItem;
        //---------------------------------------------
        #endregion

        #region Validação

        if(SaveLoad.inventoryData!=null)//tem itens
        {
            Item tempItemObj = new Item();
            foreach (SaveLoad.Item element in SaveLoad.inventoryData)
            {
                if (element.ID == iTemp.ID)
                {
                    tempItemObj = element;
                }
            }
        
            if (tempItemObj.ID == TabelaDeItens.newItem.ID )//NAME = TabelaDeItens.newItem.NAME.ToString() }))//tem o item com nome procurado na lista?
            {
                if (tempItemObj.ID == iTemp.ID)
                {
                    if (tempItemObj.ISTACKABLE == true)//se o item for acumulativo{add+1 na quantidade}
                    {
                        tempItemObj.AMOUNT++;
                    }
                }
                else// se não tiver o item na lista{ add item }
                {
                    Debug.Log("ElseB");
                    iTemp.AMOUNT = 1;
                    inventoryData.Add(iTemp);
                }
            }
            else
            {
                //Debug.Log("ElseX");
                iTemp.AMOUNT = 1;
                inventoryData.Add(iTemp);
            }
            
        }
        else// n tem itens
        {
            Debug.Log("ElseC");
            iTemp.AMOUNT = 1;
            inventoryData.Add(iTemp);
        }

        //SaveLoad.Save();
        #endregion
    }
    public static void RemoveItemOnInventory(int ItemID)
    {
        #region Validação
        /*
        foreach (SaveLoad.Item element in SaveLoad.Inventory)
        {
            if (element.ID == ItemID && element.AMOUNT > 1)
            {
                if (element.AMOUNT > 1)
                {
                    if (element.ISTACKABLE == true)
                    {
                        element.AMOUNT--;
                    }
                    else// se não tiver o item na lista{ remove item }
                    {
                        Inventory.Remove(element);
                    }
                }
                else
                {
                    Inventory.Remove(element);
                }
            }
        }
        */
        if (SaveLoad.inventoryData != null)//tem itens
        {
            Item tempItemObj = new Item();
            int index=0;
            int objIndex = 0;
            foreach (SaveLoad.Item element in SaveLoad.inventoryData)
            {
                if (element.ID == ItemID)
                {
                    tempItemObj = element;
                    objIndex = index;
                }
                index++;
            }

            if (tempItemObj.ID == ItemID)//NAME = TabelaDeItens.newItem.NAME.ToString() }))//tem o item com nome procurado na lista?
            {
                if (tempItemObj.ID == ItemID)
                {
                    if (tempItemObj.ISTACKABLE == true)//se o item for acumulativo{add+1 na quantidade}
                    {
                        if (tempItemObj.AMOUNT > 1)
                        {
                            tempItemObj.AMOUNT--;
                        }
                        else
                        {
                            inventoryData.RemoveAt(objIndex);
                        }
                    }
                }
                else// se não tiver o item na lista{ add item }
                {
                    Debug.Log("Item n existe");
                }
            }
            else
            {
                Debug.Log("Item n existe");
            }

        }
        else// n tem itens
        {
            Debug.Log("Item n existe");

        }
        //SaveLoad.Save();
        #endregion
    }
}