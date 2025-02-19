using UnityEngine;

public class ColorGenerator
{
    public Color ChangeRandomColor()
    {
        return new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }
}
