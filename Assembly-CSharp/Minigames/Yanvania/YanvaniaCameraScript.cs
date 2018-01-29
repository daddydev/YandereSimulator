using UnityEngine;

// Token: 0x02000227 RID: 551
public class YanvaniaCameraScript : MonoBehaviour {

  // Token: 0x060009C7 RID: 2503 RVA: 0x000B260A File Offset: 0x000B0A0A
  private void Start() {
    base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
  }

  // Token: 0x060009C8 RID: 2504 RVA: 0x000B2640 File Offset: 0x000B0A40
  private void FixedUpdate() {
    this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
    if (this.TargetZoom < 0f) {
      this.TargetZoom = 0f;
    }
    if (this.TargetZoom > 3.85f) {
      this.TargetZoom = 3.85f;
    }
    this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
    if (!this.Cutscene) {
      base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f + this.Zoom);
      if (base.transform.position.x > 47.9f) {
        base.transform.position = new Vector3(47.9f, base.transform.position.y, base.transform.position.z);
      }
    } else {
      if (this.StopMusic) {
        AudioSource component = this.Jukebox.GetComponent<AudioSource>();
        component.volume -= Time.deltaTime * ((this.Yanmont.Health <= 0f) ? 0.025f : 0.2f);
        if (component.volume <= 0f) {
          this.StopMusic = false;
        }
      }
      base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34.675f, Time.deltaTime * this.Yanmont.walkSpeed), 8f, -5.85f + this.Zoom);
    }
  }

  // Token: 0x04001D87 RID: 7559
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001D88 RID: 7560
  public GameObject Jukebox;

  // Token: 0x04001D89 RID: 7561
  public bool Cutscene;

  // Token: 0x04001D8A RID: 7562
  public bool StopMusic = true;

  // Token: 0x04001D8B RID: 7563
  public float TargetZoom;

  // Token: 0x04001D8C RID: 7564
  public float Zoom;
}