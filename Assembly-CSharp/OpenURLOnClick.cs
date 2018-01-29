using UnityEngine;

// Token: 0x0200001F RID: 31
public class OpenURLOnClick : MonoBehaviour {

  // Token: 0x0600007F RID: 127 RVA: 0x0000AA10 File Offset: 0x00008E10
  private void OnClick() {
    UILabel component = base.GetComponent<UILabel>();
    if (component != null) {
      string urlAtPosition = component.GetUrlAtPosition(UICamera.lastWorldPosition);
      if (!string.IsNullOrEmpty(urlAtPosition)) {
        Application.OpenURL(urlAtPosition);
      }
    }
  }
}