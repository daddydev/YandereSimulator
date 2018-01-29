using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001BD RID: 445
public class SponsorScript : MonoBehaviour {

  // Token: 0x060007BF RID: 1983 RVA: 0x00076C14 File Offset: 0x00075014
  private void Start() {
    this.Set[1].SetActive(true);
    this.Set[2].SetActive(false);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    base.GetComponent<AudioSource>().Play();
  }

  // Token: 0x060007C0 RID: 1984 RVA: 0x00076C98 File Offset: 0x00075098
  private void Update() {
    this.Timer += Time.deltaTime * 1.33333337f;
    if (this.Timer < 6f) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime * 1.33333337f);
      if (this.Darkness.color.a < 0f) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
        if (Input.anyKeyDown) {
          this.Timer = 6f;
        }
      }
    } else {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 1.33333337f);
      if (this.Darkness.color.a >= 1f) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
        this.Set[this.ID].SetActive(false);
        this.ID++;
        if (this.ID < this.Set.Length) {
          this.Set[this.ID].SetActive(true);
          this.Timer = 0f;
        } else {
          SceneManager.LoadScene("TitleScene");
        }
      }
    }
  }

  // Token: 0x040013E2 RID: 5090
  public GameObject[] Set;

  // Token: 0x040013E3 RID: 5091
  public UISprite Darkness;

  // Token: 0x040013E4 RID: 5092
  public float Timer;

  // Token: 0x040013E5 RID: 5093
  public int ID;
}