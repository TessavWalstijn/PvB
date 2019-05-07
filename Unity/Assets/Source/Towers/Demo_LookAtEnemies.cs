using UnityEngine;

public class Demo_LookAtEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _turretHead;

    private GameObject _enemy;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            _enemy = other.gameObject;
            _turretHead.transform.LookAt(_enemy.transform);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        _enemy = null;
    }
}
