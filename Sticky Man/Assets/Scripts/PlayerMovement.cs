using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Props")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<GameObject> stickies;
    [SerializeField] private Rigidbody2D playerRb;

    List<GameObject> activeStickies = new List<GameObject>();
    GameObject decidedStick;
    static GameObject tempObj;

    Vector2 movePos;
    float turnSpeed = 250f;

    public static GameObject TempObj { get => tempObj; set => tempObj = value; }


    private void FixedUpdate()
    {
        foreach (var x in stickies)
        {
            var a = x.gameObject.GetComponent<Sticks>();

            if (a.Active)
            {
                if (activeStickies.Contains(x) == false)
                {
                    activeStickies.Add(x.gameObject);
                }
            }

            else
            {
                if (activeStickies.Contains(x))
                {
                    activeStickies.Remove(x);
                }

            }

        }

        if (activeStickies.Count == 0)
        {
        }

        else
        {
            // playerRb.gravityScale = 0f;
        }



        if (Input.GetKey(KeyCode.D))
        {
            //float temp = -999f;
            if (activeStickies.Count != 0)
            {
                activeStickies.Sort();
                tempObj = activeStickies[activeStickies.Count - 1];
               /* foreach (var item in activeStickies)
                {
                    if (item.transform.position.x > temp)
                    {
                        decidedStick = item;
                        temp = item.transform.position.x;
                    }

                }*/

                

                // playerTransform.RotateAround(decidedStick.transform.position, new Vector3(0f, 0f, 1f), -turnSpeed * Time.deltaTime);
                //playerRb.MoveRotation(1f * turnSpeed * Time.deltaTime);
                playerRb.AddTorque(1 * Time.deltaTime * turnSpeed);
                //decidedStick.GetComponent<Transform>().localRotation = Quaternion.Euler(0f,0f, 5f); 
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            float temp = 999f;
            if (activeStickies.Count != 0)
            {
                foreach (var item in activeStickies)
                {
                    if (item.transform.position.x < temp)
                    {
                        decidedStick = item;
                        temp = item.transform.position.x;
                    }

                }

                playerTransform.RotateAround(decidedStick.transform.position, new Vector3(0f, 0f, 1f), turnSpeed * Time.deltaTime);
            }
        }

    }

}
