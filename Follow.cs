using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Follow : MonoBehaviour
{
    public NavMeshAgent agent;
    bool imFar = false; int aim=0;
    PlayerFrogLocalsRefs scriptLocais;
    [SerializeField] Animator thiAnimator;
    [SerializeField] AudioSource[] frogSFX = new AudioSource[4];
    bool firstBool = false;

    public bool toLocalPoint = false;
    public int waypointNum = 0;
    public List<Transform> waypoints= new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        //assinlocal();
        scriptLocais = GameManager_Singleton.Instance.Player.GetComponent<PlayerFrogLocalsRefs>();
        randomizarObjetivo();
        
    }
    void randomcroack()
    {
        frogSFX[((int)Random.Range(0, 3))].Play();
        Invoke("randomcroack", (int)(Random.Range(0, 100)));
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CalcDistance());
        if (CalcDistance() > 1.31f)
        {
            imFar = true;
        }
        else { imFar = false; }
        if (toLocalPoint)
        {

            if (imFar == true)
            {
                thiAnimator.SetBool("Walking", true);
                agent.destination = waypoints[waypointNum].transform.position;
            }
            else
            {
                thiAnimator.SetBool("Walking", false);
                if (firstBool) { return; }
                firstBool = true;
                randomcroack();

            }
        }
        else
        {
            if (imFar == true)
            {
                thiAnimator.SetBool("Walking", true);
                agent.destination = GameManager_Singleton.Instance.Player.GetComponent<PlayerFrogLocalsRefs>().Locais[aim].transform.position;

            }
            else
            {
                thiAnimator.SetBool("Walking", false);
                if (firstBool) { return; }
                firstBool = true;
                randomcroack();

            }
        }
        
    }
    void randomizarObjetivo()
    {
        //Random.Range(0, scriptLocais.Locais.Length-1);
        Invoke("randomizarObjetivo", 4);
    }
    float CalcDistance()
    {
        return Vector3.Distance(GameManager_Singleton.Instance.Player.transform.position, this.gameObject.transform.position);
    }
}
