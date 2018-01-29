using UnityEngine;

// Token: 0x02000036 RID: 54
public class ArcTrailScript : MonoBehaviour {

  // Token: 0x060000C3 RID: 195 RVA: 0x0000D0BE File Offset: 0x0000B4BE
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
    }
  }

  // Token: 0x040002D8 RID: 728
  private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

  // Token: 0x040002D9 RID: 729
  public TrailRenderer Trail;
}