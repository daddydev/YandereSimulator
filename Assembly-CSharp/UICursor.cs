using UnityEngine;

// Token: 0x02000007 RID: 7
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/Examples/UI Cursor")]
public class UICursor : MonoBehaviour {

  // Token: 0x06000025 RID: 37 RVA: 0x00008D25 File Offset: 0x00007125
  private void Awake() {
    UICursor.instance = this;
  }

  // Token: 0x06000026 RID: 38 RVA: 0x00008D2D File Offset: 0x0000712D
  private void OnDestroy() {
    UICursor.instance = null;
  }

  // Token: 0x06000027 RID: 39 RVA: 0x00008D38 File Offset: 0x00007138
  private void Start() {
    this.mTrans = base.transform;
    this.mSprite = base.GetComponentInChildren<UISprite>();
    if (this.uiCamera == null) {
      this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
    }
    if (this.mSprite != null) {
      this.mAtlas = this.mSprite.atlas;
      this.mSpriteName = this.mSprite.spriteName;
      if (this.mSprite.depth < 100) {
        this.mSprite.depth = 100;
      }
    }
  }

  // Token: 0x06000028 RID: 40 RVA: 0x00008DD8 File Offset: 0x000071D8
  private void Update() {
    Vector3 mousePosition = Input.mousePosition;
    if (this.uiCamera != null) {
      mousePosition.x = Mathf.Clamp01(mousePosition.x / (float)Screen.width);
      mousePosition.y = Mathf.Clamp01(mousePosition.y / (float)Screen.height);
      this.mTrans.position = this.uiCamera.ViewportToWorldPoint(mousePosition);
      if (this.uiCamera.orthographic) {
        Vector3 localPosition = this.mTrans.localPosition;
        localPosition.x = Mathf.Round(localPosition.x);
        localPosition.y = Mathf.Round(localPosition.y);
        this.mTrans.localPosition = localPosition;
      }
    } else {
      mousePosition.x -= (float)Screen.width * 0.5f;
      mousePosition.y -= (float)Screen.height * 0.5f;
      mousePosition.x = Mathf.Round(mousePosition.x);
      mousePosition.y = Mathf.Round(mousePosition.y);
      this.mTrans.localPosition = mousePosition;
    }
  }

  // Token: 0x06000029 RID: 41 RVA: 0x00008F00 File Offset: 0x00007300
  public static void Clear() {
    if (UICursor.instance != null && UICursor.instance.mSprite != null) {
      UICursor.Set(UICursor.instance.mAtlas, UICursor.instance.mSpriteName);
    }
  }

  // Token: 0x0600002A RID: 42 RVA: 0x00008F40 File Offset: 0x00007340
  public static void Set(UIAtlas atlas, string sprite) {
    if (UICursor.instance != null && UICursor.instance.mSprite) {
      UICursor.instance.mSprite.atlas = atlas;
      UICursor.instance.mSprite.spriteName = sprite;
      UICursor.instance.mSprite.MakePixelPerfect();
      UICursor.instance.Update();
    }
  }

  // Token: 0x040000CB RID: 203
  public static UICursor instance;

  // Token: 0x040000CC RID: 204
  public Camera uiCamera;

  // Token: 0x040000CD RID: 205
  private Transform mTrans;

  // Token: 0x040000CE RID: 206
  private UISprite mSprite;

  // Token: 0x040000CF RID: 207
  private UIAtlas mAtlas;

  // Token: 0x040000D0 RID: 208
  private string mSpriteName;
}