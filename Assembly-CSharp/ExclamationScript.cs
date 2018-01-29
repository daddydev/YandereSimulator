using UnityEngine;

// Token: 0x020000B6 RID: 182
public class ExclamationScript : MonoBehaviour {

  // Token: 0x060002C5 RID: 709 RVA: 0x0003525B File Offset: 0x0003365B
  private void Start() {
    base.transform.localScale = Vector3.zero;
    this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
  }

  // Token: 0x060002C6 RID: 710 RVA: 0x0003529C File Offset: 0x0003369C
  private void Update() {
    this.Timer -= Time.deltaTime;
    if (this.Timer > 0f) {
      base.transform.LookAt(Camera.main.transform);
      if (this.Timer > 1.5f) {
        base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * 10f);
        this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
      } else {
        if (base.transform.localScale.x > 0.1f) {
          base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
        } else {
          base.transform.localScale = Vector3.zero;
        }
        this.Alpha = Mathf.Lerp(this.Alpha, 0f, Time.deltaTime * 10f);
        this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
      }
    }
  }

  // Token: 0x040008CC RID: 2252
  public Renderer Graphic;

  // Token: 0x040008CD RID: 2253
  public float Alpha;

  // Token: 0x040008CE RID: 2254
  public float Timer;
}