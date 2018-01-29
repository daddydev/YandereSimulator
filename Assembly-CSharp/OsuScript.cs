using UnityEngine;

// Token: 0x02000149 RID: 329
public class OsuScript : MonoBehaviour {

  // Token: 0x06000617 RID: 1559 RVA: 0x00055C80 File Offset: 0x00054080
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > this.StartTime) {
      if (this.Button == null && this.New300 == null) {
        this.Button = UnityEngine.Object.Instantiate<GameObject>(this.OsuButton, base.transform.position, Quaternion.identity);
        this.Button.transform.parent = base.transform;
        this.Button.transform.localPosition = new Vector3(UnityEngine.Random.Range(-171f, 171f), UnityEngine.Random.Range(-68f, 68f), 0f);
        this.Button.transform.localEulerAngles = Vector3.zero;
        this.Button.transform.localScale = new Vector3(1f, 1f, 1f);
        UITexture component = this.Button.GetComponent<UITexture>();
        component.mainTexture = this.ButtonTexture;
        component.color = new Color(component.color.r, component.color.g, component.color.b, 0f);
        this.Circle = UnityEngine.Object.Instantiate<GameObject>(this.OsuCircle, base.transform.position, Quaternion.identity);
        this.Circle.transform.parent = base.transform;
        this.Circle.transform.localPosition = this.Button.transform.localPosition;
        this.Circle.transform.localEulerAngles = Vector3.zero;
        this.Circle.transform.localScale = new Vector3(2f, 2f, 2f);
        UITexture component2 = this.Circle.GetComponent<UITexture>();
        component2.mainTexture = this.CircleTexture;
        component2.color = new Color(component2.color.r, component2.color.g, component2.color.b, 0f);
      } else {
        if (this.Button != null) {
          UITexture component3 = this.Button.GetComponent<UITexture>();
          component3.color = new Color(component3.color.r, component3.color.g, component3.color.b, component3.color.a + Time.deltaTime);
          UITexture component4 = this.Circle.GetComponent<UITexture>();
          component4.color = new Color(component4.color.r, component4.color.g, component4.color.b, component4.color.a + Time.deltaTime);
          this.Circle.transform.localScale = new Vector3(this.Circle.transform.localScale.x - Time.deltaTime, this.Circle.transform.localScale.y - Time.deltaTime, this.Circle.transform.localScale.z);
          if (this.Circle.transform.localScale.x <= 0.5f) {
            this.New300 = UnityEngine.Object.Instantiate<GameObject>(this.Osu300, base.transform.position, Quaternion.identity);
            this.New300.transform.parent = base.transform;
            this.New300.transform.localPosition = this.Button.transform.localPosition;
            this.New300.transform.localEulerAngles = Vector3.zero;
            this.New300.transform.localScale = new Vector3(1f, 1f, 1f);
            UnityEngine.Object.Destroy(this.Button);
            UnityEngine.Object.Destroy(this.Circle);
          }
        }
        if (this.New300 != null) {
          UITexture component5 = this.New300.GetComponent<UITexture>();
          component5.color = new Color(component5.color.r, component5.color.g, component5.color.b, component5.color.a - Time.deltaTime);
          if (component5.color.a <= 0f) {
            UnityEngine.Object.Destroy(this.New300);
          }
        }
      }
    }
  }

  // Token: 0x04000E9E RID: 3742
  public GameObject Button;

  // Token: 0x04000E9F RID: 3743
  public GameObject Circle;

  // Token: 0x04000EA0 RID: 3744
  public GameObject New300;

  // Token: 0x04000EA1 RID: 3745
  public GameObject OsuButton;

  // Token: 0x04000EA2 RID: 3746
  public GameObject OsuCircle;

  // Token: 0x04000EA3 RID: 3747
  public GameObject Osu300;

  // Token: 0x04000EA4 RID: 3748
  public Texture ButtonTexture;

  // Token: 0x04000EA5 RID: 3749
  public Texture CircleTexture;

  // Token: 0x04000EA6 RID: 3750
  public float StartTime;

  // Token: 0x04000EA7 RID: 3751
  public float Timer;
}