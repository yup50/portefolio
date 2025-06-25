using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DescriptionOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject descriptionPrefab; // Prefab voor de beschrijving
    private GameObject currentDescription; // Huidige beschrijving
    public string text; // Tekst voor de beschrijving

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Ik werk");
        // Instantieer beschrijving en stel tekst in
        currentDescription = Instantiate(descriptionPrefab, Input.mousePosition, Quaternion.identity);
        TextMeshProUGUI descriptionText = currentDescription.GetComponentInChildren<TextMeshProUGUI>();
        descriptionText.text = text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentDescription != null)
        {
            Destroy(currentDescription);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Ik ben uit");
        if (currentDescription != null)
        {
            Destroy(currentDescription);
        }
    }
}
