using UnityEngine;

public class _bullet : MonoBehaviour
{
    private GameObject _target;
    protected private float _speed = 0.3f;
    [SerializeField] protected GameObject _animprefab;

    // baseTower _enemy word gedefinieerd
     void Start()
    {
      _baseTower _enemy = new _baseTower(); 
    }
    // _enemy word gezien als _target 
    public void Chase(GameObject _enemy)
    {
        _target = _enemy;
    }

    
    void Update()
    {
        // als target null is dan word bullet vernietigd
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }
        // dir is de lengte van de enemy naar de bullet
        Vector3 dir = _target.gameObject.transform.position - transform.position;
        // de snelheid die de kogel heeft
        float distanceThisFrame = _speed * Time.deltaTime;
        // als de vijand dichterbij staat dan de hoeveelheid stappen die de kogel per frame aflegt dan moet de functie HitTarget worden aangeroepen
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            //return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    // maakt een geanimeerd object aan en verwijdert het oude object 
    private void HitTarget()
    {
        Instantiate(_animprefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
