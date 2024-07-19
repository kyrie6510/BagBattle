# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers
from flatbuffers.compat import import_numpy
np = import_numpy()

class TablePropItemRowData(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAs(cls, buf, offset=0):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = TablePropItemRowData()
        x.Init(buf, n + offset)
        return x

    @classmethod
    def GetRootAsTablePropItemRowData(cls, buf, offset=0):
        """This method is deprecated. Please switch to GetRootAs."""
        return cls.GetRootAs(buf, offset)
    # TablePropItemRowData
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # TablePropItemRowData
    def Id(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def Name(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return None

    # TablePropItemRowData
    def PropType(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def ItemGridType(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # TablePropItemRowData
    def ItemGridTypeAsNumpy(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.GetVectorAsNumpy(flatbuffers.number_types.Int32Flags, o)
        return 0

    # TablePropItemRowData
    def ItemGridTypeLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # TablePropItemRowData
    def ItemGridTypeIsNone(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        return o == 0

    # TablePropItemRowData
    def Power(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Float32Flags, o + self._tab.Pos)
        return 0.0

    # TablePropItemRowData
    def Rate(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def Interval(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Float32Flags, o + self._tab.Pos)
        return 0.0

    # TablePropItemRowData
    def Damage(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # TablePropItemRowData
    def DamageAsNumpy(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.GetVectorAsNumpy(flatbuffers.number_types.Int32Flags, o)
        return 0

    # TablePropItemRowData
    def DamageLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # TablePropItemRowData
    def DamageIsNone(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        return o == 0

    # TablePropItemRowData
    def Cost(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def Width(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(22))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def Height(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(24))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def UIWidth(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(26))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def UIHeight(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(28))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int16Flags, o + self._tab.Pos)
        return 0

    # TablePropItemRowData
    def TexturePath(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(30))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return None

def Start(builder): builder.StartObject(14)
def TablePropItemRowDataStart(builder):
    """This method is deprecated. Please switch to Start."""
    return Start(builder)
def AddId(builder, Id): builder.PrependInt16Slot(0, Id, 0)
def TablePropItemRowDataAddId(builder, Id):
    """This method is deprecated. Please switch to AddId."""
    return AddId(builder, Id)
def AddName(builder, Name): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(Name), 0)
def TablePropItemRowDataAddName(builder, Name):
    """This method is deprecated. Please switch to AddName."""
    return AddName(builder, Name)
def AddPropType(builder, PropType): builder.PrependInt16Slot(2, PropType, 0)
def TablePropItemRowDataAddPropType(builder, PropType):
    """This method is deprecated. Please switch to AddPropType."""
    return AddPropType(builder, PropType)
def AddItemGridType(builder, ItemGridType): builder.PrependUOffsetTRelativeSlot(3, flatbuffers.number_types.UOffsetTFlags.py_type(ItemGridType), 0)
def TablePropItemRowDataAddItemGridType(builder, ItemGridType):
    """This method is deprecated. Please switch to AddItemGridType."""
    return AddItemGridType(builder, ItemGridType)
def StartItemGridTypeVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def TablePropItemRowDataStartItemGridTypeVector(builder, numElems):
    """This method is deprecated. Please switch to Start."""
    return StartItemGridTypeVector(builder, numElems)
def AddPower(builder, Power): builder.PrependFloat32Slot(4, Power, 0.0)
def TablePropItemRowDataAddPower(builder, Power):
    """This method is deprecated. Please switch to AddPower."""
    return AddPower(builder, Power)
def AddRate(builder, Rate): builder.PrependInt32Slot(5, Rate, 0)
def TablePropItemRowDataAddRate(builder, Rate):
    """This method is deprecated. Please switch to AddRate."""
    return AddRate(builder, Rate)
def AddInterval(builder, Interval): builder.PrependFloat32Slot(6, Interval, 0.0)
def TablePropItemRowDataAddInterval(builder, Interval):
    """This method is deprecated. Please switch to AddInterval."""
    return AddInterval(builder, Interval)
def AddDamage(builder, Damage): builder.PrependUOffsetTRelativeSlot(7, flatbuffers.number_types.UOffsetTFlags.py_type(Damage), 0)
def TablePropItemRowDataAddDamage(builder, Damage):
    """This method is deprecated. Please switch to AddDamage."""
    return AddDamage(builder, Damage)
def StartDamageVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def TablePropItemRowDataStartDamageVector(builder, numElems):
    """This method is deprecated. Please switch to Start."""
    return StartDamageVector(builder, numElems)
def AddCost(builder, Cost): builder.PrependInt16Slot(8, Cost, 0)
def TablePropItemRowDataAddCost(builder, Cost):
    """This method is deprecated. Please switch to AddCost."""
    return AddCost(builder, Cost)
def AddWidth(builder, Width): builder.PrependInt16Slot(9, Width, 0)
def TablePropItemRowDataAddWidth(builder, Width):
    """This method is deprecated. Please switch to AddWidth."""
    return AddWidth(builder, Width)
def AddHeight(builder, Height): builder.PrependInt16Slot(10, Height, 0)
def TablePropItemRowDataAddHeight(builder, Height):
    """This method is deprecated. Please switch to AddHeight."""
    return AddHeight(builder, Height)
def AddUIWidth(builder, UIWidth): builder.PrependInt16Slot(11, UIWidth, 0)
def TablePropItemRowDataAddUIWidth(builder, UIWidth):
    """This method is deprecated. Please switch to AddUIWidth."""
    return AddUIWidth(builder, UIWidth)
def AddUIHeight(builder, UIHeight): builder.PrependInt16Slot(12, UIHeight, 0)
def TablePropItemRowDataAddUIHeight(builder, UIHeight):
    """This method is deprecated. Please switch to AddUIHeight."""
    return AddUIHeight(builder, UIHeight)
def AddTexturePath(builder, TexturePath): builder.PrependUOffsetTRelativeSlot(13, flatbuffers.number_types.UOffsetTFlags.py_type(TexturePath), 0)
def TablePropItemRowDataAddTexturePath(builder, TexturePath):
    """This method is deprecated. Please switch to AddTexturePath."""
    return AddTexturePath(builder, TexturePath)
def End(builder): return builder.EndObject()
def TablePropItemRowDataEnd(builder):
    """This method is deprecated. Please switch to End."""
    return End(builder)