using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject gotcha;

    private void OnDestroy()
    {
        Instantiate(gotcha, transform.position, Quaternion.identity);
    }
}
