using UnityEngine;

public class _bullet : MonoBehaviour
{

    private Transform _target;
    protected private float _speed = 70f;
     void Start()
    {
      _baseTower _enemy = new _baseTower(); 
    }
    public void Chase(GameObject _enemy)
    {
        //_target = _baseTower._enemy;
    }

    
    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    private void HitTarget()
    {
        Debug.Log("Target hit");
    }
}
