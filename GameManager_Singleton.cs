using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Singleton : MonoBehaviour
{
    private static GameManager_Singleton instance = null;
    public GameObject Player; public DialogWriter MessageWindow;
    public Icon_Manager IconManager;
    public GameObject inventoryCtrlScptOnGO;
    public GameObject Frog;
    public Audio_Master Audio_Master_Scpt;

    public int temporarayItensCount = 0;
    public int temporarySolutionsSaverCount = 0;
    public bool tutorialColetandoSapoDone = false;
    public bool waterIsClear = false;
    public bool canPlay = true;

    [SerializeField] List<GameObject> WaterGos = new List<GameObject>();
    // Game Instance Singleton
    public static GameManager_Singleton Instance
    {
        get
        {
            return instance;
        }
    }
    public void ClearWater()
    {
        waterIsClear = true;
        WaterGos[0].SetActive(false); WaterGos[2].SetActive(true); WaterGos[4].SetActive(true);
        WaterGos[1].SetActive(true); WaterGos[3].SetActive(false); WaterGos[5].SetActive(false);

    }
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);


        if(SaveLoad.TestFile()== true){
            SaveLoad.Load();
            SaveLoad.Save();
        }
        else
        {
            SaveLoad.saverData.Add(new SaveLoad.ProgressSaver());
            SaveLoad.Save(); SaveLoad.Load();
        }
        
        
    }

}
