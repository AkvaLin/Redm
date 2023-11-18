using System;
using UnityEngine;
using DG.Tweening;

namespace Entities
{
    public class Note: MonoBehaviour
    {
        private Transform triggerEnter = new RectTransform();
        private Transform triggerExit = new RectTransform();
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                DestroyNote();
            }
        }

        public void StartMotion(float speed)
        {
            transform.DOMoveX(40, speed);
        }

        public void DestroyNote()
        {
            transform.DOComplete();
            Destroy(gameObject);
        }
    }
}