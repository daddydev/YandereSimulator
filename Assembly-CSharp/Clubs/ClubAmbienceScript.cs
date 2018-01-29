using UnityEngine;

// Token: 0x02000069 RID: 105
public class ClubAmbienceScript : MonoBehaviour {

  // Token: 0x0600017A RID: 378 RVA: 0x00019130 File Offset: 0x00017530
  private void Update() {
    if (this.Yandere.position.y > base.transform.position.y - 0.1f && this.Yandere.position.y < base.transform.position.y + 0.1f) {
      if (Vector3.Distance(base.transform.position, this.Yandere.position) < 4f) {
        this.CreateAmbience = true;
        this.EffectJukebox = true;
      } else {
        this.CreateAmbience = false;
      }
    }
    if (this.EffectJukebox) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.CreateAmbience) {
        component.volume = Mathf.MoveTowards(component.volume, this.MaxVolume, Time.deltaTime * 0.1f);
        this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
      } else {
        component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime * 0.1f);
        this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, 0f, Time.deltaTime * 0.1f);
        if (this.Jukebox.ClubDip == 0f) {
          this.EffectJukebox = false;
        }
      }
    }
  }

  // Token: 0x0400048F RID: 1167
  public JukeboxScript Jukebox;

  // Token: 0x04000490 RID: 1168
  public Transform Yandere;

  // Token: 0x04000491 RID: 1169
  public bool CreateAmbience;

  // Token: 0x04000492 RID: 1170
  public bool EffectJukebox;

  // Token: 0x04000493 RID: 1171
  public float ClubDip;

  // Token: 0x04000494 RID: 1172
  public float MaxVolume;
}