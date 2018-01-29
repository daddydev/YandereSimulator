using UnityEngine;

// Token: 0x0200003E RID: 62
public class BlasterScript : MonoBehaviour {

  // Token: 0x060000E2 RID: 226 RVA: 0x00010C0A File Offset: 0x0000F00A
  private void Start() {
    this.Skull.localScale = Vector3.zero;
    this.Beam.localScale = Vector3.zero;
  }

  // Token: 0x060000E3 RID: 227 RVA: 0x00010C2C File Offset: 0x0000F02C
  private void Update() {
    AnimationState animationState = base.GetComponent<Animation>()["Blast"];
    if (animationState.time > 1f) {
      this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3(15f, 1f, 1f), Time.deltaTime * 10f);
      this.Eyes.material.color = new Color(1f, 0f, 0f, 1f);
    }
    if (animationState.time >= animationState.length) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x060000E4 RID: 228 RVA: 0x00010CDC File Offset: 0x0000F0DC
  private void LateUpdate() {
    AnimationState animationState = base.GetComponent<Animation>()["Blast"];
    this.Size = ((animationState.time >= 1.5f) ? Mathf.Lerp(this.Size, 0f, Time.deltaTime * 10f) : Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f));
    this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
  }

  // Token: 0x0400032B RID: 811
  public Transform Skull;

  // Token: 0x0400032C RID: 812
  public Renderer Eyes;

  // Token: 0x0400032D RID: 813
  public Transform Beam;

  // Token: 0x0400032E RID: 814
  public float Size;
}