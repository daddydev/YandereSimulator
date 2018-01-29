using UnityEngine;

// Token: 0x02000026 RID: 38
[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour {

  // Token: 0x06000093 RID: 147 RVA: 0x0000B1E6 File Offset: 0x000095E6
  private void Start() {
    this.mBar = base.GetComponent<UIProgressBar>();
    this.mSprite = base.GetComponent<UIBasicSprite>();
    this.Update();
  }

  // Token: 0x06000094 RID: 148 RVA: 0x0000B208 File Offset: 0x00009608
  private void Update() {
    if (this.sprite == null || this.colors.Length == 0) {
      return;
    }
    float num = (!(this.mBar != null)) ? this.mSprite.fillAmount : this.mBar.value;
    num *= (float)(this.colors.Length - 1);
    int num2 = Mathf.FloorToInt(num);
    Color color = this.colors[0];
    if (num2 >= 0) {
      if (num2 + 1 < this.colors.Length) {
        float t = num - (float)num2;
        color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], t);
      } else if (num2 < this.colors.Length) {
        color = this.colors[num2];
      } else {
        color = this.colors[this.colors.Length - 1];
      }
    }
    color.a = this.sprite.color.a;
    this.sprite.color = color;
  }

  // Token: 0x04000159 RID: 345
  public UISprite sprite;

  // Token: 0x0400015A RID: 346
  public Color[] colors = new Color[]
  {
    Color.red,
    Color.yellow,
    Color.green
  };

  // Token: 0x0400015B RID: 347
  private UIProgressBar mBar;

  // Token: 0x0400015C RID: 348
  private UIBasicSprite mSprite;
}