using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unitsmovement : MonoBehaviour
{

    public GameControls gameControls;
    private Camera cam;
    public LayerMask groudLayer;

    private void Awake()
    {
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {

        if (gameControls.selectedUnits != null && Input.GetMouseButtonDown(1))
        {
            int x = 0;
            int z = 0;

            foreach (var gameobject in gameControls.selectedUnits)
            {
                if (x == 4)
                {
                    x = 0;
                    z++;
                }

                gameobject.GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(x * 3.5f, 0, z * 3.5f));
                x++;
            }
           
        }





        // pokud je nejaka jednotka nakliknuta a zraoven hrac klika pravym tlacitkem se na dany bod pohnou vsechny jednotky
      /*  if (gameControls.selectedUnits != null && Input.GetMouseButtonDown(1))
        {
            
            int nummber = gameControls.selectedUnits.Count;
            Debug.Log("pocet ulozenych " + nummber);
            Debug.Log("jmeno ulozeneho " + gameControls.selectedUnits[0]);
            if (nummber <= 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == nummber - 1)
                    {
                        gameControls.selectedUnits[i].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(i * 2.5f, 0, 0));
                        break;
                    }
                    else
                    {
                        gameControls.selectedUnits[i].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(i * 2.5f, 0, 0));

                    }
                }
            }

            else if (nummber <= 10)
            {
                float y = 0f;
 
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j == nummber - 1)
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                            break;
                        }
                        else
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                        }
                    }

                    y += 2.5f;
                }
            }

            else if (nummber <= 18)
            {
                float y = 0f;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (j == nummber - 1)
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                            break;
                        }
                        else
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                        }
                    }

                    y += 2.5f;
                }
            }

            else if (nummber <= 32)
            {
                float y = 0f;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == nummber - 1)
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                            break;
                        }
                        else
                        {
                            gameControls.selectedUnits[j].GetComponent<NavMeshAgent>().SetDestination(GetPoint() + new Vector3(j * 2.5f, y, 0));
                        }
                    }

                    y += 2.5f;
                } 
        } 
                  
          
        }*/
    }






    private Vector3 GetPoint()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 mousePosition = cam.ScreenToWorldPoint(screenPosition);

        RaycastHit hit;

        Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, groudLayer);

        return hit.point;

    }
}
