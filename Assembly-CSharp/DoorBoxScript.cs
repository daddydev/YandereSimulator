using UnityEngine;

// Token: 0x0200008C RID: 140
public class DoorBoxScript : MonoBehaviour {

  // Token: 0x0600022D RID: 557 RVA: 0x0002EE38 File Offset: 0x0002D238
  private void Update() {
    float y = Mathf.Lerp(base.transform.localPosition.y, (!this.Show) ? -630f : -530f, Time.deltaTime * 10f);
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
  }

  // Token: 0x04000790 RID: 1936
  public UILabel Label;

  // Token: 0x04000791 RID: 1937
  public bool Show;
}