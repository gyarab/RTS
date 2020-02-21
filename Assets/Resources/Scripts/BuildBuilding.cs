using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    GameObject Building;
    // Start is called before the first frame update
    void Start()
    {
         Building = Resources.Load<GameObject>("Prefab/Building") as GameObject;
        Debug.Log(Building);
    }

    // Update is called once per frame
   public void Update()
    {

        Debug.Log("ahoj");
     /*   Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Instantiate(Building);
        Building.transform.position = mousePos;
    */}

   public void Build()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        Instantiate(Building);


        Debug.Log( "pozice x " + Input.mousePosition.x);
        Debug.Log("pozice y " + Input.mousePosition.y);
        Debug.Log("pozice z " + Input.mousePosition.z);
    }


}
