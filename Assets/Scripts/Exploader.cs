using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 5f;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(List<Cube> cubes, Vector3 position)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, position, 10f);
            Instantiate(_effect, transform.position, transform.rotation);
        }
    }
}
