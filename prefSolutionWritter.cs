using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefSolutionWritter : MonoBehaviour
{
    GameObject InventoryRef; ItensController go;
    public Image iconImage;

    public SaveLoad.Solutions So;
   
    public void triggerDraw(SaveLoad.Solutions sol)
    {
        Debug.Log("trigeredDraw_Solution");
        InventoryRef = GameObject.FindWithTag("Inventory");
        if (InventoryRef == null)
        {
            Debug.Log("InventoryRef continua nulo");
        }
        iconImage.sprite = InventoryRef.gameObject.GetComponent<SpriteRefs>().ListaSolutions[sol.icone];//];

        
        So = sol;
        Invoke("DrawOnClick", 0);//teste

    }
    public void DrawOnClick()
    {
        //if (!canclik) return;
        if (So == null)
        {
            Debug.Log("O item chamado é nulo!");
            return;
        }
        Debug.Log("DrawOnClick");
        InventoryRef = GameObject.FindWithTag("Inventory");
        go = InventoryRef.GetComponent<InventoryController>().Main_Solutions_Head.GetComponent<ItensController>();
        Text name = go.Name_Iten;
        Text description = go.Descritption_Iten;
        Sprite image = InventoryRef.GetComponent<SpriteRefs>().ListaSolutions[So.icone];
        
        if(So.icone == 0)//id da solução
        {
            So.setDesc(SaveLoad.Solutions.solutionType.FossaVapotranspirante);
        }
        else if(So.icone == 1)//id da solução
        {
            So.setDesc(SaveLoad.Solutions.solutionType.CirculoDeBananeira);
        }

        if (SaveLoad.saverData[0].Language == false)//pt
        {
            name.text = So.NAME_PT;
            go.Descritption_Iten.text = So.DESCRIPTION_PT;
        }
        else if (SaveLoad.saverData[0].Language == true)//en
        {
            name.text = So.NAME_EN;
            go.Descritption_Iten.text = So.DESCRIPTION_EN;
        }
        InventoryRef.GetComponent<InventoryController>().Main_Solutions_Head.GetComponent<ItensController>().Main_Icone.GetComponent<Image>().sprite = image;

    }
}
