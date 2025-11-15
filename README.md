#  **Application de Réalité Augmentée - Anatomie Humaine**

---
---

##  **Aperçu**

Ce projet est une **application éducative de réalité augmentée** développée dans le cadre d'un TP universitaire. L'application permet de visualiser des organes humains en 3D grâce à la reconnaissance d'images avec Vuforia.

**Objectifs pédagogiques :**
- Maîtriser la réalité augmentée avec Unity
- Implémenter la reconnaissance d'images avec Vuforia
- Développer des interfaces utilisateur interactives
- Créer des animations et sons programmatiques

---

##  **Fonctionnalités**

### **Reconnaissance d'Organes**
- **Cœur** : Sphère rouge animée avec battement sonore
- **Cerveau** : Cube rose avec informations éducatives
- **Poumons** : Deux sphères roses représentant les poumons

### ** Interactions**
- **Détection automatique** des images cibles
- **Animation réaliste** du cœur (pulsation)
- **Son procédural** de battement cardiaque
- **Interface éducative** avec informations détaillées
- **Boutons interactifs** pour contrôler l'animation



---

##  **Technologies Utilisées**

| Technologie | Version | Usage |
|-------------|---------|-------|
| **Unity** | 2022.3.62f1 | Moteur de jeu et réalité augmentée |
| **Vuforia** | 11.4.4 | Reconnaissance d'images et tracking |
| **C#** | .NET 4.x | Programmation des fonctionnalités |
| **Visual Studio** | 2022 | Environnement de développement |

---

##  **Structure du Projet**

```
AnatomieHumaine-RA/
├──  Assets/
│   ├──  Scenes/
│   │   └── Main.unity              # Scène principale AR
│   ├──  Scripts/
│   │   ├── AnimationCoeur.cs       # Animation et son du cœur
│   │   └── GestionnaireAnatomie.cs # Gestion UI et interactions
│   ├──  Materials/
│   │   ├── Mat_Coeur.mat           # Matériau rouge pour le cœur
│   │   ├── Mat_Cerveau.mat         # Matériau rose pour le cerveau
│   │   └── Mat_Poumon.mat          # Matériau rose clair pour poumons
│   └──  StreamingAssets/
│       └──  Vuforia/
│           └── AnatomieHumaine.xml # Database de reconnaissance
├──  ProjectSettings/             # Configuration Unity
├──  Packages/manifest.json       # Dépendances du projet
├── .gitignore                   # Fichiers ignorés par Git
└──  README.md                    # Documentation du projet
```

---

##  **Installation**

### **Prérequis**
-  Unity 2022.3.62f1 ou version compatible
-  Compte développeur Vuforia


### **Étapes d'installation**
```bash
# 1. Cloner le dépôt
git clone https://github.com/hbenziat1318-cloud/AnatomieHumaine-RA.git

# 2. Ouvrir avec Unity
# - Lancer Unity Hub
# - Add project → Sélectionner le dossier cloné

# 3. Installer les dépendances
# - Ouvrir Window → Package Manager
# - Installer Vuforia Engine AR

# 4. Configurer Vuforia
# - Obtenir une license key sur developer.vuforia.com
# - ARCamera → Vuforia Configuration → Ajouter la license key
```

### **Configuration Vuforia**
1. Créer un compte sur (https://developer.vuforia.com/)
2. Créer une license key "Development"
3. Ajouter la key dans `ARCamera → Vuforia Configuration`
4. Télécharger la database "AnatomieHumaine" et l'importer dans Unity

---

---

## **Démonstration**

<img width="1918" height="1021" alt="image" src="https://github.com/user-attachments/assets/0aa9731d-2805-4c3f-bc5a-4b4053817ab7" />



https://github.com/user-attachments/assets/5782d907-79c1-4c91-83f9-878b9e524a0e


---

##  **Encadrement & Auteur**

-Réalisée par:BENZIAT hana
Encadrée par : Mme.DEROUECH oumaima
- Email: h.benziat1318@uca.ac.ma
-  Université: Cady ayad
-  Cours: Réalité Augmentée et Virtuelle



---

