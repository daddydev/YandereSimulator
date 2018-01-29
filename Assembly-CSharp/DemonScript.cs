using UnityEngine;

// Token: 0x02000085 RID: 133
public class DemonScript : MonoBehaviour {

  // Token: 0x06000219 RID: 537 RVA: 0x0002B7F4 File Offset: 0x00029BF4
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      this.Communing = true;
    }
    if (this.Communing) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.Phase == 1) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        if (this.Darkness.color.a == 1f) {
          this.DemonSubtitle.transform.localPosition = Vector3.zero;
          this.DemonSubtitle.text = this.Lines[this.ID];
          this.DemonSubtitle.color = this.MyColor;
          this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
          this.Phase++;
          if (this.Clips[this.ID] != null) {
            component.clip = this.Clips[this.ID];
            component.Play();
          }
        }
      } else if (this.Phase == 2) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 1f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A")) {
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 0f) {
          this.ID++;
          if (this.ID < this.Lines.Length) {
            this.Phase--;
            this.DemonSubtitle.text = this.Lines[this.ID];
            if (this.Clips[this.ID] != null) {
              component.clip = this.Clips[this.ID];
              component.Play();
            }
          } else {
            this.Phase++;
          }
        }
      } else {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f) {
          this.Yandere.CanMove = true;
          this.Communing = false;
          this.Phase = 1;
          this.ID = 0;
          SchoolGlobals.SetDemonActive(this.DemonID, true);
          GameGlobals.Paranormal = true;
        }
      }
    }
  }

  // Token: 0x04000748 RID: 1864
  public YandereScript Yandere;

  // Token: 0x04000749 RID: 1865
  public PromptScript Prompt;

  // Token: 0x0400074A RID: 1866
  public UILabel DemonSubtitle;

  // Token: 0x0400074B RID: 1867
  public UISprite Darkness;

  // Token: 0x0400074C RID: 1868
  public UISprite Button;

  // Token: 0x0400074D RID: 1869
  public AudioClip[] Clips;

  // Token: 0x0400074E RID: 1870
  public string[] Lines;

  // Token: 0x0400074F RID: 1871
  public bool Communing;

  // Token: 0x04000750 RID: 1872
  public float Intensity = 1f;

  // Token: 0x04000751 RID: 1873
  public Color MyColor;

  // Token: 0x04000752 RID: 1874
  public int DemonID;

  // Token: 0x04000753 RID: 1875
  public int Phase = 1;

  // Token: 0x04000754 RID: 1876
  public int ID;
}