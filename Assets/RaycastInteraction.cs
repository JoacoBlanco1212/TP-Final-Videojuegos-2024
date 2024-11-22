using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInteraction : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLength;
    public LayerMask layer;
    public GameObject uiGO;
    public Text hintText;
    public float hintTime;
    public string defaultHint;

    // Start is called before the first frame update
    void Start()
    {
        uiGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        InteractableObject interactable = null;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLength))
        {            
            interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable)
            {
                uiGO.SetActive(interactable);
            }
            else
            {
                uiGO.SetActive(false);
            }
        }

        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            string message = "";
            if (!interactable.activated)
            {
                interactable.PlayObjectAnimation();
                message = "Succesfully open!";
                Debug.Log("gero, te quiero mucho.");
            }
            else
            {
                message = "It's already open!";
                Debug.Log("gero, my beloved");
            }
            StopAllCoroutines();
            StartCoroutine(ShowHintDuringTime(message));
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLength);
    }

    IEnumerator ShowHintDuringTime(string hintMessage)
    {
        float time = 0;
        hintText.text = hintMessage;
        while (time < hintTime)
        {
            time += Time.deltaTime;
            uiGO.SetActive(true);
            yield return null;
        }
        uiGO.SetActive(false);
        hintText.text = defaultHint;
    }

}
