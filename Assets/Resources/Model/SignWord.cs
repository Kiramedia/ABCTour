using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SignWord : ScriptableObject, IEqualityComparer<SignWord>
{
    public string word;
    public Sprite signs;


    public bool Equals(SignWord x, SignWord y)
    {
        return x.word.Equals(y.word);
    }

    public int GetHashCode(SignWord obj)
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
