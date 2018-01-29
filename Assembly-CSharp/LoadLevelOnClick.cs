using UnityEngine;

// Token: 0x0200001D RID: 29
[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour {

  // Token: 0x0600007A RID: 122 RVA: 0x0000A946 File Offset: 0x00008D46
  private void OnClick() {
    if (!string.IsNullOrEmpty(this.levelName)) {
      Application.LoadLevel(this.levelName);
    }
  }

  // Token: 0x04000141 RID: 321
  public string levelName;
}