using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _cubeSpeedMove;
    [SerializeField] private float _deleteDistance;
    [Header("Reference")]
    [SerializeField] private Pool _cubePool;
    [SerializeField] private FloatField _distanceField;
    [SerializeField] private FloatField _spawnDelayField;
    [SerializeField] private FloatField _speedMovementField;

    private List<CubeMove> _cubeList = new List<CubeMove>();

    private void Awake()
    {
        _distanceField.SetValue(_deleteDistance);
        _spawnDelayField.SetValue(_spawnDelay);
        _speedMovementField.SetValue(_cubeSpeedMove);
    }

    private void OnEnable()
    {
        _distanceField.OnUpdateValue += ChangeDistance;
        _spawnDelayField.OnUpdateValue += SetSpawnDelay;
        _speedMovementField.OnUpdateValue += ChangeSpeed;
    }

    private void OnDisable()
    {
        _distanceField.OnUpdateValue -= ChangeDistance;
        _spawnDelayField.OnUpdateValue -= SetSpawnDelay;
        _speedMovementField.OnUpdateValue -= ChangeSpeed;
    }

    private void Start()
    {

        StartCoroutine(SpawnCube());
    }

    public void SetSpawnDelay(float delay)
    {
            _spawnDelay = delay;
    }

    public void ChangeSpeed(float speed)
    {
        _cubeSpeedMove = speed;
        foreach (var cube in _cubeList)
        {
            cube.SetSpeed(_cubeSpeedMove);
        }
    }

    public void ChangeDistance(float distance)
    {
        _deleteDistance = distance;
        foreach (var cube in _cubeList)
        {
            cube.SetDistance(_deleteDistance);
        }
    }

    private IEnumerator SpawnCube()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_spawnDelay);
            var item = _cubePool.Create(transform);
            var cube = item.GetComponent<CubeMove>();
            item.OnDelete += (PoolItem item) => DeleteCube(item, cube);
            cube.SetSpeed(_cubeSpeedMove);
            cube.SetDistance(_deleteDistance);
            cube.SetStartPosition(transform.position);
            _cubeList.Add(cube);
            yield return null;
        }
    }

    private void DeleteCube(PoolItem item, CubeMove cube)
    {
        _cubeList.Remove(cube);
        item.OnDelete -= (PoolItem item) => DeleteCube(item, cube);
    }

}
