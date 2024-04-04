using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Item _spawnableObject;

    private Item _spawnedObject;

    private Coroutine _spawnGemCoroutine;
    private float _spawnSecondsPeriod = 3f;
    private bool _isDone = true;
    private Transform _point;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawnedObject = Instantiate(_spawnableObject, _spawnPoints.GetChild(i).transform.position, Quaternion.identity);

            _spawnedObject.transform.SetParent(_spawnPoints.GetChild(i));
        }
    }

    private void Update()
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

        _isDone = true;
    }

    private void RunCoroutine(Transform _point)
    {
        if (_spawnGemCoroutine != null & _isDone == true)
        {
            StopCoroutine(_spawnGemCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _spawnGemCoroutine = StartCoroutine(SpawnObject(_point));
        }
    }
}
