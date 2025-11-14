using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionnaireAnatomie : MonoBehaviour
{
    [Header("Références UI")]
    public GameObject textTitreObject;
    public GameObject textDescriptionObject;
    
    [Header("Références Organes")]
    public AnimationCoeur scriptCoeur;
    
    [Header("Informations Éducatives")]
    public string messageAccueil = "Montrez une image d'organe à la caméra pour découvrir ses secrets!";
    public string infoCoeur = "LE CŒUR:\n• Pompe le sang dans tout le corps\n• Bat 100 000 fois par jour\n• Pompe 7 000 litres de sang quotidiennement\n• Taille: 250-350 grammes\n• Son: LUB-DUB caractéristique";
    
    void Start()
    {
        AfficherMessageAccueil();
    }
    
    void AfficherMessageAccueil()
    {
        SetTexteSimple(textTitreObject, "ANATOMIE HUMAINE EN RA");
        SetTexteSimple(textDescriptionObject, messageAccueil);
    }
    
    private void SetTexteSimple(GameObject obj, string message)
    {
        if (obj == null) return;
        
        // Essayer Text standard
        var textStandard = obj.GetComponent<Text>();
        if (textStandard != null)
        {
            textStandard.text = message;
            return;
        }
        
        // Essayer TextMeshPro
        var textTMP = obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (textTMP != null)
        {
            textTMP.text = message;
            return;
        }
        
        Debug.LogWarning("Aucun composant texte trouvé sur: " + obj.name);
    }
    
    // Méthode appelée quand le cœur est détecté
    public void CœurDetecte()
    {
        SetTexteSimple(textTitreObject, "CŒUR DÉTECTÉ - ❤️");
        SetTexteSimple(textDescriptionObject, infoCoeur);
    }
    
    // Méthode pour le bouton d'information
    public void AfficherInfoCoeur()
    {
        CœurDetecte();
    }
    
    // Méthode pour activer/désactiver l'animation
    public void AlternerAnimationCoeur()
    {
        if (scriptCoeur != null)
        {
            scriptCoeur.ChangerAnimation(!scriptCoeur.animationActive);
            
            // Mettre à jour l'interface
            string etat = scriptCoeur.animationActive ? "ON" : "OFF";
            SetTexteSimple(textTitreObject, "ANIMATION CŒUR: " + etat);
        }
    }
    
    // Méthode appelée automatiquement quand le cœur est détecté
    public void OnCoeurDetecte()
    {
        CœurDetecte();
    }
}