using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickObject : MonoBehaviour
{
    // promene
    public bool selected = false;
    NavMeshAgent agent;

    Camera cam;
    GameControls gameControls;
    public LayerMask groudLayer;


    private void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        GameObject ob = GameObject.Find("GameControl");
        gameControls = ob.GetComponent<GameControls>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        // poznava zda je stisknuto prave tlacitko mysi
        if (Input.GetMouseButtonDown(1) && selected)
        {
            float t = 0;
                      
            foreach (var gameobject in gameControls.selectedUnits)
            {


                agent.SetDestination(GetPoint() + new Vector3(t,0,0));
             //   t = t + 10;
            }
            
        }
        // poznava zda je stisknuto leve tlacitko mysi
        if (Input.GetMouseButtonDown(0))
        {
         //   SelectUnit();
        }

       

    }
    //ziska bod kde je mys
    private Vector3 GetPoint()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 mousePosition = cam.ScreenToWorldPoint(screenPosition);

        RaycastHit hit;

        Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, groudLayer);

        return hit.point;

    }

    // urci zda jednotka, ktera ma tento kod byla nakliknuta
    /* private void SelectUnit()
     {

         RaycastHit hit;
         Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f);
        // print(hit.transform.name);
         if (hit.transform.name == this.transform.name)
         {
             selected = true;

         }
         else
         {
             selected = false;

         }*/
    //  }

    public void SetPath()
    {

    }

}
