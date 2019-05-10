using UnityEngine;

public class _bullet : MonoBehaviour
{
    private GameObject _target;
    protected private float _speed = 0.3f;
    public int damage;
    [SerializeField] protected GameObject _animprefab;

    void Start()
    {
      _baseTower _enemy = new _baseTower(); 
    }

    public void Chase(GameObject _enemy)
    {
        _target = _enemy;
        Debug.Log("Chasing");
    }

    
    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.gameObject.transform.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            //return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    private void HitTarget()
    {
        Debug.Log(damage);
        Instantiate(_animprefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
