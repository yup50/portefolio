using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Range(1, 99)][SerializeField] private int startingelevel = 1;
    [SerializeField] private CharacterClass characterClass;
    [SerializeField] private Progression progression;
    // Start is called before the first frame update

    private void Start()
    {
        GetStat(Stats.Health);
        Debug.Log(GetStat(Stats.Health) +
            GetStat(Stats.Strength) +
            GetStat(Stats.Defence)
            );
    }
    public float GetStat(Stats stats)
    {
        Debug.Log(progression.GetStats(stats, characterClass, startingelevel));
        return progression.GetStats(stats, characterClass, startingelevel);
    }

    // Update is called once per frame
    public float GetExperienceReward()
    {
        return 0.1f;
    }

    public void LevelUp()
    {
        startingelevel++;
        Debug.Log(GetStat(Stats.Health) +
            GetStat(Stats.Strength) +
            GetStat(Stats.Defence)
            );
    }
}
