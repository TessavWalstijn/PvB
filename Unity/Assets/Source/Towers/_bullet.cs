using UnityEngine;

public class _bullet : _baseTower
{
    private Transform _target;
    protected private float _speed = 70f;
    public void Chase(Transform _Target)
    {
        _target = _Target;
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
