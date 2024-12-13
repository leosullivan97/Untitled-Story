using UnityEngine;

namespace UntitledStory {
    public interface IState {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void OnExit();
    }
}