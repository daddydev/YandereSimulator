using UnityEngine;

// Token: 0x0200013B RID: 315
public class MythTreeScript : MonoBehaviour {

  // Token: 0x060005E5 RID: 1509 RVA: 0x0005210F File Offset: 0x0005050F
  private void Start() {
    if (SchemeGlobals.GetSchemeStage(2) > 2) {
      UnityEngine.Object.Destroy(this);
    }
  }

  // Token: 0x060005E6 RID: 1510 RVA: 0x00052124 File Offset: 0x00050524
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.Spoken) {
      if (SchemeGlobals.GetSchemeStage(2) == 2 && Vector3.Distance(this.Yandere.position, base.transform.position) < 5f) {
        this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
        this.EventSubtitle.text = "...that...ring...";
        this.Jukebox.Dip = 0.5f;
        this.Spoken = true;
        component.Play();
      }
    } else if (!component.isPlaying) {
      this.EventSubtitle.transform.localScale = Vector3.zero;
      this.EventSubtitle.text = string.Empty;
      this.Jukebox.Dip = 1f;
      UnityEngine.Object.Destroy(this);
    }
  }

  // Token: 0x04000E09 RID: 3593
  public UILabel EventSubtitle;

  // Token: 0x04000E0A RID: 3594
  public JukeboxScript Jukebox;

  // Token: 0x04000E0B RID: 3595
  public Transform Yandere;

  // Token: 0x04000E0C RID: 3596
  public bool Spoken;
}