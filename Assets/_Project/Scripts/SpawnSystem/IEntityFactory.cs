using UnityEngine;

namespace UntitledStory {
    public interface IEntityFactory<T> where T : Entity {
        T Create(Transform spawnPoint);
    }
}