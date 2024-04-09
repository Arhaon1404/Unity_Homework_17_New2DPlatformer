using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Item _spawnableObject;
    [SerializeField] private ColliderChecker _colliderChecker;

    private Item _spawnedObject;

    private Coroutine _spawnCoroutine;
    private float _spawnSecondsPeriod = 3f;
    private int _spawnCount;
    private bool _isCoroutineDone = true;
    private Transform _point;

    private void OnEnable()
    {
        _colliderChecker.ItemCollected += AddItemToSpawn;
    }

    private void OnDisable()
    {
        _colliderChecker.ItemCollected -= AddItemToSpawn;
    }

    private void Start()
    {
        _spawnCount = 0;

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawnedObject = Instantiate(_spawnableObject, _spawnPoints.GetChild(i).transform.position, Quaternion.identity);

            _spawnedObject.transform.SetParent(_spawnPoints.GetChild(i));
        }
    }

    private void Update()
    {
        if (_spawnCount > 0)
        {
            CheckPoints();
        }
    }

    private void AddItemToSpawn() 
    {
        _spawnCount++;
    }

    private void CheckPoints()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            if (_spawnPoints.GetChild(i).childCount == 0)
            {
                _point = _spawnPoints.GetChild(i);

                RunCoroutine(_point);
            }
        }
    }

    private IEnumerator SpawnObject(Transform _point)
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        _spawnedObject = Instantiate(_spawnableObject, _point.transform.position, Quaternion.identity);

        _spawnedObject.transform.SetParent(_point);

        _isCoroutineDone = true;

        _spawnCount--;
    }

    private void RunCoroutine(Transform _point)
    {
        if (_spawnCoroutine != null & _isCoroutineDone == true)
        {
            StopCoroutine(_spawnCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            _spawnCoroutine = StartCoroutine(SpawnObject(_point));
        }
    }
}
