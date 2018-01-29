using UnityEngine;

// Token: 0x02000097 RID: 151
public class RivalEditorScript : MonoBehaviour {

  // Token: 0x0600025B RID: 603 RVA: 0x00031CE8 File Offset: 0x000300E8
  private void Awake() {
    this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
  }

  // Token: 0x0600025C RID: 604 RVA: 0x00031CF8 File Offset: 0x000300F8
  private void OnEnable() {
    this.promptBar.Label[0].text = string.Empty;
    this.promptBar.Label[1].text = "Back";
    this.promptBar.Label[4].text = string.Empty;
    this.promptBar.UpdateButtons();
  }

  // Token: 0x0600025D RID: 605 RVA: 0x00031D58 File Offset: 0x00030158
  private void HandleInput() {
    bool buttonDown = Input.GetButtonDown("B");
    if (buttonDown) {
      this.mainPanel.gameObject.SetActive(true);
      this.rivalPanel.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600025E RID: 606 RVA: 0x00031D98 File Offset: 0x00030198
  private void Update() {
    this.HandleInput();
  }

  // Token: 0x040007F1 RID: 2033
  [SerializeField]
  private UIPanel mainPanel;

  // Token: 0x040007F2 RID: 2034
  [SerializeField]
  private UIPanel rivalPanel;

  // Token: 0x040007F3 RID: 2035
  [SerializeField]
  private UILabel titleLabel;

  // Token: 0x040007F4 RID: 2036
  [SerializeField]
  private PromptBarScript promptBar;

  // Token: 0x040007F5 RID: 2037
  private InputManagerScript inputManager;
}