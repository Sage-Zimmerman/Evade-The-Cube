using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Catcher,
    Evader
}

public class EnemyController : MonoBehaviour
{

    public float enemySpeed;
    public EnemyType enemyType;
    private Transform m_PlayerTransform;
    private float m_ThreshholdPositionZ = -20f;
    private PlayerController m_Pc;

    void Start()
    {
        m_Pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.z + -1 * Time.deltaTime * enemySpeed);

            // measure distance between the enemy and player position
            if (Vector3.Distance(m_Pc.transform.position, transform.position) < 1f)
            {
                if (enemyType == EnemyType.Evader)
                {
                    m_Pc.ReceiveDamage();
                }
                Destroy(gameObject);
                
            }
            else if ((m_Pc.transform.position.z - transform.position.z > 5.0) && (enemyType == EnemyType.Catcher))
            {
                m_Pc.ReceiveDamage();
                Destroy(gameObject);
            }
            else if (transform.position.z <= m_ThreshholdPositionZ)
            {
                Destroy(gameObject);
            }
    }
}
