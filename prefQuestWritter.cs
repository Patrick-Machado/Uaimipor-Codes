using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefQuestWritter : MonoBehaviour
{
    GameObject InventoryRef; ItensController go;
    [SerializeField] Image iconImage;
    [SerializeField] Text text;

    public SaveLoad.QuestID It;
    int completed = 0;//0=nao completada,1=completada

    public void triggerDrawA(SaveLoad.QuestID que)
    {
        Debug.Log("trigeredDraw");
        InventoryRef = GameObject.FindWithTag("Inventory");
        if (InventoryRef == null)
        {
            Debug.Log("InventoryRef continua nulo");
        }
        if (que == null)
        {
            Debug.Log("Objeto QUE e nulo !!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if(que.enumIndex==1) { completed = 1; Debug.Log("true"); } //SaveLoad.QuestID.questProgress.Completed) { completed = 1;Debug.Log("true"); } 
        Debug.Log(completed);
        iconImage.sprite = InventoryRef.gameObject.GetComponent<SpriteRefs>().ListaOthers[completed];//];
        It = que;
        
        Invoke("DrawOnClick", 0);//teste*/
    }
    public void DrawOnClick()
    {
        if (SaveLoad.saverData[0].Language == false)
        { text.text = It.NAME_PT; }
        else { text.text = It.NAME_EN; }
        //if (!canclik) return;
        if (It == null)
        {
            Debug.Log("O item chamado é nulo!");
            return;
        }
        Debug.Log("DrawOnClick");
        InventoryRef = GameObject.FindWithTag("Inventory");
        go = InventoryRef.GetComponent<InventoryController>().Main_Quests_Head.GetComponent<ItensController>();
        Text name = go.Name_Iten;
        Text description = go.Descritption_Iten;
        Sprite image = InventoryRef.GetComponent<SpriteRefs>().ListaOthers[completed];
        if (SaveLoad.saverData[0].Language == false)//pt
        {
            name.text = It.NAME_PT; 
            go.Descritption_Iten.text = It.DESCRIPTION_PT;
        }
        else if (SaveLoad.saverData[0].Language == true)//en
        {
            name.text = It.NAME_EN;
            go.Descritption_Iten.text = It.DESCRIPTION_EN;
        }
        InventoryRef.GetComponent<InventoryController>().Main_Quests_Head.GetComponent<ItensController>().Main_Icone.GetComponent<Image>().sprite = image;

    }
}
