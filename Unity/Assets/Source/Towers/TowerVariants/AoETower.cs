using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETower : BaseTower
{
    [SerializeField] private GameObject AoETowerImpact;

    [SerializeField] private Component[] impRef;

    protected override void Shoot()
    {
        GameObject impact = Instantiate(AoETowerImpact, _enemy.gameObject.transform.position, _enemy.gameObject.transform.rotation);
        impact.transform.parent = gameObject.transform;

        impRef = impact.GetComponentsInChildren<AoEBulletHitbox>();
        foreach(AoEBulletHitbox bHitBox in impRef)
        {
            bHitBox.damage = _damage;
        }
    }
}
