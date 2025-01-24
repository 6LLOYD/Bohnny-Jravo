using UnityEngine;
using TMPro;
using System;
using System.Collections;

// Je viens de remarquer que j'ai complètement mal compris le sujet initial (à 16h42),
// ce code est hors sujet par rapport à ce qui était demandé.
// En effet mon joueur ralentit au fur et à mesure qu'il collecte de l'argent.4

// Le sujet en question:
// Le personnage peut marcher, courir, se deplacer lentement
// Un element peut déclencher un evement si le personnage ne marche pas lentement pres de lui (distance parametrable)

public class Fonctionalite : MonoBehaviour
{

    public TextMeshProUGUI TextPoids;

    private float _poids = 70.0F;

    private Joueur _joueur;

    public TextMeshProUGUI messageText;

    public int messageCont = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Trouver le joueur dans la scène
        _joueur = UnityEngine.Object.FindFirstObjectByType<Joueur>();

        if (_joueur == null)
        {
            Debug.LogError("Aucun joueur trouvé dans la scène !");
        }

        // Initialiser le message à vide
        messageText.text = "";
        messageText.gameObject.SetActive(false); // Masquer l'objet texte au départ
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Méthode pour afficher un message temporaire
    public void ShowMessage(string message, float duration)
    {
        StartCoroutine(DisplayMessage(message, duration));
    }
    // Coroutine pour afficher et masquer le message après un délai
    private IEnumerator DisplayMessage(string message, float duration)
    {
        messageText.text = message; // Afficher le message
        messageText.gameObject.SetActive(true); // Activer l'objet texte

        // Attendre pendant la durée spécifiée
        yield return new WaitForSeconds(duration);

        messageText.text = ""; // Effacer le message
        messageText.gameObject.SetActive(false); // Masquer l'objet texte
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Argent") || collider.gameObject.CompareTag("Argent-big"))
        {
            if (collider.gameObject.CompareTag("Argent-big"))
            {
                _poids += 00.20F;
            }
            _poids += 00.10F;
            double roundedValue = Math.Round(_poids, 2);
            TextPoids.text = "Poids de Bohnny Jravo : " + roundedValue + " kg";

            if (72.2F > _poids && _poids > 70.8F)
            {
                _joueur.vitessePoids -= 0.05F; // Réduire la vitesse à chaque objet ramassé
                if (messageCont == 0)
                {
                    ShowMessage("' Oh mama! Ce poids, c'est pas juste mes muscles, hein ? Je vais ralentir, mais toujours aussi beau ! '", 10.0f);// Afficher un message temporaire
                    messageCont++;
                }
            }
            if (_poids > 72.3F && _poids < 73.7F)
            {
                _joueur.vitessePoids -= 0.05F; // Réduire la vitesse à chaque objet ramassé
                if (messageCont == 1)
                {
                    ShowMessage("' Oh là là ! Je commence à me sentir comme un frigo sur roulettes. Quelqu'un a vu ma vitesse ?! '", 10.0f); // Afficher un nouveau message temporaire
                    messageCont++;
                }
            }
            if (_poids > 73.8F && _poids < 74.4F)
            {
                _joueur.vitessePoids -= 0.05F; // Réduire la vitesse à chaque objet ramassé
                if (messageCont == 2)
                {
                    ShowMessage("' Whoa ! À ce rythme, je vais finir par ressembler à un tank. Mais un tank sacrément sexy, hein ! '", 10.0f); // Afficher un nouveau message temporaire
                    messageCont++;
                }
            }

            Destroy(collider.gameObject);
        }


    }

}
