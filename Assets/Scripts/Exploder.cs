using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 100f;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube, Vector3 position, Vector3 scale)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {

            explodableObject.AddExplosionForce(_explosionForce * cube.Generation, position, _explosionRadius * cube.Generation);
        }

        Instantiate(_effect, position, transform.rotation);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
