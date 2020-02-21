using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // rychlost pohybu kamery
    public float speed = 10f;
    // rychlost prblizeni
    public float scrollspeed = 1f;
    // rycholst rotace
    public float rotspeed = 60f;
    //hraniceobrazovky
    public float SCborder = 10f;
    // limit kam se kamera muze pohybovat
    public Vector2 screenLimit;


    float rotY = 0f;
    float rotX = 30f;
        
    void Update()
    {
        // pozice kamery
        Vector3 pos = transform.position;
        

        // pohyb kamery pri stisku tlacitek wsad
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - SCborder)
        {
            pos.z += speed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= SCborder)
        {
            pos.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - SCborder)
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= SCborder)
        {
            pos.x -= speed * Time.deltaTime;
        }

        //rotace kamery
        if (Input.GetKey("q"))
        {
            rotY -= rotspeed * Time.deltaTime;
        }

        if (Input.GetKey("e"))
        {
            rotY += rotspeed * Time.deltaTime;
        }

        //priblizeni oddaleni
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y += scroll * scrollspeed * 150f * Time.deltaTime;

        //maximalni pohyb kamery
        pos.x = Mathf.Clamp(pos.x, -screenLimit.x, screenLimit.x);
        pos.z = Mathf.Clamp(pos.z, -screenLimit.y, screenLimit.y);
        pos.y = Mathf.Clamp(pos.y, 2, 11);

        // meni polohu kamery v zavislosti na stisknuti tlacitek
        transform.position = pos;
        transform.eulerAngles = new Vector3(rotX, rotY, 0f);
       
    }
   
}
