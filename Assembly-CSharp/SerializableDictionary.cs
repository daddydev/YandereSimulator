using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020001F8 RID: 504
public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable {

  // Token: 0x06000907 RID: 2311 RVA: 0x0009EAD5 File Offset: 0x0009CED5
  public SerializableDictionary() {
    this.keys = new List<K>();
    this.values = new List<V>();
  }

  // Token: 0x06000908 RID: 2312 RVA: 0x0009EAF4 File Offset: 0x0009CEF4
  public void OnBeforeSerialize() {
    this.keys.Clear();
    this.values.Clear();
    foreach (KeyValuePair<K, V> keyValuePair in this) {
      this.keys.Add(keyValuePair.Key);
      this.values.Add(keyValuePair.Value);
    }
  }

  // Token: 0x06000909 RID: 2313 RVA: 0x0009EB80 File Offset: 0x0009CF80
  public void OnAfterDeserialize() {
    base.Clear();
    for (int i = 0; i < this.keys.Count; i++) {
      base.Add(this.keys[i], this.values[i]);
    }
  }

  // Token: 0x0600090A RID: 2314 RVA: 0x0009EBCD File Offset: 0x0009CFCD
  public XmlSchema GetSchema() {
    return null;
  }

  // Token: 0x0600090B RID: 2315 RVA: 0x0009EBD0 File Offset: 0x0009CFD0
  public void ReadXml(XmlReader reader) {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
    XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
    bool isEmptyElement = reader.IsEmptyElement;
    reader.Read();
    if (isEmptyElement) {
      return;
    }
    while (reader.NodeType != XmlNodeType.EndElement) {
      reader.ReadStartElement("Item");
      reader.ReadStartElement("Key");
      K key = (K)((object)xmlSerializer.Deserialize(reader));
      reader.ReadEndElement();
      reader.ReadStartElement("Value");
      V value = (V)((object)xmlSerializer2.Deserialize(reader));
      reader.ReadEndElement();
      base.Add(key, value);
      reader.ReadEndElement();
      reader.MoveToContent();
    }
    reader.ReadEndElement();
  }

  // Token: 0x0600090C RID: 2316 RVA: 0x0009EC88 File Offset: 0x0009D088
  public void WriteXml(XmlWriter writer) {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
    XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
    foreach (KeyValuePair<K, V> keyValuePair in this) {
      writer.WriteStartElement("Item");
      writer.WriteStartElement("Key");
      xmlSerializer.Serialize(writer, keyValuePair.Key);
      writer.WriteEndElement();
      writer.WriteStartElement("Value");
      xmlSerializer2.Serialize(writer, keyValuePair.Value);
      writer.WriteEndElement();
      writer.WriteEndElement();
    }
  }

  // Token: 0x04001A15 RID: 6677
  [SerializeField]
  private List<K> keys;

  // Token: 0x04001A16 RID: 6678
  [SerializeField]
  private List<V> values;

  // Token: 0x04001A17 RID: 6679
  private const string XML_Item = "Item";

  // Token: 0x04001A18 RID: 6680
  private const string XML_Key = "Key";

  // Token: 0x04001A19 RID: 6681
  private const string XML_Value = "Value";
}