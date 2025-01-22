using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
//using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Geometry;
using RosMessageTypes.Std;

/// <summary>
/// 
/// </summary>
/// 

public class RosPublisherExample : MonoBehaviour
{
    ROSConnection ros;
    ROSConnection ros2;
    public string topicName = "/robot192168239217/cmd_vel";
    public string topicName2 = "/robot192168239217/changeCam";

    int mode = 0;

    // The game object 
    public GameObject cube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.1f;
    

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TwistMsg>(topicName);

        ros2 = ROSConnection.GetOrCreateInstance();
        ros2.RegisterPublisher<Int32Msg>(topicName2);

    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            TwistMsg vel = new TwistMsg();
            Int32Msg mode_val = new Int32Msg();
            
            if (Input.GetKey(KeyCode.W))
            {
                vel.linear.x = 0.1;
                vel.linear.y = 0.0;
                vel.angular.z = 0.0;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.S))
            {
                vel.linear.x = -0.1;
                vel.linear.y = 0.0;
                vel.angular.z = 0.0;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.A))
            {
                vel.linear.x = 0.0;
                vel.linear.y = 0.0;
                vel.angular.z = 0.5;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.D))
            {
                vel.linear.x = 0.0;
                vel.linear.y = 0.0;
                vel.angular.z = -0.5;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                vel.linear.x = 0.0;
                vel.linear.y = 0.1;
                vel.angular.z = 0.0;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.E))
            {
                vel.linear.x = 0.0;
                vel.linear.y = -0.1;
                vel.angular.z = 0.0;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                vel.linear.x = 0.0;
                vel.linear.y = 0.0;
                vel.angular.z = 0.0;
                ros.Publish(topicName, vel);
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (mode == 1){
                    mode = 0;
                    mode_val.data = 0;
                }
                else{
                    mode = 1;
                    mode_val.data = 1;
                }
                ros2.Publish(topicName2, mode_val);
            }

            // Finally send the message to server_endpoint.py running in ROS

            timeElapsed = 0;
        }
    }
}
