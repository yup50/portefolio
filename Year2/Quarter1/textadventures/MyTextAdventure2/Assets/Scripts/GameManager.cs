using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private States currentState;

    public enum States
    {
        Start,
        Onderwater,
        Vuur,
        BootNa,
        Verloren,
        Water,
        Schuim,
        Mist,
        SchipVoorkant,
        SchipAchterkant,
        Voordek,
        Ruim,
        Stress,
        YouSurvive
    }
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("Type tutorial voor een eenvoudige tutorial \n" +
                           "Type start om te beginnen");
        currentState = States.Start;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnUserInput(string input)
    {
        string userInput = input.ToLower();

        switch (currentState)
        { 
            case States.Start:
                if (userInput == "start")
                {
                    StartGame();
                }else if(userInput == "tutorial")
                {
                    Tutorial();
                }
                break;
            case States.Verloren:
                if(userInput == "opnieuw")
                {
                    StartGame();
                }
            break;
            case States.Onderwater:
                if(userInput == "omhoog")
                {
                    Vuur();
                }else if (userInput == "blijven")
                {
                    BootNa();
                }
                break;
            case States.BootNa:
                if(userInput == "klim")
                {
                    Gezonken();
                }
                break;
            case States.Vuur:
                if(userInput == "water")
                {
                    Water();
                }else if( userInput == "schuim")
                {
                    Schuim();
                }
                break;
            case States.Water:
                if(userInput == "weggaan")
                {
                    Opgepakt();
                }
            break;
            case States.Schuim:
                if(userInput == "weggaan")
                {
                    Mist();
                }
            break;
            case States.Mist:
                if (userInput == "terug")
                {
                    SchipAchterkant();
                }else if(userInput == "doorgaan")
                {
                    SchipVoorkant();
                }
            break;
            case States.SchipVoorkant:
                if(userInput == "klim")
                {
                    Voordek();
                }
            break;
            case States.SchipAchterkant:
                if (userInput == "klim")
                {
                    Ruim();
                }
            break;
            case States.Voordek:
                if(userInput == "verstop")
                {
                    YouSurvive();
                }
            break;
            case States.Ruim:
                if (userInput == "wegwezen")
                {
                    Stress();
                }
            break;
            case States.Stress:
                if (userInput == "verstoppen")
                {
                    Dies();
                }else if (userInput == "rennen")
                {
                    Voordek();
                }
            break;
            
        }
        
    }

    private void Tutorial()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("In dit spel ga je keuzes maken. Door de lage intelligentie van dit spel zullen je opties tussen '' staan. Denk hierbij aan 'omhoog' of 'omlaag'. Gebruik dan\n slechts deze woorden voor een goede \nervaring\n" + "\n Schrijf nu 'start' om te beginnen.");
    }

    private void StartGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Dit is het begin van het verhaal.\n Jij en je vrienden zijn van plan om te gaan zwemmen bij het lokale koraalrif. Tijdens het zwemmen zie je dat je\n luchttank bijna leeg is en is het tijd terug te gaan. Je zwemt rustig omhoog \n tegen decrompressie ziekte. Er gloeit een vuurbal \n uit de boot en je moet kiezen.\n Snel 'omhoog' zwemmen of 'blijven' om decrompressie ziekte te voorkomen.");
        currentState = States.Onderwater;
    }

    private void BootNa()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je blijft nog even dobberen. Je bent\n omringt door water en je vrienden zijn allemaal oud genoeg om voor zichzelf\n te zorgen. Wanneer je boven komt zie\n je tot schrik dat de bbq nog steeds\n brandt en steeds dichter bij het\n controlepaneel komt. 'Klim' snel\n omhoog en probeer te helpen!");
        currentState = States.BootNa;
    }

    private void Gezonken() 
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je doet je best de brand te blussen. \nJe ziet je vrienden met moeite overeind\n blijven staan en met emmers water\n richting het vuur gooien. Wat goed zou zijn als ze ook zouden raken. Het vuur is nu bijna overal. Alcohol en tieners\n was toch geen goed idee, na een paar minuten vergeefse moeite springen jij en je vrienden van het schip. Wanneer de\n kustwacht langskomt om de rookpluim te controleren is de boot al gezonken.\n Schrijf 'opnieuw' om opnieuw te beginnen.");
        currentState = States.Verloren;
    }
    private void Vuur()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("\n\n\nJe zwemt snel omhoog. Nu is niet de tijd om je zorgen om jezelf te maken. Wat is er aan de hand op dat schip. Zijn er gewonden? Is er schade?. Als je eenmaal boven bent zie je dat de bbq het dek in de brand heeft gezet. Je zoekt een manier om te blussen. Gebruik je de pompslang met 'water' of de blusser met 'schuim'.");
        currentState = States.Vuur;
    }

    private void Water()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je pakt snel de pompslang en start met het blussen van het vuur. Gelukkig is er genoeg water in de buurt om de bbq te blussen. Dit is noodzakelijk want erg accuraat ben je niet met de krachtige brandslang. Je ziet in de verte de kustwacht aankomen. Je moet snel 'weggaan' voordat ze je oppakken.");
        currentState = States.Water;
    }

    private void Schuim()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je pakt snel de brandblusser en begint met blussen. Je was gelukkig snel omhoog gezwommen dus is het vuur nog niet erg groot. Gelukkig maar want er zit niet veel schuim in zo'n brandblusser. Je ziet in de verte de kustwacht aankomen. Je moet snel 'weggaan' voordat ze je oppakken.");
        currentState = States.Schuim;
    }

    private void Opgepakt()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je rent snel de kajuit in en draait de sleutel in het contact om. Een oorverdovende stilte stokt de adem in je longen. Tijdens het blussen heb je waarschijnlijk wat water-aantastbare apparatuur gebroken. Je bent een sitting-duck en kunt niks anders doen dan door de kustwacht gepakt te worden. Schrijf 'opnieuw' om opnieuw te beginnen.");
        currentState = States.Verloren;
    }

    private void Mist()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je rent snel de kajuit in en draait de sleutel in het contact om. En met een luide brul start de motor en vaar je ervandoor. Je hoort achter je dat instructies worden geroepen maar vanwege de mistige omgeving kan je niet horen wat erg gezegd wordt. De mist wordt dikker. Misschien is het beter om 'terug' te keren inplaats van 'doorgaan'.");
        currentState = States.Mist;
    }

    private void SchipVoorkant()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je Stopt niet. Je weet dat het onmogelijk zou zijn voor een schip om een ander schip te volgen in deze weersomstandigheden. De mist wordt alsmaar dikker en als het niet voor een angsaanjagende gil was geweest had je volop tegen een groot vachtschip aan gevaren. Er hangt een ladder aan. 'Klim' omhoog, misschien valt er wal wat te halen terwijl je wacht tot de mist gaat liggen.");
        currentState = States.SchipVoorkant;
    }

    private void SchipAchterkant()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Het is te gevaarlijk om zo te blijven varen. Je draait het stuur om en maakt een 180 om terug te gaan en de kustwacht te trotseren. De mist wordt alsmaar dikker en als het niet voor een angsaanjagende gil was geweest had je volop tegen een groot vachtschip aan gevaren. 'Klim' omhoog, misschien valt er wal wat te halen terwijl je wacht tot de mist gaat liggen.");
        currentState = States.SchipAchterkant;
    }

    private void Voordek()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt voorzichtig rond over het voordek om checken wat er aan boord kan zijn. Voetstappen klinken vanuit de richting van het ruim omhoog. 'Verstop' je voordat je gepakt wordt");
        currentState = States.Voordek;
    }

    private void Ruim()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je Loopt een stukje rond op het achterdek tot voetstappen in jouw richting aankomen. Je duikt snel een gang in en leest dat het richting het ruim gaat. Eenmaal aangekomen check je 1 van de kratten om te kijken wat er in zit. CHCl3? Dat is gevaarlijk chloorgas, je merkt niet dat je een gat prikt in 1 van de blikken. 'Wegwezen' hier, er valt niks te halen.");
        currentState = States.Ruim;
    }

    private void Stress()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Voetstappen komen jouw richting op. Je moet snel kiezen om te 'verstoppen' in het ruim of, richting het voordek te 'rennen'. De trap op");
        currentState = States.Stress;
    }

    private void Dies()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je duikt snel achter de kist die je hebt gecheckt wanneer een booskijkende matrood voorbij loopt. Hij ziet jou niet en dus wacht je rustig totdat je verder kan lopen. Je probeert op te staan maar chloorgas zorgt ervoor dat je je bewustzijn verliest en helaas te laat wordt gevonden om te overleven. Schrijf 'opnieuw' om opnieuw te beginnen.");
        currentState = States.Verloren;
    }

    private void YouSurvive()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je duikt achter de boei. De voetstappen gaan langs je maar dankzij de dikke mist konden jullie elkaar niet zien. Je beslist snel terug te gaan naar de boot. Eenmaal aangekomen in de boot varen jullie er snel vandoor. De richting op die het rachtschip ook ging. Dat komt er vanzelf een einde aan de mistbank. En ja hoor, na een paar minuten varen heb je het avontuur overleeft en ben je in de open zon. Type 'nogmaals' om nog een keer te spelen'");
        currentState= States.YouSurvive;
    }



    private void WinGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hebt gewonnen");
    }
}
