using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [field: SerializeField] public float SplitChance { get; private set; } = 1f;
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    public event Action<Cube> Clicked;

    private MeshRenderer _renderer;
    private ColorGenerator _colorGenerator;


    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _colorGenerator = new ColorGenerator();
    }
    public void Construct(Vector3 position, Vector3 scale, float splitChance)
    {
        transform.position = position;
        transform.localScale = scale;
        SplitChance = splitChance;

        Color color = _colorGenerator.ChangeRandomColor();
        _renderer.material.color = color;
    }

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }
}
