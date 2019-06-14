using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class prefItemWriter : MonoBehaviour
{
    GameObject InventoryRef; ItensController go;
    public Image iconImage;
    public Text number;
    
    //public Text name;
    public SaveLoad.Item It;
    bool canclik = false;
    public void triggerDraw(SaveLoad.Item it)
    {
        Debug.Log("trigeredDraw");
        InventoryRef = GameObject.FindWithTag("Inventory");
        if (InventoryRef == null)
        {
            Debug.Log("InventoryRef continua nulo");
        }
        /*else
        {
            GameManager_Singleton.Instance.inventoryCtrlScptOnGO = InventoryRef;
        }*/
            iconImage.sprite = InventoryRef.gameObject.GetComponent<SpriteRefs>().ListaTypes[it.ICONTYPEID];//];
       

        if (it.ISTACKABLE)
        {
            number.text = it.AMOUNT.ToString();
        }
        else
        {
            Destroy(number.gameObject);
        }
        It = it;
        Invoke("DrawOnClick", 0);//teste
        //canclik = true;
    }
    public void DrawOnClick()
    {
        //if (!canclik) return;
        if (It == null)
        {
            Debug.Log("O item chamado é nulo!");
            return;
        }
        Debug.Log("DrawOnClick");
        InventoryRef = GameObject.FindWithTag("Inventory");
        go = InventoryRef.GetComponent<InventoryController>().Main_Itens_Head.GetComponent<ItensController>();
        Text name = go.Name_Iten;
        Text description = go.Descritption_Iten;
        Sprite image = InventoryRef.GetComponent<SpriteRefs>().ListaTypes[It.ICONTYPEID];
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
        InventoryRef.GetComponent<InventoryController>().Main_Itens_Head.GetComponent<ItensController>().Main_Icone.GetComponent<Image>().sprite = image;

    }


}
