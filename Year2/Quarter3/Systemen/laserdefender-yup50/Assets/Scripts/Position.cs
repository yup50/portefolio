using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//de locaties waarop enemies kunnen spawnen
//kan ook invullen welke enemy er inspawned
//spawned ze overigens zelf niet in
public class Position : MonoBehaviour
{
    public GameObject enemyPrefab;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    private void Start()
    {
        enemyPrefab.SetActive(true);
    }
}
