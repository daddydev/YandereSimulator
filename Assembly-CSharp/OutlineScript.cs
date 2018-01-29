using HighlightingSystem;
using UnityEngine;

// Token: 0x0200014A RID: 330
public class OutlineScript : MonoBehaviour {

  // Token: 0x06000619 RID: 1561 RVA: 0x0005617C File Offset: 0x0005457C
  public void Awake() {
    this.h = base.GetComponent<Highlighter>();
    if (this.h == null) {
      this.h = base.gameObject.AddComponent<Highlighter>();
    }
  }

  // Token: 0x0600061A RID: 1562 RVA: 0x000561AC File Offset: 0x000545AC
  private void Update() {
    this.h.ConstantOnImmediate(this.color);
  }

  // Token: 0x04000EA8 RID: 3752
  public Highlighter h;

  // Token: 0x04000EA9 RID: 3753
  public Color color = new Color(1f, 1f, 1f, 1f);
}