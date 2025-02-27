using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStoryNode", menuName ="New/storyNode")]
public class StoryNode : ScriptableObject
{
    [TextArea]
    public string storyText;

    public StoryNode[] nextStoryNodes;
    public string[] nextStoryNodeText;
    
}
