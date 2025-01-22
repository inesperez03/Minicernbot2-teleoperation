using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
//using RosMessageTypes.UnityRoboticsDemo;
using  RosMessageTypes.Sensor;

/// <summary>
/// 
/// </summary>
/// 

public class RosPublisherBrazo : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/robot192168239217/arm2/goalJointState";

    // The game object 
    public GameObject cube1;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    public double posicion_brazo = 0;
    public double posicion_herramienta = 0;
    

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;


    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<JointStateMsg>(topicName);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            JointStateMsg joint = new JointStateMsg();
            
            if (Input.GetKey(KeyCode.I))
            {
                joint.name = new string[] { "1" };
                posicion_brazo = posicion_brazo + 500.0;
                joint.position = new double[] {posicion_brazo};
                joint.velocity = new double[] {200};
                ros.Publish(topicName, joint);
            }
            if (Input.GetKey(KeyCode.K))
            {
                if(posicion_brazo > 0) {
                    joint.name = new string[] { "1" };
                    posicion_brazo = posicion_brazo - 500.0;
                    joint.position = new double[] {posicion_brazo};
                    joint.velocity = new double[] {200};
                    ros.Publish(topicName, joint);
                } 
            }
            if (Input.GetKey(KeyCode.J))
            {
                if(posicion_herramienta < 20000) {
                    joint.name = new string[] { "2" };
                    posicion_herramienta = posicion_herramienta + 50.0;
                    joint.position = new double[] {posicion_herramienta};
                    joint.velocity = new double[] {20};
                    ros.Publish(topicName, joint);
                }
            }
            if (Input.GetKey(KeyCode.L))
            {
                if(posicion_herramienta > -20000) {
                    joint.name = new string[] { "2" };
                    posicion_herramienta= posicion_herramienta - 50.0;
                    joint.position = new double[] {posicion_herramienta};
                    joint.velocity = new double[] {20};
                    ros.Publish(topicName, joint);
                } 
            }

            // Finally send the message to server_endpoint.py running in ROS

            timeElapsed = 0;
        }
    }
}
