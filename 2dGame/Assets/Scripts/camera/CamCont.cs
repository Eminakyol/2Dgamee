using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCont : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    [SerializeField] float minimumy, maximumy;

    private void Update()
    {
        transform.position = new Vector3(targetTransform.position.x, Mathf.Clamp(targetTransform.position.y,minimumy,maximumy), transform.position.z);
    }


}
