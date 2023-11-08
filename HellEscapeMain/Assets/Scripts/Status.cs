using UnityEngine;

public class Status : MonoBehaviour 
{

    public PrefabData enemyData;
    public int initialHealth = 100;
	[HideInInspector] public int health;
	public float speed = 5;
    Animator anim;
    SkinnedMeshRenderer smr;
    // Use this for initialization
    void Awake ()
	{
        anim = GetComponent<Animator>();
        health = initialHealth;
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
        if (enemyData != null)
        {
           
            if (smr != null)
            {
                smr.sharedMesh = enemyData.sharedMeshRenderer.sharedMesh;
               
            }

            if (anim != null)
            {
                anim.runtimeAnimatorController = enemyData.sharedAnimator;
                anim.avatar = enemyData.sharedAvatar;
                anim.cullingMode = AnimatorCullingMode.CullCompletely;
            }

        }
    }
		
}
