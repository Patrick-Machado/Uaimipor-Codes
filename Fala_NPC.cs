using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fala_NPC : MonoBehaviour
{
    public List<string> ListaFalas;
    public List<string> ListChats;
    public int numberOfDialogLists = 0;
    [SerializeField] int DialogID ; // id é inicializado de acordo com a instancia do mesmo dentro gameobject pai dos NPCS 
    public bool isSavableDialog;
    float distance; bool canInteractWithMe = false; public bool interacting = false;

    [SerializeField] bool Isthisatutorial = false;[SerializeField] bool IsThisTutorial_Sapo = false;

    DialogWriter DialogWriterWindow;

    public AudioSource correctsfx;
    public GameObject cubetutorial;

    private void Start()
    {
        DialogWriterWindow = GameManager_Singleton.Instance.MessageWindow;
        
    }
    private void FixedUpdate()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if(distance < 4)
        {
            canInteractWithMe = true;
        }
        else
        {
            canInteractWithMe = false;
            
        }

    }
    public void SetID(int id)
    {
        DialogID = id;
    }
    private void OnMouseDown()
    {
        if(canInteractWithMe == true && GameManager_Singleton.Instance.canPlay == true && !interacting)
        {
            bool theresthisquest = false;
            set_tutorialFaceIcon();
            if (gameObject.GetComponent<Quest>())
            {
                foreach (SaveLoad.QuestID qid in SaveLoad.questData)
                {
                    if (qid.QuestID_Class == DialogID)
                    {
                        theresthisquest = true;
                        interacting = true;
                        GameManager_Singleton.Instance.canPlay = false;

                        if (qid.qProgress == SaveLoad.QuestID.questProgress.Completed)
                        {
                            
                            DialogWriterWindow.npcTalking = this.gameObject.GetComponent<Fala_NPC>();
                            DialogWriterWindow.chatfromquest = this.gameObject.GetComponent<Quest>();
                            DialogWriterWindow.StartDialogQuestEnded();
                        }
                        else if (qid.qProgress == SaveLoad.QuestID.questProgress.Started)
                        {
                            if (this.gameObject.GetComponent<Quest>().hasRequest())
                            {
                                DialogWriterWindow.npcTalking = this.gameObject.GetComponent<Fala_NPC>();

                                this.gameObject.GetComponent<Quest>().completeQuest();
                            }
                            else
                            {
                                DialogWriterWindow.npcTalking = this.gameObject.GetComponent<Fala_NPC>();
                                DialogWriterWindow.chatfromquest = this.gameObject.GetComponent<Quest>();
                                DialogWriterWindow.StartDialogQuestLoading();
                            }
                        }
                        else if (qid.qProgress == SaveLoad.QuestID.questProgress.HasAllRequests)
                        {
                                DialogWriterWindow.npcTalking = this.gameObject.GetComponent<Fala_NPC>();
                                this.gameObject.GetComponent<Quest>().completeQuest();
                        }
                    }
                }
            }
            if (!theresthisquest)
            {
                interacting = true;
                GameManager_Singleton.Instance.canPlay = false;
                DialogWriterWindow.npcTalking = this.gameObject.GetComponent<Fala_NPC>();
                set_tutorialFaceIcon();
                DialogWriterWindow.StartDialog();
            }
        }
    }
    void set_tutorialFaceIcon()
    {
        if (Isthisatutorial)
        {
            GameManager_Singleton.Instance.MessageWindow.foto.gameObject.GetComponent<Image>().sprite = GameManager_Singleton.Instance.inventoryCtrlScptOnGO.GetComponent<SpriteRefs>().ListaOthers[2];

        }
        if (IsThisTutorial_Sapo)
        {
            GameManager_Singleton.Instance.MessageWindow.foto.gameObject.GetComponent<Image>().sprite = GameManager_Singleton.Instance.inventoryCtrlScptOnGO.GetComponent<SpriteRefs>().ListaOthers[3];

        }
    }
    public void ended()
    {
        GameManager_Singleton.Instance.canPlay = true;
        
        if (isSavableDialog)// é chat que salva?
        {
            bool haschatsaved = false;
            foreach(SaveLoad.ChatPtkObj dialogData in SaveLoad.dialogosData)// verificando se ja exxiste o ID salvo da conversa
            {
                if(dialogData.ChatID == DialogID)
                {
                    haschatsaved = true;
                }
            }
            if (!haschatsaved)
            {
                SaveLoad.ChatPtkObj a = new SaveLoad.ChatPtkObj();
                a.ChatID = DialogID;
                a.progress = 1;
                SaveLoad.dialogosData.Add(a);
            }
        }
        if (gameObject.GetComponent<Quest>()) // NPC tem quest attachado?
        {
            bool theresthisquest = false;
            foreach(SaveLoad.QuestID qid in SaveLoad.questData)
            {
                if(qid.QuestID_Class == DialogID)
                {
                    theresthisquest = true;
                }
            }
            if (!theresthisquest)
            {
                Quest q = gameObject.GetComponent<Quest>();
                q.setQuestID(DialogID); 
                q.addQuest();
            }
            
        }
        if (Isthisatutorial)
        {
            Isthisatutorial = false;
            ListaFalas = null;
            ListaFalas = new List<string>(1);
            ListaFalas.Add("...");
            GameManager_Singleton.Instance.IconManager.gameObject.SetActive(true);
            correctsfx.Play();
            GameManager_Singleton.Instance.IconManager.GetComponent<Animator>().SetTrigger("UpAndDown");
            //SaveLoad.solutionsData.Add();
            GameManager_Singleton.Instance.inventoryCtrlScptOnGO.GetComponent<InventoryController>().SelfUpdate();
        }
        if (IsThisTutorial_Sapo)
        {
            IsThisTutorial_Sapo = false;
            ListaFalas = null;
            ListaFalas =new List<string>(1);
            ListaFalas.Add("...");
            cubetutorial.gameObject.GetComponent<simplecollider>().blackscreen.gameObject.SetActive(true);
            cubetutorial.gameObject.GetComponent<simplecollider>().animtuto.gameObject.GetComponent<Animator>().SetTrigger("double");
            cubetutorial.gameObject.GetComponent<simplecollider>().animtuto.gameObject.GetComponent<Animator>().SetTrigger("double");
            cubetutorial.gameObject.GetComponent<simplecollider>().animtuto.gameObject.GetComponent<Animator>().SetTrigger("double");
            cubetutorial.gameObject.GetComponent<simplecollider>().blackscreen.gameObject.SetActive(false);
            Destroy(cubetutorial);
            GameManager_Singleton.Instance.canPlay = true;
        }
        interacting = false;
        SaveLoad.Save();
    }
}
