using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup() {}

    [Test]
    public void SimpleTest()
    {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void NormalRollsWithoutStrikeOrSpareEndsTurn()
    {
        List<int> rolls = new List<int> { 3, 4 }; // Een normale beurt zonder strike of spare
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls)); // Na twee worpen moet de beurt eindigen
    }
    [Test]
    public void SpareInTenthFrameGrantsOneExtraRoll()
    {
        List<int> rolls = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls)); // Spare, reset voor extra bal in frame 10
    }
    [Test]
    public void StrikeInTenthFrameGrantsTwoExtraRolls()
    {
        List<int> rolls = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls)); // Eerste bal van frame 10 is een strike, reset voor extra bal
        rolls.Add(10); // Eerste extra bal na de strike
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls)); // Nog een reset voor de laatste bal
        rolls.Add(10); // Tweede extra bal
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls)); // Spel zou hier moeten eindigen
    }

    [Test]
    public void GameEndsAtSecondThrow10thRoundWithoutSrikeOrSpare()
    {
        List<int> rolls = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 5, 4 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls));
    }

}
