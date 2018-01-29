using UnityEngine;

// Token: 0x02000018 RID: 24
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Examples/Envelop Content")]
public class EnvelopContent : MonoBehaviour {

  // Token: 0x06000069 RID: 105 RVA: 0x0000A513 File Offset: 0x00008913
  private void Start() {
    this.mStarted = true;
    this.Execute();
  }

  // Token: 0x0600006A RID: 106 RVA: 0x0000A522 File Offset: 0x00008922
  private void OnEnable() {
    if (this.mStarted) {
      this.Execute();
    }
  }

  // Token: 0x0600006B RID: 107 RVA: 0x0000A538 File Offset: 0x00008938
  [ContextMenu("Execute")]
  public void Execute() {
    if (this.targetRoot == base.transform) {
      Debug.LogError("Target Root object cannot be the same object that has Envelop Content. Make it a sibling instead.", this);
    } else if (NGUITools.IsChild(this.targetRoot, base.transform)) {
      Debug.LogError("Target Root object should not be a parent of Envelop Content. Make it a sibling instead.", this);
    } else {
      Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(base.transform.parent, this.targetRoot, false);
      float num = bounds.min.x + (float)this.padLeft;
      float num2 = bounds.min.y + (float)this.padBottom;
      float num3 = bounds.max.x + (float)this.padRight;
      float num4 = bounds.max.y + (float)this.padTop;
      UIWidget component = base.GetComponent<UIWidget>();
      component.SetRect(num, num2, num3 - num, num4 - num2);
      base.BroadcastMessage("UpdateAnchors", SendMessageOptions.DontRequireReceiver);
    }
  }

  // Token: 0x0400012F RID: 303
  public Transform targetRoot;

  // Token: 0x04000130 RID: 304
  public int padLeft;

  // Token: 0x04000131 RID: 305
  public int padRight;

  // Token: 0x04000132 RID: 306
  public int padBottom;

  // Token: 0x04000133 RID: 307
  public int padTop;

  // Token: 0x04000134 RID: 308
  private bool mStarted;
}