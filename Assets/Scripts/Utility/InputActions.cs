using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RLD
{
    public class InputActions
    {
        public void init() {
            RLDControls controls = new RLDControls();
            controls.Menu.Toggle.performed += Toggle_performed;
            controls.Menu.Enable();

            controls.Player.Movement.performed += Movement_performed;
            controls.Player.PrimaryFire.performed += PrimaryFire_performed;
            controls.Player.Enable();
        }

        private void PrimaryFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Debug.Log("Primary Fire");
        }

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Debug.Log("MoveMent:"+obj.ReadValue<Vector2>());
        }

        private GameObject menu;
        private void Toggle_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Debug.Log("Detected Toggle");
            if (menu == null) {
                Scene scene = SceneManager.GetActiveScene();
                GameObject[] roots = scene.GetRootGameObjects();
                foreach (GameObject go in roots) {
                    if (go.name == "UI") {
                        menu = go;
                        break;
                    }
                }
            }
            menu.SetActive(!menu.activeSelf);
        }
    }
}
