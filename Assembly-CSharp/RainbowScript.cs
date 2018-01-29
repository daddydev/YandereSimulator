using UnityEngine;

// Token: 0x02000170 RID: 368
public class RainbowScript : MonoBehaviour {

  // Token: 0x060006D8 RID: 1752 RVA: 0x0006984A File Offset: 0x00067C4A
  private void Start() {
    this.MyRenderer.material.color = Color.red;
    this.cyclesPerSecond = 0.25f;
  }

  // Token: 0x060006D9 RID: 1753 RVA: 0x0006986C File Offset: 0x00067C6C
  private void Update() {
    this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
    this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
  }

  // Token: 0x0400113E RID: 4414
  [SerializeField]
  private Renderer MyRenderer;

  // Token: 0x0400113F RID: 4415
  [SerializeField]
  private float cyclesPerSecond;

  // Token: 0x04001140 RID: 4416
  [SerializeField]
  private float percent;
}