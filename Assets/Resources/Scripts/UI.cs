using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{

    Font ArialFont;
    private float angleX = 70;
    BuildBuilding Build = new BuildBuilding();

   



    // Start is called before the first frame update
    void Start()
    {
        Sprite UIbackgroud = Resources.Load<Sprite>("Sprites/Stone") as Sprite;



        ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject myGO;
        GameObject myText;
        Canvas myCanvas;
        Text text;
        RectTransform rectTransform;

        // Canvas
        myGO = new GameObject();
        myGO.name = "TestCanvas";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "wibble";

        text = myText.AddComponent<Text>();
        text.font = ArialFont;
        text.text = "ahoj";
        text.fontSize = 100;


        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);

        


        //panel

        GameObject LeftPanel = new GameObject();
        LeftPanel.transform.parent = myGO.transform;
        LeftPanel.name = "Panel";
        LeftPanel.AddComponent<CanvasRenderer>();
        LeftPanel.AddComponent<RectTransform>();
        LeftPanel.AddComponent<Image>();
        LeftPanel.GetComponent<Image>().sprite = UIbackgroud;
        LeftPanel.GetComponent<Image>().color = new Color (0,0,0,0.5f);
        LeftPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.33f, 0.33f);
        LeftPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
        LeftPanel.GetComponent<RectTransform>().pivot = new Vector2(0f, 0f);
        LeftPanel.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
        LeftPanel.GetComponent<RectTransform>().right = new Vector3(0f, 0f, 0f);
        LeftPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);



        GameObject MiddlePanel = new GameObject();
        MiddlePanel.transform.parent = myGO.transform;
        MiddlePanel.name = "Panel";
        MiddlePanel.AddComponent<CanvasRenderer>();
        MiddlePanel.AddComponent<RectTransform>();
        MiddlePanel.AddComponent<Image>();
        MiddlePanel.GetComponent<Image>().sprite = UIbackgroud;
        MiddlePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.8f);
        MiddlePanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.66f, 0.33f);
        MiddlePanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.33f, 0);
        MiddlePanel.GetComponent<RectTransform>().pivot = new Vector2(0f, 0f);
        MiddlePanel.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
        MiddlePanel.GetComponent<RectTransform>().right = new Vector3(0f, 0f, 0f);
        MiddlePanel.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        MiddlePanel.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);

        GameObject RightPanel = new GameObject();
        RightPanel.transform.parent = myGO.transform;
        RightPanel.name = "Panel";
        RightPanel.AddComponent<CanvasRenderer>();
        RightPanel.AddComponent<RectTransform>();
        RightPanel.AddComponent<Image>();
        RightPanel.GetComponent<Image>().sprite = UIbackgroud;
        RightPanel.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        RightPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 0.33f);
        RightPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.66f, 0);
        RightPanel.GetComponent<RectTransform>().pivot = new Vector2(0f, 0f);
        RightPanel.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
        RightPanel.GetComponent<RectTransform>().right = new Vector3(0f, 0f, 0f);
        RightPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        RightPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);




        //button 
        GameObject myButton = new GameObject();
        myButton.transform.parent = LeftPanel.transform;
        myButton.name = "Button";
        myButton.AddComponent<RectTransform>();
        myButton.AddComponent<Button>();
        myButton.AddComponent<Image>();
        myButton.GetComponent<Button>().targetGraphic = myButton.GetComponent<Image>();
        myButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        myButton.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
        myButton.GetComponent<RectTransform>().pivot = new Vector2(0f, 0f);
        myButton.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
        myButton.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        myButton.GetComponent<Button>().onClick.AddListener(() => {Build.Update() ; });

        // vytvori eventsystem k fungovani tlacitka
        GameObject listener = new GameObject("EventSystem", typeof(EventSystem));
        listener.AddComponent<StandaloneInputModule>();
        listener.AddComponent<BaseInput>();
        //  myButton.GetComponent<RectTransform>().right = new Vector3(0f, 0f, 0f);
        // myButton.GetComponent<RectTransform>().rect.Set(0f, 0f, 0f, 0f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*  void CreateCanvas(GameObject Node, GameObject canvas, string name)
      {
          Node.name = name + "Pos";
          canvas.transform.parent = Node.transform;
          Node.transform.rotation = Quaternion.Euler(angleX, 0, 0);
          canvas.name = name;
          canvas.AddComponent<Canvas>();
          canvas.AddComponent<GraphicRaycaster>();
          canvas.AddComponent<CanvasScaler>();
          Canvas can = canvas.GetComponent<Canvas>();
          canvas.AddComponent<HorizontalLayoutGroup>();

          canvas.GetComponent<HorizontalLayoutGroup>().spacing = 10;

          can.renderMode = RenderMode.WorldSpace;
          can.worldCamera = GetComponent<Camera>();

          canvas.transform.rotation = Quaternion.Euler(angleX, 0, 0);

          Node.SetActive(false);


      }

      void CreateText(GameObject text, GameObject parent, string name)
      {
          text.name = name + "Text";


          text.transform.parent = parent.transform;

          text.AddComponent<RectTransform>();
          text.AddComponent<Text>().text = name;
          text.GetComponent<Text>().font = ArialFont;
          text.GetComponent<Text>().fontSize = 20;
          text.GetComponent<Text>().color = Color.black;
          text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
          RectTransform textSize = text.GetComponent<RectTransform>();
          textSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
          textSize.sizeDelta = new Vector2(0f, 0f);
          textSize.localScale = new Vector3(1f, 1f, 1f);
          textSize.anchorMin = new Vector2(0f, 0f);
          textSize.anchorMax = new Vector2(1f, 1f);
      }

      void CreatePanel(GameObject panel, GameObject parent, string name, Sprite sprite)
      {
          panel.transform.parent = parent.transform;

          panel.name = name;
          panel.AddComponent<CanvasRenderer>();
          panel.AddComponent<RectTransform>();
          panel.AddComponent<Image>();

          Image PanelImage = panel.GetComponent<Image>();

          PanelImage.sprite = sprite;

          PanelImage.color = new Color32(255, 255, 255, 255);


      }*/




   /* void CreateButton(GameObject canvas, GameObject button, GameObject text, string ButtText)
    {

        button.transform.parent = canvas.transform;


        button.name = "Butt" + ButtText;
        button.tag = "Button";
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();

        Button buttonB = button.GetComponent<Button>();





        RectTransform buttonRectT = button.GetComponent<RectTransform>();
        buttonRectT.sizeDelta = new Vector2(500f, 500f);
        buttonRectT.localScale = new Vector3(1f, 1f, 1f);
        buttonRectT.localPosition = new Vector3(0f, 0f, 0f);
        buttonRectT.rotation = Quaternion.Euler(angleX, 0, 0);





        /*
                text.name = "Butt" + ButtText + "Text";


                text.transform.parent = button.transform;


                text.AddComponent<RectTransform>();
                text.AddComponent<Text>().text = ButtText;
                text.GetComponent<Text>().font = ArialFont;
                text.GetComponent<Text>().fontSize = 30;
                text.GetComponent<Text>().color = Color.yellow;
                text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                RectTransform textSize = text.GetComponent<RectTransform>();
                textSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                textSize.sizeDelta = new Vector2(500f, 500f);
                textSize.localScale = new Vector3(1f, 1f, 1f);
                textSize.anchorMin = new Vector2(0.5f, 0.5f);
                textSize.anchorMax = new Vector2(0.5f, 0.5f);
                textSize.rotation = Quaternion.Euler(angleX, 0, 0);


            


    }

    */






}
