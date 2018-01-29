using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000095 RID: 149
public class EditorManagerScript : MonoBehaviour {

  // Token: 0x0600024F RID: 591 RVA: 0x000319EA File Offset: 0x0002FDEA
  private void Awake() {
    this.buttonIndex = 0;
    this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
  }

  // Token: 0x06000250 RID: 592 RVA: 0x00031A00 File Offset: 0x0002FE00
  private void Start() {
    this.promptBar.Label[0].text = "Select";
    this.promptBar.Label[1].text = "Exit";
    this.promptBar.Label[4].text = "Choose";
    this.promptBar.UpdateButtons();
  }

  // Token: 0x06000251 RID: 593 RVA: 0x00031A60 File Offset: 0x0002FE60
  private void OnEnable() {
    this.promptBar.Label[0].text = "Select";
    this.promptBar.Label[1].text = "Exit";
    this.promptBar.Label[4].text = "Choose";
    this.promptBar.UpdateButtons();
  }

  // Token: 0x06000252 RID: 594 RVA: 0x00031AC0 File Offset: 0x0002FEC0
  public static Dictionary<string, object>[] DeserializeJson(string filename) {
    string path = Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename));
    string value = File.ReadAllText(path);
    return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
  }

  // Token: 0x06000253 RID: 595 RVA: 0x00031AF0 File Offset: 0x0002FEF0
  private void HandleInput() {
    bool buttonDown = Input.GetButtonDown("B");
    if (buttonDown) {
      SceneManager.LoadScene("TitleScene");
    }
    bool tappedUp = this.inputManager.TappedUp;
    bool tappedDown = this.inputManager.TappedDown;
    if (tappedUp) {
      this.buttonIndex = ((this.buttonIndex <= 0) ? 2 : (this.buttonIndex - 1));
    } else if (tappedDown) {
      this.buttonIndex = ((this.buttonIndex >= 2) ? 0 : (this.buttonIndex + 1));
    }
    bool flag = tappedUp || tappedDown;
    if (flag) {
      Transform transform = this.cursorLabel.transform;
      transform.localPosition = new Vector3(transform.localPosition.x, 100f - (float)this.buttonIndex * 100f, transform.localPosition.z);
    }
    bool buttonDown2 = Input.GetButtonDown("A");
    if (buttonDown2) {
      this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
      this.mainPanel.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000254 RID: 596 RVA: 0x00031C1A File Offset: 0x0003001A
  private void Update() {
    this.HandleInput();
  }

  // Token: 0x040007E5 RID: 2021
  [SerializeField]
  private UIPanel mainPanel;

  // Token: 0x040007E6 RID: 2022
  [SerializeField]
  private UIPanel[] editorPanels;

  // Token: 0x040007E7 RID: 2023
  [SerializeField]
  private UILabel cursorLabel;

  // Token: 0x040007E8 RID: 2024
  [SerializeField]
  private PromptBarScript promptBar;

  // Token: 0x040007E9 RID: 2025
  private int buttonIndex;

  // Token: 0x040007EA RID: 2026
  private const int ButtonCount = 3;

  // Token: 0x040007EB RID: 2027
  private InputManagerScript inputManager;
}