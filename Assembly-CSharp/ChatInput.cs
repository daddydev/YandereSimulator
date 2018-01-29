using UnityEngine;

// Token: 0x02000016 RID: 22
[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Examples/Chat Input")]
public class ChatInput : MonoBehaviour {

  // Token: 0x06000063 RID: 99 RVA: 0x0000A2A8 File Offset: 0x000086A8
  private void Start() {
    this.mInput = base.GetComponent<UIInput>();
    this.mInput.label.maxLineCount = 1;
    if (this.fillWithDummyData && this.textList != null) {
      for (int i = 0; i < 30; i++) {
        this.textList.Add(string.Concat(new object[]
        {
          (i % 2 != 0) ? "[AAAAAA]" : "[FFFFFF]",
          "This is an example paragraph for the text list, testing line ",
          i,
          "[-]"
        }));
      }
    }
  }

  // Token: 0x06000064 RID: 100 RVA: 0x0000A34C File Offset: 0x0000874C
  public void OnSubmit() {
    if (this.textList != null) {
      string text = NGUIText.StripSymbols(this.mInput.value);
      if (!string.IsNullOrEmpty(text)) {
        this.textList.Add(text);
        this.mInput.value = string.Empty;
        this.mInput.isSelected = false;
      }
    }
  }

  // Token: 0x04000129 RID: 297
  public UITextList textList;

  // Token: 0x0400012A RID: 298
  public bool fillWithDummyData;

  // Token: 0x0400012B RID: 299
  private UIInput mInput;
}