using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    // Start is called before the first frame update

    private void OnEnable()
    {
        SpawnCoin();
    }
    private void SpawnCoin()
    {
        int x = Random.Range(0, 10);

        if(x <= 1.5f)
        {
            Instantiate(coinPrefab, transform.position + new Vector3(0, 1, 0), coinPrefab.transform.rotation);
        }
    }
}
