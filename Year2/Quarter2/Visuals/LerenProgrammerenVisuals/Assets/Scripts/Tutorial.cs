using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> tutorials = new List<GameObject>();
    private int currentSlideIndex = 0; // Houd bij welke slide momenteel actief is
    public GameObject explain;

    // Start is called before the first frame update
    void Start()
    {
        ShowFirstTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSlide();
            explain.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousSlide();
            explain.SetActive(false);
        }
    }

    void ShowFirstTutorial()
    {
        // Controleer of er objecten in de lijst staan
        if (tutorials.Count > 0)
        {
            // Maak alleen het eerste object zichtbaar
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].SetActive(i == 0);
            }
        }
        else
        {
            Debug.LogWarning("De lijst met tutorials is leeg!");
        }
    }

    private void NextSlide()
    {
        if (currentSlideIndex < tutorials.Count - 1)
        {
            currentSlideIndex++;
            ShowSlide(currentSlideIndex);
        }
        else
        {
            Debug.Log("StartGame()");
        }
    }

    private void PreviousSlide()
    {
        if (currentSlideIndex >= 1)
        {
            currentSlideIndex--;
            ShowSlide(currentSlideIndex);
        }
        else
        {
            Debug.Log("Dit is al het begin!!! >:(");
        }
    }

    void ShowSlide(int index)
    {
        // Controleer of de index binnen de lijst valt
        if (index >= 0 && index < tutorials.Count)
        {
            // Maak alleen het object op de opgegeven index zichtbaar
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].SetActive(i == index);
            }
        }
        else
        {
            Debug.LogWarning("Index valt buiten bereik van de lijst!");
        }
    }

    public void Uitleg(string text)
    {
        explain.SetActive(true);
        explain.GetComponent<TextMeshProUGUI>().text = text;
    }
}
