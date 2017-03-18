using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using System.Collections;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private UnityStandardAssets.Characters.FirstPerson.MouseLook m_MouseLook;
        public Camera m_Camera;
        
        // Use this for initialization
        void Start()
        {
            m_MouseLook.Init(transform, m_Camera.transform);
        }
        void FixedUpdate()
        {
            m_MouseLook.UpdateCursorLock();
        }
        // Update is called once per frame
        void Update()
        {
            RotateView();
        }
        private void RotateView()
        {
            m_MouseLook.LookRotation(transform, m_Camera.transform);
        }

    }
}
