using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCoeur : MonoBehaviour
{
    [Header("Paramètres du battement")]
    public float vitesseBattement = 2.0f;
    public float forceBattement = 0.2f;
    
    [Header("État de l'animation")]
    public bool animationActive = true;
    
    [Header("Son du battement")]
    public AudioClip sonBattement;
    public AudioSource audioSource;
    
    private Vector3 tailleOriginale;
    private float tempsDernierBattement = 0f;
    private bool sonCree = false;
    
    void Start()
    {
        tailleOriginale = transform.localScale;
        
        // Créer AudioSource si pas assigné
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        // Configurer AudioSource
        audioSource.volume = 0.3f;
        audioSource.spatialBlend = 1.0f; // Son 3D
        audioSource.dopplerLevel = 0.0f;
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 10.0f;
        
        // Créer le son de battement
        CreerSonBattement();
    }
    
    void Update()
    {
        if (animationActive)
        {
            float battement = Mathf.Sin(Time.time * vitesseBattement) * forceBattement;
            transform.localScale = tailleOriginale * (1 + battement);
            
            // JOUER LE SON AU BON MOMENT
            GererSonBattement();
        }
    }
    
    void CreerSonBattement()
    {
        // Créer un clip audio pour le battement de cœur
        int frequenceEchantillonage = 44100;
        int dureeEchantillons = (int)(frequenceEchantillonage * 0.15f); // 0.15 seconde
        
        sonBattement = AudioClip.Create(
            "BattementCoeur",
            dureeEchantillons,
            1, // mono
            frequenceEchantillonage,
            false
        );
        
        float[] data = new float[dureeEchantillons];
        
        for (int i = 0; i < data.Length; i++)
        {
            // Premier battement "LUB" (premier 40%)
            if (i < dureeEchantillons * 0.4f)
            {
                // Fréquence qui descend
                float frequence = 300 - (i / (float)data.Length * 80);
                data[i] = Mathf.Sin(2 * Mathf.PI * frequence * i / frequenceEchantillonage) * 0.4f;
                
                // Enveloppe ADSR
                float envelope = 1.0f;
                if (i < dureeEchantillons * 0.1f) // Attack
                    envelope = i / (dureeEchantillons * 0.1f);
                else // Release
                    envelope = 1.0f - (i - dureeEchantillons * 0.1f) / (dureeEchantillons * 0.3f);
                
                data[i] *= envelope;
            }
            // Deuxième battement "DUB" (40% à 70%)
            else if (i < dureeEchantillons * 0.7f)
            {
                float offset = dureeEchantillons * 0.4f;
                float pos = i - offset;
                float longueurPhase = dureeEchantillons * 0.3f;
                
                // Fréquence plus haute pour "DUB"
                float frequence = 350 - (pos / longueurPhase * 60);
                data[i] = Mathf.Sin(2 * Mathf.PI * frequence * i / frequenceEchantillonage) * 0.3f;
                
                // Enveloppe
                float envelope = 1.0f;
                if (pos < longueurPhase * 0.2f) // Attack
                    envelope = pos / (longueurPhase * 0.2f);
                else // Release
                    envelope = 1.0f - (pos - longueurPhase * 0.2f) / (longueurPhase * 0.8f);
                
                data[i] *= envelope;
            }
            // Silence (dernier 30%)
            else
            {
                data[i] = 0;
            }
        }
        
        sonBattement.SetData(data, 0);
        sonCree = true;
    }
    
    void GererSonBattement()
    {
        // Calculer quand jouer le son (chaque "battement")
        float intervalleBattement = 1f / vitesseBattement;
        
        if (Time.time - tempsDernierBattement >= intervalleBattement)
        {
            if (sonBattement != null && audioSource != null && sonCree)
            {
                audioSource.PlayOneShot(sonBattement);
            }
            tempsDernierBattement = Time.time;
        }
    }
    
    public void ChangerAnimation(bool active)
    {
        animationActive = active;
        if (!active)
        {
            transform.localScale = tailleOriginale;
        }
    }
}