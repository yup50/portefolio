using System.Collections.Generic;
using UnityEngine;

public static class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined }
    

    public static Action NextAction(List<int> rolls)
    {
        Action nextAction = Action.Undefined;

        for (int i = 0; i < rolls.Count; i++)
        {
            if (i >= 18) // Voor speciale regels in het tiende frame
            {
                if (i == 20) 
                {
                    nextAction = Action.EndGame; // Reset voor extra bal in frame 10
                }
                else if (rolls[i] == 10 || (i == 19 && rolls[i] + rolls[i - 1] == 10))
                {
                    nextAction = Action.Reset;
                }
                else
                {
                    nextAction = Action.EndGame;
                }
            }
            else if (i % 2 == 0) // Eerste bal van een beurt (behalve laatste frame)
            {
                if (rolls[i] == 10)
                {
                    rolls.Insert(i, 0); // Virtuele 0 na strike
                    nextAction = Action.EndTurn;
                }
                else
                {
                    nextAction = Action.Tidy;
                }
            }
            else // Tweede bal van een beurt
            { 
                nextAction = Action.EndTurn;
            }
        }

        return nextAction;
    }
}
