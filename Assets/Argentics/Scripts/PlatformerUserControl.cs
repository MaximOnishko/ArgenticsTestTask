using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Argentics._2D
{
    [RequireComponent(typeof (PlatformerCharacter))]
    public class PlatformerUserControl : MonoBehaviour
    {
        private PlatformerCharacter m_Character;
        private bool m_Jump;
        private bool alive;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter>();
            PlatformerCharacter.EDeath += PlatformerCharacter_EDeath;
            alive = true;
        }

        private void PlatformerCharacter_EDeath(object sender, EventArgs e)
        {
            alive = false;
        }

        private void Update()
        {
            if (!alive)
                return;

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            if (!alive)
                return;
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }
}
