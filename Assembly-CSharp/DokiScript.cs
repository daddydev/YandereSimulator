using UnityEngine;

// Token: 0x0200008B RID: 139
public class DokiScript : MonoBehaviour {

  // Token: 0x0600022B RID: 555 RVA: 0x0002EB58 File Offset: 0x0002CF58
  private void Update() {
    if (!this.Yandere.Egg) {
      if (this.OtherPrompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        base.enabled = false;
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Circle[0].fillAmount = 1f;
        UnityEngine.Object.Instantiate<GameObject>(this.TransformEffect, this.Yandere.Hips.position, Quaternion.identity);
        this.Yandere.MyRenderer.sharedMesh = this.Yandere.Uniforms[4];
        this.Yandere.MyRenderer.materials[0].mainTexture = this.DokiTexture;
        this.Yandere.MyRenderer.materials[1].mainTexture = this.DokiTexture;
        this.ID++;
        if (this.ID > 4) {
          this.ID = 1;
        }
        this.Credits.SongLabel.text = this.DokiName[this.ID] + " from Doki Doki Literature Club";
        this.Credits.BandLabel.text = "by Team Salvato";
        this.Credits.Panel.enabled = true;
        this.Credits.Slide = true;
        this.Credits.Timer = 0f;
        if (this.ID == 1) {
          this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[0]);
          this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[0]);
        } else {
          this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[1]);
          this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[1]);
        }
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
        this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
        this.Yandere.MyRenderer.materials[2].mainTexture = this.DokiHair[this.ID];
        this.Yandere.Hairstyle = 136 + this.ID;
        this.Yandere.UpdateHair();
      }
    } else {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.enabled = false;
    }
  }

  // Token: 0x04000786 RID: 1926
  public MusicCreditScript Credits;

  // Token: 0x04000787 RID: 1927
  public YandereScript Yandere;

  // Token: 0x04000788 RID: 1928
  public PromptScript OtherPrompt;

  // Token: 0x04000789 RID: 1929
  public PromptScript Prompt;

  // Token: 0x0400078A RID: 1930
  public GameObject TransformEffect;

  // Token: 0x0400078B RID: 1931
  public Texture DokiTexture;

  // Token: 0x0400078C RID: 1932
  public Texture[] DokiSocks;

  // Token: 0x0400078D RID: 1933
  public Texture[] DokiHair;

  // Token: 0x0400078E RID: 1934
  public string[] DokiName;

  // Token: 0x0400078F RID: 1935
  public int ID;
}