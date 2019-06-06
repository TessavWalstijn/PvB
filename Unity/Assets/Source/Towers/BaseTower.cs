using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{   
  [Header("LookAt")]

    [SerializeField] private GameObject _turretHead;
    [SerializeField] private float _turnSpeed = 10f;
   
    public GameObject _enemy;
    public List<GameObject> enemiesInCollider;
    private SphereCollider _collider;
    

   [Header("Bullet")]

    [SerializeField] protected private int _damage;
    [SerializeField] protected private float _fireRate;
    [SerializeField] protected private Transform _firePoint;

    protected private float _fireCountdown = 0f;

    /**
     * <summary>
     * Start functie met een referentie van de collider in de tower
     * </summary>
     * <returns></returns>
     */
    void Start() 
    {
         _collider = GetComponent<SphereCollider>();
         //_rapidFire _rapidFire = new _rapidFire();
    }

    /**
     * <summary>
     * Update functie die ervoor zorgt dat van de vijanden in de collider de dichtsbijzijnde vijand als doelwit wordt gezien
     * Daarna wordt de rotatie van de turret head gezet naar de dichtsbijzijnde vijand uit de enemiesInCollider List
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemiesInCollider)      // Checkt voor elke vijand in de collider welke het dichtsbijzijnde is
        {
            float _distanceToNearestEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(_distanceToNearestEnemy < shortestDistance)
            {
                shortestDistance = _distanceToNearestEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= _collider.radius)    // Zet het _enemy object als de dichtsbijzijnde vijand
        {
            _enemy = nearestEnemy.gameObject;
        }else
        {
            _enemy = null;
        }

        if(_fireCountdown <= 0f && _enemy != null)      // Geeft een cooldown aan de schiet functie
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;

        if(_enemy == null)      // Stopt met rotatie als er geen vijand gezien wordt
        {
            return;
        }

        // Zoekt welke richting de vijand staat vanaf de turret en zorgt ervoor dat de rotatie soepel beweegt door de Lerp fucntie de gebruiken
        Vector3 dir = _enemy.transform.position - _turretHead.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(_turretHead.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
        _turretHead.gameObject.transform.rotation = rotation;
    }

    /**
     * <summary>
     * OnTriggerEnter functie die detecteerd of er een vijand in de collider zit en die dan toevoegt aan de lijst van vijanden op de tower
     * </summary>
     * <param name="other"></param>
     * <returns></returns>
     */
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Add(other.gameObject);
        }
    }

    /**
     * <summary>
     * OnTriggerExit functie die de vijanden verwijderen uit de lijst als ze uit de collider lopen.
     * </summary>
     * <param name="other"></param>
     * <returns></returns>
     */
    void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Remove(other.gameObject);
        }
    }

    /**
     * <summary>
     * Schiet functie die overgeschreven wordt door de andere type towers
     * </summary>
     */
    protected virtual void Shoot()
    {
                 
    }
}

