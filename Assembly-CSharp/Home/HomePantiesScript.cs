using UnityEngine;

// Token: 0x020000FD RID: 253
public class HomePantiesScript : MonoBehaviour {

  // Token: 0x060004FE RID: 1278 RVA: 0x000441D0 File Offset: 0x000425D0
  private void Update() {
    float y = (this.PantyChanger.Selected != this.ID) ? 0f : (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed);
    base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
  }

  // Token: 0x04000B8A RID: 2954
  public HomePantyChangerScript PantyChanger;

  // Token: 0x04000B8B RID: 2955
  public float RotationSpeed;

  // Token: 0x04000B8C RID: 2956
  public int ID;
}