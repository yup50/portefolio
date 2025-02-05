using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpReward : MonoBehaviour
{
    public float exp;
    private BaseStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindAnyObjectByType<BaseStats>();
    }

    private void OnDestroy()
    {
        stats.LevelUp();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
