using UnityEngine;
using UnityEngine.Events;

namespace Etra.StarterAssets.Source.Interactions
{
    public class ObjectCollection : MonoBehaviour
    {
        //From @aMySour
        /*
        The MIT License (MIT)
        Copyright 2023 amysour
        Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
        The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        */

        public bool isCollectable = true; // Whether the object is interactable
        public UnityEvent onCollect; // The event that is called when the object is interacted with
        public itemData scriptablePrefab;

        EtrasStarterAssets.AudioManager audioManager;
        bool hasManager;
        // Start is called before the first frame update
        void Start()
        {
            if (GetComponent<EtrasStarterAssets.AudioManager>() != null)
            {
                hasManager = true;
                audioManager = GetComponent<EtrasStarterAssets.AudioManager>();
            }

        }

        public void Collect()
        {
            // Call the event
            onCollect.Invoke();

        }

        public void SetInteractable(bool collectable)
        {
            // Set the interactable state
            isCollectable = collectable;
        }

        public itemData TakeItem()
        {
            Destroy(gameObject);
            return scriptablePrefab;
        }

        public void PlayAudio()
        {
            if (hasManager)
            {
                audioManager.Play(audioManager.sounds[0]);
            }
        }
    }
}