using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CollisionStorage", menuName = "CollisionStorage" )]
public class CollisionStorage : ScriptableObject
{
    public new string[] name = {"Wall", "Boulder", "Gem", "Finish"};
    public string[] tag = {"wall", "boulder", "gem", "finish"};

    public string tags;

    public bool CheckTags(string input)
    {
        for(int i = 0; i < tag.Length; i++)
        {
            if(input == tag[i])
            {
                return true;
            }
        }
        return false;
    }
}
