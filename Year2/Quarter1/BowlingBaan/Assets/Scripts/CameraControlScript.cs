using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public GameObject player;
    public GameObject zelf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.transform.position.z <= 18f)
        {
            zelf.transform.position = (player.transform.position + new Vector3(0f, 0.5f, -2f));
        }
    }
}
