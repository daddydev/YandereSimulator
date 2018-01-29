using UnityEngine;

// Token: 0x02000096 RID: 150
public class EventEditorScript : MonoBehaviour {

  // Token: 0x06000256 RID: 598 RVA: 0x00031C2A File Offset: 0x0003002A
  private void Awake() {
    this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
  }

  // Token: 0x06000257 RID: 599 RVA: 0x00031C38 File Offset: 0x00030038
  private void OnEnable() {
    this.promptBar.Label[0].text = string.Empty;
    this.promptBar.Label[1].text = "Back";
    this.promptBar.Label[4].text = string.Empty;
    this.promptBar.UpdateButtons();
  }

  // Token: 0x06000258 RID: 600 RVA: 0x00031C98 File Offset: 0x00030098
  private void HandleInput() {
    bool buttonDown = Input.GetButtonDown("B");
    if (buttonDown) {
      this.mainPanel.gameObject.SetActive(true);
      this.eventPanel.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000259 RID: 601 RVA: 0x00031CD8 File Offset: 0x000300D8
  private void Update() {
    this.HandleInput();
  }

  // Token: 0x040007EC RID: 2028
  [SerializeField]
  private UIPanel mainPanel;

  // Token: 0x040007ED RID: 2029
  [SerializeField]
  private UIPanel eventPanel;

  // Token: 0x040007EE RID: 2030
  [SerializeField]
  private UILabel titleLabel;

  // Token: 0x040007EF RID: 2031
  [SerializeField]
  private PromptBarScript promptBar;

  // Token: 0x040007F0 RID: 2032
  private InputManagerScript inputManager;
}