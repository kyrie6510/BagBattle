// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct TablePropItemRowData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static TablePropItemRowData GetRootAsTablePropItemRowData(ByteBuffer _bb) { return GetRootAsTablePropItemRowData(_bb, new TablePropItemRowData()); }
  public static TablePropItemRowData GetRootAsTablePropItemRowData(ByteBuffer _bb, TablePropItemRowData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public TablePropItemRowData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public short Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public string Name { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(6); }
  public short PropType { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public short ItemGridType(int j) { int o = __p.__offset(10); return o != 0 ? __p.bb.GetShort(__p.__vector(o) + j * 2) : (short)0; }
  public int ItemGridTypeLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<short> GetItemGridTypeBytes() { return __p.__vector_as_span<short>(10, 2); }
#else
  public ArraySegment<byte>? GetItemGridTypeBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public short[] GetItemGridTypeArray() { return __p.__vector_as_array<short>(10); }
  public short Width { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public short Height { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public short UIWidth { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public short UIHeight { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public string TexturePath { get { int o = __p.__offset(20); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetTexturePathBytes() { return __p.__vector_as_span<byte>(20, 1); }
#else
  public ArraySegment<byte>? GetTexturePathBytes() { return __p.__vector_as_arraysegment(20); }
#endif
  public byte[] GetTexturePathArray() { return __p.__vector_as_array<byte>(20); }

  public static Offset<TablePropItemRowData> CreateTablePropItemRowData(FlatBufferBuilder builder,
      short Id = 0,
      StringOffset NameOffset = default(StringOffset),
      short PropType = 0,
      VectorOffset ItemGridTypeOffset = default(VectorOffset),
      short Width = 0,
      short Height = 0,
      short UIWidth = 0,
      short UIHeight = 0,
      StringOffset TexturePathOffset = default(StringOffset)) {
    builder.StartTable(9);
    TablePropItemRowData.AddTexturePath(builder, TexturePathOffset);
    TablePropItemRowData.AddItemGridType(builder, ItemGridTypeOffset);
    TablePropItemRowData.AddName(builder, NameOffset);
    TablePropItemRowData.AddUIHeight(builder, UIHeight);
    TablePropItemRowData.AddUIWidth(builder, UIWidth);
    TablePropItemRowData.AddHeight(builder, Height);
    TablePropItemRowData.AddWidth(builder, Width);
    TablePropItemRowData.AddPropType(builder, PropType);
    TablePropItemRowData.AddId(builder, Id);
    return TablePropItemRowData.EndTablePropItemRowData(builder);
  }

  public static void StartTablePropItemRowData(FlatBufferBuilder builder) { builder.StartTable(9); }
  public static void AddId(FlatBufferBuilder builder, short Id) { builder.AddShort(0, Id, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(1, NameOffset.Value, 0); }
  public static void AddPropType(FlatBufferBuilder builder, short PropType) { builder.AddShort(2, PropType, 0); }
  public static void AddItemGridType(FlatBufferBuilder builder, VectorOffset ItemGridTypeOffset) { builder.AddOffset(3, ItemGridTypeOffset.Value, 0); }
  public static VectorOffset CreateItemGridTypeVector(FlatBufferBuilder builder, short[] data) { builder.StartVector(2, data.Length, 2); for (int i = data.Length - 1; i >= 0; i--) builder.AddShort(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateItemGridTypeVectorBlock(FlatBufferBuilder builder, short[] data) { builder.StartVector(2, data.Length, 2); builder.Add(data); return builder.EndVector(); }
  public static void StartItemGridTypeVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(2, numElems, 2); }
  public static void AddWidth(FlatBufferBuilder builder, short Width) { builder.AddShort(4, Width, 0); }
  public static void AddHeight(FlatBufferBuilder builder, short Height) { builder.AddShort(5, Height, 0); }
  public static void AddUIWidth(FlatBufferBuilder builder, short UIWidth) { builder.AddShort(6, UIWidth, 0); }
  public static void AddUIHeight(FlatBufferBuilder builder, short UIHeight) { builder.AddShort(7, UIHeight, 0); }
  public static void AddTexturePath(FlatBufferBuilder builder, StringOffset TexturePathOffset) { builder.AddOffset(8, TexturePathOffset.Value, 0); }
  public static Offset<TablePropItemRowData> EndTablePropItemRowData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TablePropItemRowData>(o);
  }
};

public struct TablePropItem : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static TablePropItem GetRootAsTablePropItem(ByteBuffer _bb) { return GetRootAsTablePropItem(_bb, new TablePropItem()); }
  public static TablePropItem GetRootAsTablePropItem(ByteBuffer _bb, TablePropItem obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public TablePropItem __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public TablePropItemRowData? Datalist(int j) { int o = __p.__offset(4); return o != 0 ? (TablePropItemRowData?)(new TablePropItemRowData()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DatalistLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<TablePropItem> CreateTablePropItem(FlatBufferBuilder builder,
      VectorOffset datalistOffset = default(VectorOffset)) {
    builder.StartTable(1);
    TablePropItem.AddDatalist(builder, datalistOffset);
    return TablePropItem.EndTablePropItem(builder);
  }

  public static void StartTablePropItem(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDatalist(FlatBufferBuilder builder, VectorOffset datalistOffset) { builder.AddOffset(0, datalistOffset.Value, 0); }
  public static VectorOffset CreateDatalistVector(FlatBufferBuilder builder, Offset<TablePropItemRowData>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDatalistVectorBlock(FlatBufferBuilder builder, Offset<TablePropItemRowData>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDatalistVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<TablePropItem> EndTablePropItem(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TablePropItem>(o);
  }
};

