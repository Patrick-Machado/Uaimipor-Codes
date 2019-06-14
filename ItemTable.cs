using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTable : MonoBehaviour
{
    public SaveLoad.Item newItem;
    //---------------------------------------------COMPORTAMENTOS PADRÃO-----------------------------------------------------
    public void ChangeAtt(int ConstrucID)
    {
        SaveLoad.Item newLockedItem = new SaveLoad.Item();

        //Potion
        /*if (ConstrucID == 0)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Madeira";//<-
            newLockedItem.NAME_EN = "Madeira";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "PT Descrição";
            newLockedItem.DESCRIPTION_EN = "EN Description";
            newLockedItem.ICONTYPEID = 0;
            newItem = newLockedItem;
        }*/
        if (ConstrucID == 0)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Pedra de mão";//<-
            newLockedItem.NAME_EN = "Hand Stone";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            //newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "Pedras que cabem na mão, podem ser usadas para construir uma Solução.";
            newLockedItem.DESCRIPTION_EN = "Stones that fits in the hand, can be used to build a Solution";
            newLockedItem.ICONTYPEID = 0;
            newItem = newLockedItem;

        }
        if (ConstrucID == 1)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Pedra Fina";//<-
            newLockedItem.NAME_EN = "Smooth Stone";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            //newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "Pedras que de tamanho pequeno, podem ser usadas para construir uma Solução.";
            newLockedItem.DESCRIPTION_EN = "Very small and tiny stones, can be used to build a Solution";
            newLockedItem.ICONTYPEID = 1;
            newItem = newLockedItem;
        }
        if (ConstrucID == 2)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Planta";//<-
            newLockedItem.NAME_EN = "Plant";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            //newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "Planta que pode ser usada para construir uma Solução.";
            newLockedItem.DESCRIPTION_EN = "Plant that can be used to build a Solution";
            newLockedItem.ICONTYPEID = 2;
            newItem = newLockedItem;
        }
        if (ConstrucID == 3)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Folhagem";//<-
            newLockedItem.NAME_EN = "Dry Leaves";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            //newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "Folhas secas que podem ser usadas para construir uma Solução.";
            newLockedItem.DESCRIPTION_EN = "Dry leaves that can be used to build a Solution";
            newLockedItem.ICONTYPEID = 3;
            newItem = newLockedItem;
        }
        if (ConstrucID == 4)
        {
            newLockedItem.ID = ConstrucID;//<-
            newLockedItem.NAME_PT = "Pedra de mão";//<-
            newLockedItem.NAME_EN = "Hand Stone";//<-
            newLockedItem.AMOUNT = 0;//<-
            newLockedItem.ISTACKABLE = true;
            //newLockedItem.TYPE = 4;//lenha
            newLockedItem.VALUE = 1;//<-
            newLockedItem.DESCRIPTION_PT = "Pedras que cabem na mão, podem ser usadas para construir uma Solução.";
            newLockedItem.DESCRIPTION_EN = "Stones that fits in the hand, can be used to build a Solution";
            newLockedItem.ICONTYPEID = 0;
            newItem = newLockedItem;

        }

        //#Nota: usar mesma estrutura acima para fazer outros itens
    }

    

    //---------------------------------------------COMPORTAMENTOS ÚNICOS-----------------------------------------------------
}

