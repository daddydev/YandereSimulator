using UnityEngine;

// Token: 0x020000FE RID: 254
public class HomePantyChangerScript : MonoBehaviour {

  // Token: 0x06000500 RID: 1280 RVA: 0x00044260 File Offset: 0x00042660
  private void Start() {
    for (int i = 0; i < this.TotalPanties; i++) {
      this.NewPanties = UnityEngine.Object.Instantiate<GameObject>(this.PantyModels[i], new Vector3(base.transform.position.x, base.transform.position.y - 0.85f, base.transform.position.z - 1f), Quaternion.identity);
      this.NewPanties.transform.parent = this.PantyParent;
      this.NewPanties.GetComponent<HomePantiesScript>().PantyChanger = this;
      this.NewPanties.GetComponent<HomePantiesScript>().ID = i;
      this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, this.PantyParent.transform.localEulerAngles.y + 360f / (float)this.TotalPanties, this.PantyParent.transform.localEulerAngles.z);
    }
    this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, 0f, this.PantyParent.transform.localEulerAngles.z);
    this.PantyParent.transform.localPosition = new Vector3(this.PantyParent.transform.localPosition.x, this.PantyParent.transform.localPosition.y, 1.8f);
    this.UpdatePantyLabels();
    this.PantyParent.transform.localScale = Vector3.zero;
    this.PantyParent.gameObject.SetActive(false);
  }

  // Token: 0x06000501 RID: 1281 RVA: 0x00044450 File Offset: 0x00042850
  private void Update() {
    if (this.HomeWindow.Show) {
      this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.PantyParent.gameObject.SetActive(true);
      if (this.InputManager.TappedRight) {
        this.DestinationReached = false;
        this.TargetRotation += 360f / (float)this.TotalPanties;
        this.Selected++;
        if (this.Selected > this.TotalPanties - 1) {
          this.Selected = 0;
        }
        this.UpdatePantyLabels();
      }
      if (this.InputManager.TappedLeft) {
        this.DestinationReached = false;
        this.TargetRotation -= 360f / (float)this.TotalPanties;
        this.Selected--;
        if (this.Selected < 0) {
          this.Selected = this.TotalPanties - 1;
        }
        this.UpdatePantyLabels();
      }
      this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
      this.PantyParent.localEulerAngles = new Vector3(this.PantyParent.localEulerAngles.x, this.Rotation, this.PantyParent.localEulerAngles.z);
      if (Input.GetButtonDown("A")) {
        PlayerGlobals.PantiesEquipped = this.Selected;
        this.UpdatePantyLabels();
      }
      if (Input.GetButtonDown("B")) {
        this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
        this.HomeCamera.Target = this.HomeCamera.Targets[0];
        this.HomeYandere.CanMove = true;
        this.HomeWindow.Show = false;
      }
    } else {
      this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, Vector3.zero, Time.deltaTime * 10f);
      if (this.PantyParent.localScale.x < 0.01f) {
        this.PantyParent.gameObject.SetActive(false);
      }
    }
  }

  // Token: 0x06000502 RID: 1282 RVA: 0x000446AC File Offset: 0x00042AAC
  private void UpdatePantyLabels() {
    this.PantyNameLabel.text = this.PantyNames[this.Selected];
    this.PantyDescLabel.text = this.PantyDescs[this.Selected];
    this.PantyBuffLabel.text = this.PantyBuffs[this.Selected];
    this.ButtonLabel.text = ((this.Selected != PlayerGlobals.PantiesEquipped) ? "Wear" : "Equipped");
  }

  // Token: 0x04000B8D RID: 2957
  public InputManagerScript InputManager;

  // Token: 0x04000B8E RID: 2958
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B8F RID: 2959
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B90 RID: 2960
  public HomeWindowScript HomeWindow;

  // Token: 0x04000B91 RID: 2961
  private GameObject NewPanties;

  // Token: 0x04000B92 RID: 2962
  public UILabel PantyNameLabel;

  // Token: 0x04000B93 RID: 2963
  public UILabel PantyDescLabel;

  // Token: 0x04000B94 RID: 2964
  public UILabel PantyBuffLabel;

  // Token: 0x04000B95 RID: 2965
  public UILabel ButtonLabel;

  // Token: 0x04000B96 RID: 2966
  public Transform PantyParent;

  // Token: 0x04000B97 RID: 2967
  public bool DestinationReached;

  // Token: 0x04000B98 RID: 2968
  public float TargetRotation;

  // Token: 0x04000B99 RID: 2969
  public float Rotation;

  // Token: 0x04000B9A RID: 2970
  public int TotalPanties;

  // Token: 0x04000B9B RID: 2971
  public int Selected;

  // Token: 0x04000B9C RID: 2972
  public GameObject[] PantyModels;

  // Token: 0x04000B9D RID: 2973
  public string[] PantyNames;

  // Token: 0x04000B9E RID: 2974
  public string[] PantyDescs;

  // Token: 0x04000B9F RID: 2975
  public string[] PantyBuffs;
}