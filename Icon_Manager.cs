using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon_Manager : MonoBehaviour
{
    public List<Sprite> questIcons = new List<Sprite>();
    public List<Sprite> solutionsIcons = new List<Sprite>();
    public List<Sprite> itemIcons = new List<Sprite>();
    [SerializeField] GameObject IconImageBack;
    [SerializeField] GameObject IconImage;
    //GreenWater: //Color32(0,238,130,255); // 00EE82
    //YellowItem: //Color32(229,255,0,255) // E5FF00
    //BlueWater: //Color32(0,245,255,255) // 00F5FF 
    //DarkTrouble: //Color32(0,0,0,255) // 000000
    //white?: //Color32(255,255,255,255) // FFFFFF
    static class ColorByteEnum
    {
        public static Color32 GreenWater = new Color32 ( 0, 238, 130, 255 ); // 00EE82
        public static Color32 YellowItem = new Color32(229, 255, 0, 255);// E5FF00
        public static Color32 BlueWater = new Color32(0, 245, 255, 255); // 00F5FF
        public static Color32 DarkTrouble = new Color32(0, 0, 0, 255); //000000
        public static Color32 White = new Color32(255, 255, 255, 255);// FFFFFF


    }
    private void Awake()
    {
        //animationGO.GetComponent<Image>().color = ColorByteEnum.GreenWater; // 00EE82
        //animNormal();
    }
    void changeAuraColor(Color32 color)
    {
        IconImageBack.GetComponent<Image>().color = color;
    }
    void animNormal()
    {
        IconImage.GetComponent<Animator>().SetTrigger("RotIdle");
        IconImageBack.GetComponent<Animator>().SetTrigger("Glow");
        this.gameObject.GetComponent<Animator>().SetTrigger("UpAndDown");
    }
    public void hide()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("HideIcon");
    }
    public void setInvisible()
    {
        this.gameObject.SetActive(false);
    }
    void setImageIcon(Sprite x)
    {
        IconImage.GetComponent<Image>().sprite = x;
    }

    public void showAnimReceiveReward(int idIcone)
    {
        changeAuraColor(ColorByteEnum.YellowItem);
        setImageIcon(itemIcons[idIcone]);

    }
    public void showAnimReceiveQuest()
    {
        changeAuraColor(ColorByteEnum.White);
    }
    public void showAnimCompleteQuest()
    {
        changeAuraColor(ColorByteEnum.GreenWater);
    }
    public void showAnimReceiveSolution()
    {
        changeAuraColor(ColorByteEnum.BlueWater);
    }
}
