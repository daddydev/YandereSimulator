using UnityEngine;

// Token: 0x0200021A RID: 538
public class WitnessCameraScript : MonoBehaviour {

  // Token: 0x0600095F RID: 2399 RVA: 0x000A3CE9 File Offset: 0x000A20E9
  private void Start() {
    this.MyCamera.enabled = false;
    this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
  }

  // Token: 0x06000960 RID: 2400 RVA: 0x000A3D1C File Offset: 0x000A211C
  private void Update() {
    if (this.Show) {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.444444448f, Time.deltaTime * 10f));
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, base.transform.localPosition.z + Time.deltaTime * 0.09f);
      this.WitnessTimer += Time.deltaTime;
      if (this.WitnessTimer > 5f) {
        this.WitnessTimer = 0f;
        this.Show = false;
      }
      if (this.Yandere.Struggling) {
        this.WitnessTimer = 0f;
        this.Show = false;
      }
    } else {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
      if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f) {
        this.MyCamera.enabled = false;
        base.transform.parent = null;
      }
    }
  }

  // Token: 0x04001AD7 RID: 6871
  public YandereScript Yandere;

  // Token: 0x04001AD8 RID: 6872
  public Transform WitnessPOV;

  // Token: 0x04001AD9 RID: 6873
  public float WitnessTimer;

  // Token: 0x04001ADA RID: 6874
  public Camera MyCamera;

  // Token: 0x04001ADB RID: 6875
  public bool Show;
}