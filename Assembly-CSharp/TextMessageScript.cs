using UnityEngine;

// Token: 0x02000151 RID: 337
public class TextMessageScript : MonoBehaviour {

  // Token: 0x06000632 RID: 1586 RVA: 0x00058CF7 File Offset: 0x000570F7
  private void Start() {
    if (!this.Attachment && this.Image != null) {
      this.Image.SetActive(false);
    }
  }

  // Token: 0x06000633 RID: 1587 RVA: 0x00058D21 File Offset: 0x00057121
  private void Update() {
    base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
  }

  // Token: 0x04000F0F RID: 3855
  public UILabel Label;

  // Token: 0x04000F10 RID: 3856
  public GameObject Image;

  // Token: 0x04000F11 RID: 3857
  public bool Attachment;
}