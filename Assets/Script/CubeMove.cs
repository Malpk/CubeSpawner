using UnityEngine;

[RequireComponent(typeof(PoolItem))]
public class CubeMove : MonoBehaviour
{
    [SerializeField] private float _deleteDistance;
    [SerializeField] private float _speedMovement;
    [Header("SelfReference")]
    [SerializeField] private Rigidbody2D _rigidBody;

    private Vector2 _startPosition;
    private PoolItem _item;

    private void Awake()
    {
        _item = GetComponent<PoolItem>();

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(_rigidBody.position, _startPosition) < _deleteDistance)
        {
            Vector2 move = transform.right * _speedMovement * Time.fixedDeltaTime;
            _rigidBody.MovePosition(_rigidBody.position +  move);
        }
        else
        {
            _item.Delete();
        }
    }

    public void SetStartPosition(Vector2 startPosition)
    {
        _startPosition = startPosition;
        transform.position = startPosition;
    }


    public void SetSpeed(float speed)
    {
        _speedMovement = speed;
    }

    public void SetDistance(float distance)
    {
        _deleteDistance = distance;
    }
}
