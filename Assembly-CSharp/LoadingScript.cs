using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000127 RID: 295
public class LoadingScript : MonoBehaviour {

  // Token: 0x060005A6 RID: 1446 RVA: 0x0004E23B File Offset: 0x0004C63B
  private void Start() {
    SceneManager.LoadScene("SchoolScene");
  }
}