using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    public AudioClip clip;
    private AudioSource audSou;

    void Update()
    {
        MoveHero();
        audSou = GetComponent<AudioSource>();
    }

    private void MoveHero()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, 0, yValue);
    }

    public void PlaySound()
    {
        audSou.PlayOneShot(clip);
    }
    public IEnumerator SlowTime()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }

    public IEnumerator ChangeSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
        if (newSpeed != 10)
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(ChangeSpeed(10f));
        }
    }
}
