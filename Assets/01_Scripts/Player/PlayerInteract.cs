using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerManager playerManager;

    private RaycastHit hit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                DoInteraction(hit.transform.gameObject);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }

    private void DoInteraction(GameObject interactedObject)
    {
        // Call interact logic
        if (interactedObject.GetComponent<InteractMaster>() != null)
            interactedObject.GetComponent<InteractMaster>().DoInteraction(playerManager);
    }
}
