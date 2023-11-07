
using UnityEngine;
using UnityEngine.AI;

    [CreateAssetMenu(fileName = "PrefabData", menuName = "ScriptableObjects/PrefabData", order = 1)]
    public class PrefabData : ScriptableObject
    {
        public SkinnedMeshRenderer sharedMeshRenderer;
        public RuntimeAnimatorController sharedAnimator;
        public Avatar sharedAvatar;
        public NavMeshAgent sharedAgent;
        public Material sharedMaterial;
        public AudioClip sharedAudioClip, sharedHitClip;
        public float timeBetweenAttacks ;
        public int attackDamage ;
       
    }

