using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using System.Collections;
using System.Collections.Generic;
//using RosMessageTypes.UnityRoboticsDemo;
using  RosMessageTypes.Sensor;
public class RosSubscriberExample2 : MonoBehaviour
{

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<CompressedImageMsg>("/robot1018116128/compressedimage", ColorChange2);
    }

    void ColorChange2(CompressedImageMsg message)
    {
        byte[] imagen = message.data;
        Texture2D tex = new Texture2D(2,2);
        tex.LoadImage(imagen);
        Sprite camsprite = Sprite.Create( tex, new Rect(0, 0,  tex.width,  tex.height), new Vector2(0.5f, 0.5f));
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = camsprite; 

    }
}