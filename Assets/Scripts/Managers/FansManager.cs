using System.Collections.Generic;
using UnityEngine;

public class FansManager : MonoBehaviour
{
    [SerializeField] List<Material> _fanMaterials = new List<Material>();
    [SerializeField] GameObject _fanObject;
    [SerializeField] Orientation _orientation;

    private int _maxWidthRange = 89;
    private int _minWidthRange = -89;
    private int _maxHeightRange = 1;
    private int _minHeightRange = -6;

    private int _multiplire = -2;
    private int _fanRotation = -90;

    private void Awake()
    {
        if (_orientation == Orientation.North)
        {
            _maxWidthRange = 89;
            _minWidthRange = -89;
            _maxHeightRange = 1;
            _minHeightRange = -6;
            _multiplire *= -1;
        }
        else if (_orientation == Orientation.South)
        {
            _maxWidthRange = 89;
            _minWidthRange = -89;
            _maxHeightRange = 1;
            _minHeightRange = -6;
        }
        else if (_orientation == Orientation.West)
        {
            _maxWidthRange = 70;
            _minWidthRange = -70;
            _maxHeightRange = 1;
            _minHeightRange = -6;
        }
        else if (_orientation == Orientation.East)
        {
            _maxWidthRange = 70;
            _minWidthRange = -70;
            _maxHeightRange = 1;
            _minHeightRange = -6;
            _multiplire *= -1;
        }
        SpawnFans();
    }

    /// <summary>
    /// Spawns the fans on the stage
    /// </summary>
    private void SpawnFans()
    {
        for (int i = _minHeightRange; i < _maxHeightRange; i++)
        {
            for (int j = _minWidthRange; j < _maxWidthRange; j++)
            {
                if (j % 2 == 0)
                {
                    Vector3 position;
                    if (_orientation == Orientation.North || _orientation == Orientation.South)
                    {
                        position = new Vector3(transform.position.x + j, transform.position.y + i + 1, transform.position.z + i * _multiplire);
                    }
                    else if (_orientation == Orientation.East || _orientation == Orientation.West)
                    {
                        position = new Vector3(transform.position.x + i * _multiplire, transform.position.y + i + 1, transform.position.z + j);
                    }
                    else
                    {
                        position = new Vector3();
                    }
                    GameObject spawnedObject = Instantiate(_fanObject, position, transform.rotation, transform);
                    Material material = _fanMaterials[Random.Range(0, _fanMaterials.Count)];
                    spawnedObject.GetComponent<Renderer>().material = material;
                    spawnedObject.transform.Rotate(new Vector3(0, _fanRotation, 0));
                }
            }
        }
    }
}
