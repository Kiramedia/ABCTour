using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Sign : ScriptableObject, IEqualityComparer<Sign>
{
    public char letter;
    public Sprite sign;

    public bool Equals(Sign x, Sign y)
    {
        return x.letter == y.letter;
    }

    public int GetHashCode(Sign obj)
    {
        unchecked
        {
            if (obj == null)
                return 0;
            int hashCode = obj.GetHashCode();
            hashCode = (hashCode * 397) ^ obj.GetHashCode();
            return hashCode;
        }
    }
}
