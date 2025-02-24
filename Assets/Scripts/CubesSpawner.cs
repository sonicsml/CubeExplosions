using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private Cube _cube;
    [SerializeField] private Cube _prefab;
    [SerializeField] private Exploader _exploader;

    private float _divider = 2f;
    
    private void OnEnable()
    {
        _cube.Clicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _cube.Clicked -= OnCubeClicked;
    }

    private void OnCubeClicked(Cube cube)
    {
        cube.Clicked -= OnCubeClicked;

        if (Random.value < cube.SplitChance)
        {
            SplitCube(cube);
        }
        else
        {
            if (_exploader != null)
            {
                _exploader.Explode(cube, cube.transform.position);
            }
        }
    }

    private void SplitCube(Cube cube)
    {
        List<Cube> cubes = new List<Cube>();
        int countNewCubes = Random.Range(_minCubes, _maxCubes+1);

        for (int i = 0; i < countNewCubes; i++)
        {
            cubes.Add(CreateNewCube(cube));
        } 
    }

    private Cube CreateNewCube(Cube cube)
    {
        float newChance = cube.SplitChance / _divider;
        Vector3 newScale = cube.transform.localScale / _divider; 

        Cube newCube = Instantiate(_prefab, cube.transform.position, Quaternion.identity);
        newCube.Construct(cube.transform.position, newScale, newChance);
        newCube.Clicked += OnCubeClicked;

        return newCube;
    }
}
