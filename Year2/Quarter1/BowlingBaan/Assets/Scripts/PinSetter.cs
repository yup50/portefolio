using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinSetter : MonoBehaviour
{
    public TextMeshProUGUI standingDisplay;
    private bool ballEnteredBox = false;
    public GameObject ball;
    private float timeLeft = 3;

    public List<Pin> pins;  // Een lijst van alle pinnen
    public GameObject pinPrefab;  // Pin prefab om nieuwe pinnen te plaatsen
    private Transform pinSpawnPosition;  // Startpositie voor nieuwe pinnen

    public List<Vector3> pinSpawnPositions;  // Lijst om de spawnposities bij te houden
    private Animator animator;

    public GameObject Ending;

    // Start is called before the first frame update

    private void Start()
    {
        animator = GetComponent<Animator>();
        pins = new List<Pin>(FindObjectsOfType<Pin>());
        pinSpawnPositions = new List<Vector3>();

        // Bewaar de spawnposities van alle pinnen
        foreach (Pin pin in pins)
        {
            pinSpawnPositions.Add(pin.transform.position);
        }

        animator.SetTrigger("ResetTrigger");
    }
    public int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballEnteredBox == true)
        {
            CheckStanding();
        }
        standingDisplay.text = CountStanding().ToString();

        if(ballEnteredBox == false && ball.transform.position.y <= -10)
        {
            PinsHaveSettled();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
            print(ballEnteredBox);
        }
    }

    private void OnTriggerExit(Collider other)
    { 

        if (other.CompareTag("Pin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void CheckStanding()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0 )
        {
            PinsHaveSettled();
            timeLeft = 3;
            ballEnteredBox = false;
        }
        
    }
    private void PinsHaveSettled()
    {
        standingDisplay.color = Color.green;
        ball.GetComponent<BallControlScript>().ResetPosition();
        
        
        int potentialScore = 10;
        potentialScore -= CountStanding();
        GameManager.instance.IncreaseScore(potentialScore);
        
        StartCoroutine(DelayedExecuteAction());
    }

    private IEnumerator DelayedExecuteAction()
    {
        yield return new WaitForSeconds(1); // of gebruik een korte tijd zoals yield return new WaitForSeconds(0.1f);
        NextAction();
    }

    public void NextAction()
    {
        Debug.Log("Rolls: " + string.Join(", ", GameManager.instance.rolls) + " Vlak voor uitvoering");

        ActionMaster.Action nextAction = ActionMaster.NextAction(GameManager.instance.rolls);

        Debug.Log(nextAction);
        // Voer de juiste actie uit op basis van de returnwaarde van ActionMaster
        switch (nextAction)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("TidyTrigger");
                break;
            case ActionMaster.Action.Reset:
                animator.SetTrigger("ResetTrigger");
                break;
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("ResetTrigger");
                break;
            case ActionMaster.Action.EndGame:
                EndGame();
                break;
            default:
                Debug.LogWarning("Onbekende actie");
                break;
        }
    }

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.GetComponent<Rigidbody>().useGravity = false;
                pin.transform.position += new Vector3(0, 1f, 0);
            }
        }
    }
    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.transform.position += new Vector3(0, -1f, 0);
                pin.GetComponent<Rigidbody>().useGravity = true;

            }
        }
    }
    public void RenewPins()
    {

        pins.Clear();  // Leeg de lijst

        // Plaats nieuwe pinnen op de oorspronkelijke posities
        pins.Clear();  // Leeg de lijst

        // Plaats nieuwe pinnen 1 eenheid hoger en zonder zwaartekracht
        for (int i = 0; i < pinSpawnPositions.Count; i++)
        {
            Quaternion pinRotation = Quaternion.Euler(-90, 0, 0);  // Draai de pin -90 graden op de x-as

            // Instantiate de pin 1 eenheid boven de oorspronkelijke positie
            Vector3 elevatedPosition = pinSpawnPositions[i] + new Vector3(0, 1f, 0);

            GameObject newPin = Instantiate(pinPrefab, elevatedPosition, pinRotation);

            // Schakel zwaartekracht uit bij de nieuwe pin
            newPin.GetComponent<Rigidbody>().useGravity = false;

            // Voeg de nieuwe pin toe aan de lijst
            pins.Add(newPin.GetComponent<Pin>());
        }
    }

    public void ToggleCanRoll(int value)
    {
        GameManager.instance.ChangeCanRoll(value);
    }

    public void EndGame()
    {
        ball.gameObject.SetActive(false);
        Ending.gameObject.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerable<Pin> FindgameObjectsWithTag<T>(string v)
    {
        throw new NotImplementedException();
    }
}
