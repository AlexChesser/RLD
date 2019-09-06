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
