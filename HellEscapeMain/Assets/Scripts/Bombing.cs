
using UnityEngine;

public class Bombing : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Quaternion rotation = Quaternion.LookRotation(-transform.forward);
        switch (other.tag)
        {
            case "Enemy":
                EnemyController enemy = other.GetComponent<EnemyController>();
                enemy.LoseHealth(1);
                Vector3 pos = new(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z + .7f);
                enemy.BloodParticle(pos, rotation);
                break;
            case "Boss":
                BossCont2 boss = other.GetComponent<BossCont2>();
                boss.LoseHealth(1);
                boss.BloodParticle(other.transform.position + Vector3.up, rotation);
                break;

        }

    }
}
