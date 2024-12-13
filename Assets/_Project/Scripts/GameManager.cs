// using UnityEngine;
// using UnityEngine.SceneManagement; // Import for scene management

// namespace UntitledStory {
//     public class GameManager : MonoBehaviour {
//         public static GameManager Instance { get; private set; }

//         private int totalCollectibles = 9; // Total number of collectibles in the scene
//         private int collectedCount; // Current number of collected items

//         public float elapsedTime;
//         public bool timeRunning;

//         public TMPro.TextMeshProUGUI displayTime; // UI Text for time display
//         public TMPro.TextMeshProUGUI displayScore; // UI Text for score display

//         private void Awake() {
//             if (Instance != null && Instance != this) {
//                 Destroy(gameObject);
//             } else {
//                 Instance = this;
//             }
//         }

//         private void Start() {
//             timeRunning = true;
//         }

//         private void Update() {
//             // Update the timer if time is running
//             if (timeRunning) {
//                 elapsedTime += Time.deltaTime;
//                 displayTime.text = elapsedTime.ToString("F2"); // Display the time in the UI
//             }
//         }

//         public void InitializeLevel(int totalCollectiblesCount) {
//             totalCollectibles = totalCollectiblesCount;
//             collectedCount = 0;
//             Debug.Log("First");
//             UpdateUI();
//         }

//          public void AddScore(int scoreIncrement) {
//              collectedCount += scoreIncrement;
//              UpdateUI();

//              if (collectedCount >= 9) {
//                 Debug.Log("Second");
//                  OnLevelComplete();
//              }
//         }

//         private void UpdateUI() {
//             // Update the score display in the UI
//             displayScore.text = $"Score: {collectedCount}/9";
//             Debug.Log($"Score: {collectedCount}/9");
//             Debug.Log("Third");
//         }

//         private void OnLevelComplete() {
//             Debug.Log("Fourth");
//             Debug.Log("Level Complete!");
//             // Load the next scene
//             LoadNextScene();
//         }

//         public void LoadNextScene() {
//             int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get current scene index
//             int nextSceneIndex = currentSceneIndex + 1; // Assume the next scene is the next in build order

//             // Check if the next scene index is valid
//             if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
//                 SceneManager.LoadScene(nextSceneIndex); // Load the next scene
//             } else {
//                 Debug.Log("No more scenes to load. Game Complete!");
//                 // Handle end-of-game logic here (e.g., reload the first level or show credits)
//             }
//         }
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement; // Import for scene management

namespace UntitledStory {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }

        private int totalCollectibles = 9; // Total number of collectibles in the scene
        private int collectedCount; // Current number of collected items

        public float elapsedTime;
        public bool timeRunning;

        public TMPro.TextMeshProUGUI displayTime; // UI Text for time display
        public TMPro.TextMeshProUGUI displayScore; // UI Text for score display

        // Field for the background music (BGM)
        public AudioClip backgroundMusic; // Drag and drop your .mp3 or .wav file here
        private AudioSource audioSource; // The AudioSource component to play the music

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            } else {
                Instance = this;
            }

            // Find or create the AudioSource component
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null) {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        private void Start() {
            timeRunning = true;

            // Play background music when the scene is loaded
            if (backgroundMusic != null) {
                audioSource.clip = backgroundMusic;
                audioSource.loop = true;  // Loop the music
                audioSource.Play();       // Start playing the music
            }
        }

        private void Update() {
            // Update the timer if time is running
            if (timeRunning) {
                elapsedTime += Time.deltaTime;
                displayTime.text = elapsedTime.ToString("F2"); // Display the time in the UI
            }
        }

        public void InitializeLevel(int totalCollectiblesCount) {
            totalCollectibles = totalCollectiblesCount;
            collectedCount = 0;
            Debug.Log("First");
            UpdateUI();
        }

         public void AddScore(int scoreIncrement) {
             collectedCount += scoreIncrement;
             UpdateUI();

             if (collectedCount >= 9) {
                Debug.Log("Second");
                 OnLevelComplete();
             }
        }

        private void UpdateUI() {
            // Update the score display in the UI
            displayScore.text = $"Score: {collectedCount}/9";
            Debug.Log($"Score: {collectedCount}/9");
            Debug.Log("Third");
        }

        private void OnLevelComplete() {
            Debug.Log("Fourth");
            Debug.Log("Level Complete!");
            // Load the next scene
            LoadNextScene();
        }

        public void LoadNextScene() {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get current scene index
            int nextSceneIndex = currentSceneIndex + 1; // Assume the next scene is the next in build order

            // Check if the next scene index is valid
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
                SceneManager.LoadScene(nextSceneIndex); // Load the next scene
            } else {
                Debug.Log("No more scenes to load. Game Complete!");
                // Handle end-of-game logic here (e.g., reload the first level or show credits)
            }
        }
    }
}
