using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectCont : MonoBehaviour
{
    [SerializeField] float livingDuration;

    private void Start()
    {
        Destroy(gameObject, livingDuration);
    }
}
