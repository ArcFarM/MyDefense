using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class MainMenu : MonoBehaviour {

        public FadeInOut fadeOutPanel;
        bool flag = true;

        public void PlayGame() {
            flag = true;
            StartCoroutine(LoadScene());
        }
        public void QuitGame() {
            flag = false;
            PlayerPrefs.SetInt("PlayableLevel", PlayerStats.GetBestLevel);
            PlayerPrefs.Save();
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene() {
            //페이드 아웃 애니메이션 시작
            if(flag) yield return StartCoroutine(fadeOutPanel.Do_FadeOut("StageSelect"));
            else {
                yield return StartCoroutine(fadeOutPanel.Do_FadeOut(null));
            }
        }
    }
}
