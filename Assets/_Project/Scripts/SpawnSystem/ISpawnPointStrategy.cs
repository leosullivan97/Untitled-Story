using UnityEngine;

namespace UntitledStory {
    public interface ISpawnPointStrategy {
        Transform NextSpawnPoint();
    }
}