using UnityEngine;

// Token: 0x02000210 RID: 528
public class VibrateScript : MonoBehaviour {

  // Token: 0x06000934 RID: 2356 RVA: 0x0009F123 File Offset: 0x0009D523
  private void Start() {
    this.Origin = base.transform.localPosition;
  }

  // Token: 0x06000935 RID: 2357 RVA: 0x0009F138 File Offset: 0x0009D538
  private void Update() {
    base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
  }

  // Token: 0x04001A23 RID: 6691
  public Vector3 Origin;
}