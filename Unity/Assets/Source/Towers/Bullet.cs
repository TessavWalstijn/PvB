using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject _target;
    protected private float _speed = 0.3f;
    public int damage;
    [SerializeField] protected GameObject _animprefab;

    /**
     * <summary>
     * Zoekt naar het _enemy object, gedefinieerd in de parent class. Dit object wordt gebruikt als doelwit
     * Daarna een destroy functie die de kogel na 4 seconden vernietigd
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
      BaseTower _enemy = new BaseTower(); 

        Destroy(gameObject, 4f);
    }

    /**
     * <summary>
     * Zet het _target object gelijk aan _enemy
     * </summary>
     * <param name="_enemy"></param>
     */
    public void Chase(GameObject _enemy)
    {
        _target = _enemy;
    }

    /**
     * <summary>
     * Update functie die ervoor zorgt dat de kogel beweegt naar het doelwit
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        if(_target == null)     // Verwijderd de kogel als het doelwit weg is
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.gameObject.transform.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)     // Checkt of de kogel de vijand geraakt heeft
        {
            HitTarget();
            //return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    /**
     * <summary>
     * Functie om te definieren wat er moet gebeuren als het doelwit geraakt wordt
     * </summary>
     */
    private void HitTarget()
    {
        _target.GetComponent<Health>().currentHealth -= damage;
        Instantiate(_animprefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
