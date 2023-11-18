using System.Collections;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using Random = System.Random;

namespace Controllers.Battle.SubControllers
{
    public class NoteController: MonoBehaviour
    {
        [SerializeField] private Transform[] tracks;
        [SerializeField] private float delay;
        [SerializeField] private GameObject prefab;
        private bool generate = true;

        private void Start()
        {
            StartCoroutine(CreateNotes());
        }

        private IEnumerator CreateNotes()
        {
            Random rnd = new Random();
            while (generate)
            {
                foreach (var track in tracks)
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        GameObject gameObject = Instantiate(prefab, track.position, prefab.transform.rotation);
                        gameObject.GetComponent<Note>().StartMotion(delay * 40);
                    }
                }

                yield return new WaitForSeconds(delay);
            }
        }
    }
}