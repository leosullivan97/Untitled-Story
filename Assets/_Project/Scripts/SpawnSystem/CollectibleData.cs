using UnityEngine;

namespace UntitledStory {
    [CreateAssetMenu(fileName = "CollectibleData", menuName = "UntitledStory/Collectible Data")]
    public class CollectibleData : EntityData {
        [Tooltip("Score increment for this collectible")]
        public int scoreProgress = 1;

        [Tooltip("Sound effect to play when collected")]
        public AudioClip collectSound;
    }
}
