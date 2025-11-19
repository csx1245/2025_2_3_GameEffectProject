using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10;
    [SerializeField] private LayerMask enemyLayer;
    // Start is called before the first frame update
    public GameObject GetClosestEnemy()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        if (enemiesInRange.Length > 0)
        {
            GameObject bestTarget = null;
            float closestDestanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (Collider enemycollider in enemiesInRange)
            {
                if (enemycollider.gameObject == this.gameObject)
                    continue;

                Vector3 directionToTarget = enemycollider.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDestanceSqr)
                {
                    closestDestanceSqr = dSqrToTarget;
                    bestTarget = enemycollider.gameObject;
                }
            }
            return bestTarget;
        }
        else
        {
            return null;
        }
    }

    public List<GameObject> GetEnemiesInRange()
    {
        List<GameObject> enemiesList = new List<GameObject>();
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        foreach (Collider enemyCollider in enemiesInRange)
        {
            if (enemyCollider.gameObject != this.gameObject)
            {
                enemiesList.Add(enemyCollider.gameObject);
            }
        }
        return enemiesList;
    }
}
