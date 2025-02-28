using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public enum States
    {
        ZiekenhuisKamer,
        ZiekenhuisGang,
        Toiletten,
        Trappenhuis,
        Gebeten,
        Dak,
        Helikopter,
        FlyingOff,
        ZiekenhuisLobby,
        DoorLocked,
        SmashThroughWindow,
    }

    private States currentState;

    [SerializeField]
    private TMP_Text textArea;


    // Start is called before the first frame update
    void Start()
    {
        currentState = States.ZiekenhuisKamer;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.ZiekenhuisKamer)
        {
            ZiekenhuisKamer();
        }
        else if (currentState == States.ZiekenhuisGang)
        {
            ZiekenhuisGang();
        }
        else if (currentState == States.Toiletten)
        {
            Toiletten();
        }
        else if (currentState == States.Trappenhuis)
        {
            Trappenhuis();
        }
        else if (currentState == States.Gebeten)
        {
            Gebeten();
        }
        else if (currentState == States.Dak)
        {
            Dak();
        }
        else if (currentState == States.Helikopter)
        {
            Helikopter();
        }
        else if (currentState == States.FlyingOff)
        {
            FlyingOff();
        }
        else if (currentState == States.ZiekenhuisLobby)
        {
            ZiekenhuisLobby();
        }
        else if (currentState == States.DoorLocked)
        {
            DoorLocked();
        }
        else if (currentState == States.SmashThroughWindow)
        {
            SmashThroughWindow();
        }
    }

    private void ZiekenhuisKamer()
    {
        textArea.text = "You wake up in a darkened room. While your eyes adjust to the darkness you feel the dark aura thats currently in the air.\n" +
            "As you begin to recognize your surroundings, you realize that you're in a hospital room, specifically in the morgue.\n" +
            "Next to you is a body bag, nearly zipped up. As you step off the table, you accidentally knock over some of the tools beside you. \n " +
            "A dark growl emanates from the body bag as you see it squirm, revealing the presence of a madman inside. As you hear the zipper being torn open, you make a break for the hallway. \n \n" +
            "Press SPACE to head to the hallway";

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            currentState = States.ZiekenhuisGang;
        }
    }

    private void ZiekenhuisGang()
    {
        textArea.text = "You slam the door behind you—not the wisest move, as you now hear a loud growl from behind. Still, you search for a way out. \n" +
            "To your horror, the hallway is littered with what appear to be bodies, and the walls are splattered with a thick, metallic-smelling red liquid. \n" +
            "As you try to keep from losing your lunch, you spot a hammer on one of the bodies. \n" +
            "A loud bang echoes against the door. It won't hold much longer. Will you hide in the bathroom or flee through the stairway towards the exit? \n \n" + 
            "Press 1 to hide in the bathroom \n" +
            "Press 2 to flee through the stairway"; 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = States.Toiletten;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = States.Trappenhuis;
        }
            }

    private void Toiletten()
    {
        textArea.text = "As you walk into the toilet, you hear the door of the hospital room break down. You can hear a stomach-turning grunt. If this creature was human once, it certainly is not anymore. \n" +
            "Slow footsteps walk towards you as you hold your breath. You look down, and to your horrifying conclusion, you see a fresh little stream of blood coming from your leg. \n" +
            "'IT' is coming your way. You gather your nerves. Will you hide in one of the stalls, or will you face whatever is coming with your acquired weapon? \n \n" +
            "Press 1 to hide in the stall \n" +
            "Press 2 to fight the creature";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = States.Dak;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = States.Gebeten;
        }
    }
    private void Gebeten()
    {
        textArea.text = "You breathe in, ready to swing at whatever has been out for your neck. 'If it was once human, it can be killed again,' goes through your mind.\n" + 
            "With that, you tighten your grip on your hammer, wait for the creature to get closer, and strike with a swift move at the creature now in front of you.\n" +
            "You hit it right on the head. The sound of a smashed watermelon echoes through the air. The creature drops to the ground, and you sigh in relief and disbelief.\n" +
            "As you walk towards the exit, leaving the creature behind, you suddenly feel a sharp pain in your ankle. You look down and see the creature's hand gripping your ankle.\n" +
            "You can feel something moving up through your leg, it hurts like hell and seems to be growing bigger and bigger. You start to lose consciousness, and the last thing you see is the ground rushing up to meet you.\n \n" + 
            "YOU DIED \n" + 
            "Press SPACE to start again";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.ZiekenhuisKamer;
        }
    }

    private void Dak()
    {
        textArea.text = "You open one of the stalls and barely avoid screaming as a lifeless body sits in front of you. It looks rather fresh, so you grab it and throw it right behind the door. \n" +
            "Just as you fall back into your stall and close the door, you hear the door to the hallway open. You hear a low croak, a second of silence, and then the stomach-turning sound of flesh being squashed and torn. \n" +
            "It sounds like a boar rummaging through its slop on a farm. Again, you start to silently gag, but you endure the entire incident. The door to the hallway opens again, and the sound of distancing footsteps hits your ears, louder than thunder. \n" +
            "You open the stall and walk towards the staircase. You hear a howling from downstairs, so up you go towards the roof—maybe there is a fire exit. \n \n" +
            "Press Space to go up the stairs";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.Helikopter;
        }
    }
    
    private void Helikopter()
    {
        textArea.text = "Arriving upstairs, your heart drops to your toes. A creature, as ugly as the night, is enjoying an all-you-can-eat buffet of first-aid responders just meters ahead of you. You hide behind the doorway and try to look around the creature.\n" +
            "Not all hope is lost, though, because to the right of the monster is a helicopter. It seems to still be running; the poor crew must have been attacked right before or after a mission. \n" +
            "There seems to be enough cover to aid your journey on this cloudy day. But will the darkness be enough? What abilities do these creatures have to be able to take down an entire hospital? \n" +
            "Maybe it is better to try and take down the creature and give yourself enough time to escape. \n \n" +
            "Press 1 for the helicopter\n" +
            "Press 2 to attack the creature";
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = States.FlyingOff;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = States.Gebeten;
        }
    }
    private void FlyingOff()
    {
        textArea.text = "You make a run for the helicopter. you sneak behind the creature a make use of all the obstacles to cover your sprint of destiny. You reach the cockpit of the helicopter and find the key still in the ignetion.\n" +
            "Your aircraft obsession as a child finally pays off as you flip the switches and ready yourself for takeoff. You pull the joystick and and you feel the aircraft lift up and you go and try your luck elsewhere.\n" +
            "YOU WIN \n" +
            "Press SPACE to try again";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.ZiekenhuisKamer;
        }
    }

    private void Trappenhuis()
    {
        textArea.text = "The bigger the distance between you and that 'Thing' the better. You sprint downstairs and almost sprint through the door" +
            " towards the lobby when you see 2 ghoul-like creatures bowing over a bunch of mannequin looking shapes. \n" + "when it hits you that they " +
            "are human bodies you can barely hold in a scream of fear. You have to get out. When you look into the lobby you can see a good hiding space.\n"+
            "Press SPACE to head into the lobby";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.ZiekenhuisLobby;
        }
    }

    private void ZiekenhuisLobby()
    {
        textArea.text = "You see 2 ways out through a shabby looking window and the front door. which do you choose? \n" + 
            "Press 1 to head to the front door\n" +
            "Press 2 to head to the front door";
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = States.DoorLocked;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = States.SmashThroughWindow;
        }
    }

    private void DoorLocked()
    {
        textArea.text = "You dash towards the door and pull, then push, then pull again. You failed to notice the under construction sign and because of the commoition you hear the 2 creatures behind you getting closer.\n" +
            "you get torn apart and black out \n" +
            "Press SPACE to try again";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.ZiekenhuisKamer;
        }
    }

    private void SmashThroughWindow()
    {
        textArea.text = "You sprint to the window use your hammer to break it and run towards freedom" +
            "YOU WIN" +
        "press SPACE to try again";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = States.ZiekenhuisKamer;
        }
    }


}
