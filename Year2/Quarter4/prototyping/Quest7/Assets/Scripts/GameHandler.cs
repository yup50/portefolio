// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text FoodAmountText;

    [SerializeField] private int foodCollected = 0;
    private Attack attack; //Challenge 8. i made an attack

    private void Awake()
    {
        int gameHandlerCount = FindObjectsOfType<GameHandler>().Length;
        if (gameHandlerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
        attack = FindAnyObjectByType<Attack>(); //reference to attack script
    }

    private void Start()
    {
        FoodAmountText = GameObject.Find("FoodAmountText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(FoodAmountText == null)FoodAmountText = GameObject.Find("FoodAmountText").GetComponent<TMP_Text>();

        FoodAmountText.text = foodCollected.ToString();
        if (Input.GetKeyDown(KeyCode.E) && foodCollected >= 5) //attacks cost 5 food points
        {
            updateFood(-5);
            attack.gameObject.SetActive(true);
        }
    }

    public void updateFood(int amount)
    {
        foodCollected += amount;
    }

    public void resetFoodCount()
    {
        foodCollected = 0;
    }

}
