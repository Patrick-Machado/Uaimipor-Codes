using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class simplecollider : MonoBehaviour
{
    public bool firstPart=false;
    public GameObject blackscreen;
    public GameObject animtuto;
    public GameObject sapo;
    public Text bs_text;
    public GameObject ball_tutorial, ball_tutorial_2;



    public void tutoLadoPARAtutocima()
    {
        if (firstPart)
        {
            return;
        }
        animtuto.GetComponent<Animator>().SetTrigger("cima");
        tutocimaPARAtutoLado();
    }
    public void tutocimaPARAtutoLado()
    {
        if (firstPart)
        {
            return;
        }
        animtuto.GetComponent<Animator>().SetTrigger("lado");
        tutoLadoPARAtutocima();
    }
    private void Awake()
    {
        animtuto.SetActive(true);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tutorialfunc(collision.gameObject);
        }
        if (collision.gameObject.tag == "Sapo")
        {
            tutorialfunc(collision.gameObject);
        }
    }*/
    void tutorialfunc(GameObject received)
    {
        if (received.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<TutorialControlle>().andou = true;
            firstPart = true;
            this.gameObject.GetComponentInParent<TutorialControlle>().correctaudio.Play();
            blackscreen.SetActive(false);
            sapo.SetActive(true);
            GameManager_Singleton.Instance.canPlay = false;
            animtuto.SetActive(false);
            GameManager_Singleton.Instance.canPlay = false;
        }
        if (received.gameObject.tag == "Sapo")
        {
            blackscreen.SetActive(true);
            //Destroy(collision.gameObject.GetComponent<SphereCollider>());
            Destroy(received.gameObject.GetComponent<Rigidbody>());
            bs_text.text = "Toque no Sapo para interagir!";
            if (ball_tutorial != null)
            {
                ball_tutorial.SetActive(false); //Debug.Log("ball_tutorial___________Ativo");
                ball_tutorial_2.SetActive(true);
            }
            GameManager_Singleton.Instance.canPlay = false;
            Invoke("turnoffbs", 3);
            GameManager_Singleton.Instance.inventoryCtrlScptOnGO.SetActive(true);

        }
    }
    Vector3 initialPlayerPos;
    Vector3 atualPlayerPos;
    private void Start()
    {
        initialPlayerPos = GameManager_Singleton.Instance.Player.transform.position;//new Vector3(39.3f, 18.5f, -21.6f);
    }
    private void FixedUpdate()
    {
        
        GameObject prot = GameManager_Singleton.Instance.Player;
        atualPlayerPos = GameManager_Singleton.Instance.Player.transform.position;
       // Debug.Log( GameManager_Singleton.Instance.Player.transform.position);
        if (Vector3.Distance(atualPlayerPos, initialPlayerPos)>1f)//(prot.transform.rotation.y > (-0.9831921f + 0.01f) || prot.transform.rotation.y < (-0.9831921f - 0.01f))
        {
            if (!firstPart)
            {
                //Debug.Log("trigeredplayertutorial___________");
                tutorialfunc(GameManager_Singleton.Instance.Player);
            }
        }
        //Debug.Log(Vector3.Distance(GameManager_Singleton.Instance.Frog.transform.position,atualPlayerPos));
        if(Vector3.Distance(GameManager_Singleton.Instance.Frog.transform.position, GameManager_Singleton.Instance.Player.transform.position) < 1.4f){
            tutorialfunc(GameManager_Singleton.Instance.Frog);
        }

    }
    public void SelfDestruct()
        {
             Destroy(this.gameObject);
        }
    void turnoffbs()
    {
        blackscreen.SetActive(false);
        GameManager_Singleton.Instance.canPlay = true;
    }
}
