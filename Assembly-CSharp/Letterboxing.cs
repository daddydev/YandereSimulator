using UnityEngine;

// Token: 0x02000122 RID: 290
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour {

  // Token: 0x06000598 RID: 1432 RVA: 0x0004CBE8 File Offset: 0x0004AFE8
  private void Start() {
    float num = (float)Screen.width / (float)Screen.height;
    float num2 = 1f - num / 1.77777779f;
    base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
  }

  // Token: 0x04000D4D RID: 3405
  private const float KEEP_ASPECT = 1.77777779f;
}