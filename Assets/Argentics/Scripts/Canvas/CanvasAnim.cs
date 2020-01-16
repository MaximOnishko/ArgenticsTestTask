using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    [RequireComponent(typeof(Animator))]
    public class CanvasAnim : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private float delay;
        [SerializeField] private float animTime;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            PlatformerCharacter.EDeath += PlatformerCharacter_EDeath;
        }
        private void PlatformerCharacter_EDeath(object sender, System.EventArgs e)
        {
            StartCoroutine(canvasAnim());
        }
        IEnumerator canvasAnim()
        {
            yield return new WaitForSeconds(delay);
            _animator.SetTrigger("Die");

            yield return new WaitForSeconds(animTime + delay);
            Restarter.Instance.RestartLvel();
        }
    }
}
