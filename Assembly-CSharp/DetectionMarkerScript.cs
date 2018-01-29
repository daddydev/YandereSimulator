using UnityEngine;

// Token: 0x02000088 RID: 136
public class DetectionMarkerScript : MonoBehaviour {

  // Token: 0x06000220 RID: 544 RVA: 0x0002BF98 File Offset: 0x0002A398
  private void Start() {
    base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
    this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
    base.transform.localScale = new Vector3(1f, 1f, 1f);
    this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
  }

  // Token: 0x06000221 RID: 545 RVA: 0x0002C084 File Offset: 0x0002A484
  private void Update() {
    if (this.Tex.color.a > 0f && base.transform != null && this.Target != null) {
      base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
    }
  }

  // Token: 0x0400075A RID: 1882
  public Transform Target;

  // Token: 0x0400075B RID: 1883
  public UITexture Tex;
}