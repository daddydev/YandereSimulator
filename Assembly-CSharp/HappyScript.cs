using UnityEngine;

// Token: 0x020000ED RID: 237
public class HappyScript : MonoBehaviour {

  // Token: 0x060004C1 RID: 1217 RVA: 0x0003D8A0 File Offset: 0x0003BCA0
  private void Start() {
    if (this.JSON.Students[33].Name != "Reserved") {
      this.BakeCookies();
    } else {
      for (int i = 1; i < 101; i++) {
        if (this.JSON.Students[i].Gender == 0 && this.JSON.Students[i].Hairstyle == "20" && this.StudentManager.Students[i] != null) {
          this.StudentManager.Students[i].gameObject.SetActive(false);
        }
      }
    }
  }

  // Token: 0x060004C2 RID: 1218 RVA: 0x0003D958 File Offset: 0x0003BD58
  private void Update() {
    if (this.Fun.gameObject.activeInHierarchy) {
      this.Speed += Time.deltaTime * 0.01f;
      this.Fun.position = Vector3.MoveTowards(this.Fun.position, this.Yandere.position, Time.deltaTime * this.Speed);
      this.Fun.LookAt(this.Yandere.position);
      if (Vector3.Distance(this.Fun.position, this.Yandere.position) < 0.5f) {
        Application.Quit();
      }
    }
  }

  // Token: 0x060004C3 RID: 1219 RVA: 0x0003DA04 File Offset: 0x0003BE04
  private void BakeCookies() {
    if (!this.Fun.gameObject.activeInHierarchy) {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 0f;
      this.StudentManager.SetAtmosphere();
      foreach (StudentScript studentScript in this.StudentManager.Students) {
        if (studentScript != null) {
          studentScript.gameObject.SetActive(false);
        }
      }
      this.Yandere.gameObject.GetComponent<YandereScript>().NoDebug = true;
      this.Fun.gameObject.SetActive(true);
      this.Jukebox.SetActive(false);
      this.HUD.enabled = false;
    }
  }

  // Token: 0x04000A81 RID: 2689
  public StudentManagerScript StudentManager;

  // Token: 0x04000A82 RID: 2690
  public JsonScript JSON;

  // Token: 0x04000A83 RID: 2691
  public UIPanel HUD;

  // Token: 0x04000A84 RID: 2692
  public GameObject Jukebox;

  // Token: 0x04000A85 RID: 2693
  public Transform Yandere;

  // Token: 0x04000A86 RID: 2694
  public Transform Fun;

  // Token: 0x04000A87 RID: 2695
  public float Speed;
}