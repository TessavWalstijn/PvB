using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _baseTower : MonoBehaviour
{
    
  [Header("LookAt")]

    // Stuk van de toren dat naar de vijand moet draaien
    [SerializeField] private GameObject _turretHead; 
    // Hoe snel de toren moet draaien naar de vijand 
    [SerializeField] private float _turnSpeed = 10f; 
   
   // Het gameobject van de vijand 
    public GameObject _enemy;   
    // Hoe de toren is gedraait                     
    private  Vector3 _startRotation;     
    // Een array waar de vijanden die in de collider zitten worden opgeslagen            
    public List<GameObject> enemiesInCollider;
     // De collider om de toren heen
    private SphereCollider _collider;               

   [Header("Bullet")]

    // De hoeveelheid schade die de kogels doen
    [SerializeField] protected private int _damage;
    // Hoe snel de toren schiet  
    [SerializeField] protected private float _fireRate;  
    // Het gameobject voor de kogel 
    [SerializeField] private GameObject _bullet;
    // Het punt waar de kogel moet spawnen
    [SerializeField] protected private Transform _firePoint;  


    protected private float _fireCountdown = 0f;      


    void Start() 
    {
        // Definieren van de SphereCollider 
         _collider = GetComponent<SphereCollider>();
         // Referentie naar het _Rapidfire script 
         _rapidFire _rapidFire = new _rapidFire();
         // Het startrotatie van het deel van de toren dat draait naar de vijand   
         _startRotation = new Vector3(_turretHead.transform.rotation.eulerAngles.x, 
         _turretHead.transform.rotation.eulerAngles.y,
         _turretHead.transform.rotation.eulerAngles.z); 
    }
    void Update()
    {
        //
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // De vijand loopt de collider in
        foreach(GameObject enemy in enemiesInCollider)
        {
            // Uitrekenen welke vijand het dichtbijzijnde is
            float _distanceToNearestEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            // de dichtbijzijnde enemy aangeven dat hij de vijand is waarop hij gaat vuren 
            if(_distanceToNearestEnemy < shortestDistance)
            {
                shortestDistance = _distanceToNearestEnemy;
                nearestEnemy = enemy;
            }
        }
        // checkt of de dichtbijzijnde enemy ook in de collider staat en gaat daarop vuren
        if(nearestEnemy != null && shortestDistance <= _collider.radius)
        {
            _enemy = nearestEnemy.gameObject;
                if(_fireCountdown <= 0f)
                {
                    Shoot();
                    _fireCountdown = 1f / _fireRate;
                }
        _fireCountdown -= Time.deltaTime;
        //waneer er geen vijand is word de _enemy op null gezet en de rotatie van de toren naar de startrotatie verandert
        }else
        {
            _enemy = null;
            Vector3.Lerp(new Vector3(_turretHead.transform.rotation.x, _turretHead.transform.rotation.y, _turretHead.transform.rotation.z), _startRotation, Time.deltaTime * _turnSpeed);
        }
        
        //als enemy null is return
        if(_enemy == null)
            return;

        // de directie van de toren naar de vijand
        Vector3 dir = _enemy.transform.position - transform.position;
        // 
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(_turretHead.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
        _turretHead.transform.rotation = rotation;
    }

    // waneer een vijand de collider binnentreed word hij toegevoegd aan de array enemiesInCollider  
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Add(other.gameObject);
        }
    }
    // waneer de enemy uit de collider loopt of word vernietigd word hij weggehaald uit de array 
    void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Remove(other.gameObject);
        }
    }
    
    protected virtual void Shoot()
    {
        // Er word een tijdelijk gameobject gemaakt genaamd _bulletGO
       GameObject _bulletGO = (GameObject)Instantiate (_bullet, _firePoint.position,_firePoint.rotation);
       // het script _bullet word opgeroepen 
       _bullet _Bullet = _bulletGO.GetComponent<_bullet>();


       // waneer bullet niet null is dan word de functie chase aangeroepen in het _Bullet script
        if (_bullet != null)
        {
            _Bullet.Chase(_enemy);
        }
                 
    }
}

