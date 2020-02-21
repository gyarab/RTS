using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{

    GameObject SelUnit;
    RaycastHit hit;
    public List<Transform> selectedUnits = new List<Transform>();
    bool isDragging = false;
    Vector3 mousePosition;

    void Awake()
    {
        
    }

    private void OnGUI()
    {  
        if (isDragging)
        {
            Rect rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenReact(rect, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.blue);
        }

        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out hit))
            {
                if (!hit.transform.CompareTag("Unit"))
                {
                    DeselectUnits();
                }
                if (hit.transform.CompareTag("Unit") && (selectedUnits.Count == 0 || Input.GetKey(KeyCode.LeftShift)))
                {
                    SelectUnit(hit.transform, true);
                    Debug.Log(selectedUnits.Count);
                }

                else if (hit.transform.CompareTag("Unit"))
                {
                    DeselectUnits();
                    SelectUnit(hit.transform, true);
                    Debug.Log(selectedUnits.Count);
                }

                
                else 
                {
                    isDragging = true;   
                }

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging != false)
            {
                Debug.Log("smazano pri zvednuti klavesy");
                DeselectUnits();
            }
            
            

            foreach (var selectableObject in FindObjectsOfType<ClickObject>())
            {
                if (isWithinSelectBounds(selectableObject.transform))
                {
                    Debug.Log(selectableObject.transform.name);
                    selectableObject.GetComponent<ClickObject>().selected = true;
                    SelectUnit(selectableObject.transform, true);

                }
            }

            isDragging = false;
        }
    }


    private void SelectUnit(Transform unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect)
        {
            Debug.Log("vymazano");
            DeselectUnits();
        }
        Debug.Log("ulozeno");
        selectedUnits.Add(unit);
        unit.GetComponent<ClickObject>().selected = true;

    }

    private void DeselectUnits()
    {
        foreach (var unit in selectedUnits)
        {
            unit.GetComponent<ClickObject>().selected = false;
        }
        selectedUnits.Clear();
    }

    private bool isWithinSelectBounds(Transform transform)
    {
        if (!isDragging)
        {
            return false;
        }


        Camera camera = Camera.main;
        Bounds viewportBonds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return viewportBonds.Contains(camera.WorldToViewportPoint(transform.position));


    }

}
