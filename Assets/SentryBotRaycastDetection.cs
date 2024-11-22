using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBotRaycastDetection : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLength;
    public LayerMask layerMask;
    public bool hasDetectedPlayer;

    // Start is called before the first frame update
    void Awake()
    {
     
    }

    private void Start()
    {
        hasDetectedPlayer = false;    
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        bool RayDetection = Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLength);
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * rayLength, RayDetection ? Color.green : Color.red);
        if (RayDetection)
        {
            if (hit.collider.gameObject.tag == "Player")
            {

                hasDetectedPlayer = true;
            }
        }
    }

    
}
