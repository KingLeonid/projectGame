using UnityEngine;
using System.Collections;

    public class SpecialEffectsHelper : MonoBehaviour
    {
    public static SpecialEffectsHelper Instance;

    public ParticleSystem searchingObjectEffect;
    public ParticleSystem hintEffect;

    void Awake()
    {
     
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void SearObjEffect(Vector3 position)
    {
        instantiate(searchingObjectEffect, position);
    }

    public void HintEffect(Vector3 position)
    {
        instantiate(hintEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.main.startLifetimeMultiplier
        );

        return newParticleSystem;
    }
}
