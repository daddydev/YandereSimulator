using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001A3 RID: 419
public class SceneLoader : MonoBehaviour {

  // Token: 0x06000765 RID: 1893 RVA: 0x0006F950 File Offset: 0x0006DD50
  private void Start() {
    Time.timeScale = 1f;
    if (!SchoolGlobals.SchoolAtmosphereSet) {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 1f;
    }
    if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick) {
      Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
      this.loadingText.color = new Color(1f, 0f, 0f, 1f);
      this.crashText.color = new Color(1f, 0f, 0f, 1f);
      this.LightAnimation.SetActive(false);
      this.DarkAnimation.SetActive(true);
    }
    base.StartCoroutine(this.LoadNewScene());
  }

  // Token: 0x06000766 RID: 1894 RVA: 0x0006FA2A File Offset: 0x0006DE2A
  private void Update() {
  }

  // Token: 0x06000767 RID: 1895 RVA: 0x0006FA2C File Offset: 0x0006DE2C
  private IEnumerator LoadNewScene() {
    AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
    while (!async.isDone) {
      yield return null;
    }
    yield break;
  }

  // Token: 0x040012AE RID: 4782
  [SerializeField]
  private UILabel loadingText;

  // Token: 0x040012AF RID: 4783
  [SerializeField]
  private UILabel crashText;

  // Token: 0x040012B0 RID: 4784
  private float timer;

  // Token: 0x040012B1 RID: 4785
  public GameObject LightAnimation;

  // Token: 0x040012B2 RID: 4786
  public GameObject DarkAnimation;
}