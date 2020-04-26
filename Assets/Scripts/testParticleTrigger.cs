using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testParticleTrigger : MonoBehaviour
{

    public ParticleSystem ps;
    private List<ParticleSystem.Particle> enter;
    private List<ParticleSystem.Particle> exit;
    public int numEnter;
    public int numExit;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();

    }

    private void Update()
    {
        // numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);
        // numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, exit);
    }

    void OnParticleTrigger()
    {
        // particles
        enter = new List<ParticleSystem.Particle>();
        exit = new List<ParticleSystem.Particle>();

        // get
        numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        // numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);
        // numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, exit);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            p.remainingLifetime = 0;
            Debug.Log("triggered particle");
            enter[i] = p;
        }
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            p.startColor = new Color32(0, 255, 0, 255);
            exit[i] = p;
        }

        // set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }

}
