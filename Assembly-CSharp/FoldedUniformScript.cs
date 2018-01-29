using UnityEngine;

// Token: 0x020000BF RID: 191
public class FoldedUniformScript : MonoBehaviour {

  // Token: 0x060002DE RID: 734 RVA: 0x00036D64 File Offset: 0x00035164
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    if (this.Clean && this.Prompt.Button[0] != null) {
      this.Prompt.HideButton[0] = true;
    }
  }

  // Token: 0x060002DF RID: 735 RVA: 0x00036DB8 File Offset: 0x000351B8
  private void Update() {
    if (this.Clean) {
      this.InPosition = (this.Yandere.transform.position.x > 43f && this.Yandere.transform.position.x < 51f && this.Yandere.transform.position.z > 2f && this.Yandere.transform.position.z < 14f);
      this.Prompt.HideButton[0] = (!this.Yandere.CensorSteam[0].activeInHierarchy || this.Yandere.Bloodiness != 0f || !this.InPosition);
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
        this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_stripping_00");
        this.Yandere.Stripping = true;
        this.Yandere.CanMove = false;
        this.Timer += Time.deltaTime;
      }
      if (this.Timer > 0f) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 1.5f) {
          this.Yandere.Schoolwear = 1;
          this.Yandere.ChangeSchoolwear();
          UnityEngine.Object.Destroy(base.gameObject);
        }
      }
    }
  }

  // Token: 0x04000923 RID: 2339
  public YandereScript Yandere;

  // Token: 0x04000924 RID: 2340
  public PromptScript Prompt;

  // Token: 0x04000925 RID: 2341
  public GameObject SteamCloud;

  // Token: 0x04000926 RID: 2342
  public bool InPosition = true;

  // Token: 0x04000927 RID: 2343
  public bool Clean;

  // Token: 0x04000928 RID: 2344
  public float Timer;

  // Token: 0x04000929 RID: 2345
  public int Type;
}