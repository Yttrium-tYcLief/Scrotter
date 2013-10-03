package com.yttrium.scrotter;

import anywheresoftware.b4a.BA;
import anywheresoftware.b4a.BALayout;
import anywheresoftware.b4a.debug.*;

public class statemanager {
private static statemanager mostCurrent = new statemanager();
public static Object getObject() {
    throw new RuntimeException("Code module does not support this method.");
}
 public anywheresoftware.b4a.keywords.Common __c = null;
public static anywheresoftware.b4a.objects.collections.Map _v5 = null;
public static int _v6 = 0;
public static String _v7 = "";
public static String _v0 = "";
public static anywheresoftware.b4a.objects.collections.Map _vv1 = null;
public com.yttrium.scrotter.main _vvvvvvvvv2 = null;
public static Object[]  _vv2(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.collections.List _list1) throws Exception{
 //BA.debugLineNum = 198;BA.debugLine="Sub getNextItem(list1 As List) As Object()";
 //BA.debugLineNum = 199;BA.debugLine="listPosition = listPosition + 1";
_v6 = (int)(_v6+1);
 //BA.debugLineNum = 200;BA.debugLine="Return list1.Get(listPosition)";
if (true) return (Object[])(_list1.Get(_v6));
 //BA.debugLineNum = 201;BA.debugLine="End Sub";
return null;
}
public static String  _vv3(anywheresoftware.b4a.BA _ba,String _key) throws Exception{
 //BA.debugLineNum = 28;BA.debugLine="Sub GetSetting(Key As String)";
 //BA.debugLineNum = 29;BA.debugLine="Return GetSetting2(Key, \"\")";
if (true) return _vv4(_ba,_key,"");
 //BA.debugLineNum = 30;BA.debugLine="End Sub";
return "";
}
public static String  _vv4(anywheresoftware.b4a.BA _ba,String _key,String _defaultvalue) throws Exception{
String _v = "";
 //BA.debugLineNum = 13;BA.debugLine="Sub GetSetting2(Key As String, DefaultValue As String)";
 //BA.debugLineNum = 14;BA.debugLine="If settings.IsInitialized = False Then";
if (_vv1.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 16;BA.debugLine="If File.Exists(File.DirInternal, settingsFileName) Then";
if (anywheresoftware.b4a.keywords.Common.File.Exists(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v0)) { 
 //BA.debugLineNum = 17;BA.debugLine="settings = File.ReadMap(File.DirInternal, settingsFileName)";
_vv1 = anywheresoftware.b4a.keywords.Common.File.ReadMap(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v0);
 }else {
 //BA.debugLineNum = 19;BA.debugLine="Return DefaultValue";
if (true) return _defaultvalue;
 };
 };
 //BA.debugLineNum = 22;BA.debugLine="Dim v As String";
_v = "";
 //BA.debugLineNum = 23;BA.debugLine="v = settings.GetDefault(Key.ToLowerCase, DefaultValue)";
_v = String.valueOf(_vv1.GetDefault((Object)(_key.toLowerCase()),(Object)(_defaultvalue)));
 //BA.debugLineNum = 24;BA.debugLine="Return v";
if (true) return _v;
 //BA.debugLineNum = 25;BA.debugLine="End Sub";
return "";
}
public static String  _vv5(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.ConcreteViewWrapper _v,anywheresoftware.b4a.objects.collections.List _list1) throws Exception{
Object[] _data = null;
anywheresoftware.b4a.objects.EditTextWrapper _edit = null;
anywheresoftware.b4a.objects.SpinnerWrapper _spinner1 = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _check = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.RadioButtonWrapper _radio = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.ToggleButtonWrapper _toggle = null;
anywheresoftware.b4a.objects.SeekBarWrapper _seek = null;
anywheresoftware.b4a.objects.TabHostWrapper _th = null;
int _i = 0;
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
anywheresoftware.b4a.objects.PanelWrapper _tabparentpanel = null;
anywheresoftware.b4a.objects.ScrollViewWrapper _sv = null;
anywheresoftware.b4a.objects.PanelWrapper _panel1 = null;
 //BA.debugLineNum = 133;BA.debugLine="Sub innerRestoreState(v As View, list1 As List)";
 //BA.debugLineNum = 134;BA.debugLine="Dim data() As Object";
_data = new Object[(int)(0)];
{
int d0 = _data.length;
for (int i0 = 0;i0 < d0;i0++) {
_data[i0] = new Object();
}
}
;
 //BA.debugLineNum = 135;BA.debugLine="If v Is EditText Then";
if (_v.getObjectOrNull() instanceof android.widget.EditText) { 
 //BA.debugLineNum = 136;BA.debugLine="Dim edit As EditText";
_edit = new anywheresoftware.b4a.objects.EditTextWrapper();
 //BA.debugLineNum = 137;BA.debugLine="edit = v";
_edit.setObject((android.widget.EditText)(_v.getObject()));
 //BA.debugLineNum = 138;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 139;BA.debugLine="edit.Text = data(0)";
_edit.setText(_data[(int)(0)]);
 //BA.debugLineNum = 140;BA.debugLine="edit.SelectionStart = data(1)";
_edit.setSelectionStart((int)(BA.ObjectToNumber(_data[(int)(1)])));
 }else if(_v.getObjectOrNull() instanceof anywheresoftware.b4a.objects.SpinnerWrapper.B4ASpinner) { 
 //BA.debugLineNum = 142;BA.debugLine="Dim spinner1 As Spinner";
_spinner1 = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 143;BA.debugLine="spinner1 = v";
_spinner1.setObject((anywheresoftware.b4a.objects.SpinnerWrapper.B4ASpinner)(_v.getObject()));
 //BA.debugLineNum = 144;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 145;BA.debugLine="spinner1.SelectedIndex = data(0)";
_spinner1.setSelectedIndex((int)(BA.ObjectToNumber(_data[(int)(0)])));
 }else if(_v.getObjectOrNull() instanceof android.widget.CheckBox) { 
 //BA.debugLineNum = 147;BA.debugLine="Dim check As CheckBox";
_check = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 148;BA.debugLine="check = v";
_check.setObject((android.widget.CheckBox)(_v.getObject()));
 //BA.debugLineNum = 149;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 150;BA.debugLine="check.Checked = data(0)";
_check.setChecked(BA.ObjectToBoolean(_data[(int)(0)]));
 }else if(_v.getObjectOrNull() instanceof android.widget.RadioButton) { 
 //BA.debugLineNum = 152;BA.debugLine="Dim radio As RadioButton";
_radio = new anywheresoftware.b4a.objects.CompoundButtonWrapper.RadioButtonWrapper();
 //BA.debugLineNum = 153;BA.debugLine="radio = v";
_radio.setObject((android.widget.RadioButton)(_v.getObject()));
 //BA.debugLineNum = 154;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 155;BA.debugLine="radio.Checked = data(0)";
_radio.setChecked(BA.ObjectToBoolean(_data[(int)(0)]));
 }else if(_v.getObjectOrNull() instanceof android.widget.ToggleButton) { 
 //BA.debugLineNum = 157;BA.debugLine="Dim toggle As ToggleButton";
_toggle = new anywheresoftware.b4a.objects.CompoundButtonWrapper.ToggleButtonWrapper();
 //BA.debugLineNum = 158;BA.debugLine="toggle = v";
_toggle.setObject((android.widget.ToggleButton)(_v.getObject()));
 //BA.debugLineNum = 159;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 160;BA.debugLine="toggle.Checked = data(0)";
_toggle.setChecked(BA.ObjectToBoolean(_data[(int)(0)]));
 }else if(_v.getObjectOrNull() instanceof android.widget.SeekBar) { 
 //BA.debugLineNum = 162;BA.debugLine="Dim seek As SeekBar";
_seek = new anywheresoftware.b4a.objects.SeekBarWrapper();
 //BA.debugLineNum = 163;BA.debugLine="seek = v";
_seek.setObject((android.widget.SeekBar)(_v.getObject()));
 //BA.debugLineNum = 164;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 165;BA.debugLine="seek.Value = data(0)";
_seek.setValue((int)(BA.ObjectToNumber(_data[(int)(0)])));
 }else if(_v.getObjectOrNull() instanceof android.widget.TabHost) { 
 //BA.debugLineNum = 167;BA.debugLine="Dim th As TabHost";
_th = new anywheresoftware.b4a.objects.TabHostWrapper();
 //BA.debugLineNum = 168;BA.debugLine="th = v";
_th.setObject((android.widget.TabHost)(_v.getObject()));
 //BA.debugLineNum = 169;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 170;BA.debugLine="For i = 0 To th.TabCount - 1";
{
final double step157 = 1;
final double limit157 = (int)(_th.getTabCount()-1);
for (_i = (int)(0); (step157 > 0 && _i <= limit157) || (step157 < 0 && _i >= limit157); _i += step157) {
 //BA.debugLineNum = 171;BA.debugLine="th.CurrentTab = i";
_th.setCurrentTab(_i);
 }
};
 //BA.debugLineNum = 173;BA.debugLine="th.CurrentTab = data(0)";
_th.setCurrentTab((int)(BA.ObjectToNumber(_data[(int)(0)])));
 //BA.debugLineNum = 174;BA.debugLine="Dim r As Reflector";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
 //BA.debugLineNum = 175;BA.debugLine="r.Target = th";
_r.Target = (Object)(_th.getObject());
 //BA.debugLineNum = 176;BA.debugLine="Dim tabParentPanel As Panel";
_tabparentpanel = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 177;BA.debugLine="tabParentPanel = r.RunMethod(\"getTabContentView\")";
_tabparentpanel.setObject((android.view.ViewGroup)(_r.RunMethod("getTabContentView")));
 //BA.debugLineNum = 178;BA.debugLine="For i = 0 To tabParentPanel.NumberOfViews - 1";
{
final double step165 = 1;
final double limit165 = (int)(_tabparentpanel.getNumberOfViews()-1);
for (_i = (int)(0); (step165 > 0 && _i <= limit165) || (step165 < 0 && _i >= limit165); _i += step165) {
 //BA.debugLineNum = 179;BA.debugLine="innerRestoreState(tabParentPanel.GetView(i), list1)";
_vv5(_ba,_tabparentpanel.GetView(_i),_list1);
 }
};
 }else if(_v.getObjectOrNull() instanceof android.widget.ScrollView) { 
 //BA.debugLineNum = 182;BA.debugLine="Dim sv As ScrollView";
_sv = new anywheresoftware.b4a.objects.ScrollViewWrapper();
 //BA.debugLineNum = 183;BA.debugLine="sv = v";
_sv.setObject((android.widget.ScrollView)(_v.getObject()));
 //BA.debugLineNum = 184;BA.debugLine="data = getNextItem(list1)";
_data = _vv2(_ba,_list1);
 //BA.debugLineNum = 185;BA.debugLine="sv.ScrollPosition = data(0)";
_sv.setScrollPosition((int)(BA.ObjectToNumber(_data[(int)(0)])));
 //BA.debugLineNum = 186;BA.debugLine="DoEvents";
anywheresoftware.b4a.keywords.Common.DoEvents();
 //BA.debugLineNum = 187;BA.debugLine="sv.ScrollPosition = data(0)";
_sv.setScrollPosition((int)(BA.ObjectToNumber(_data[(int)(0)])));
 //BA.debugLineNum = 188;BA.debugLine="innerRestoreState(sv.Panel, list1)";
_vv5(_ba,(anywheresoftware.b4a.objects.ConcreteViewWrapper) anywheresoftware.b4a.AbsObjectWrapper.ConvertToWrapper(new anywheresoftware.b4a.objects.ConcreteViewWrapper(), (android.view.View)(_sv.getPanel().getObject())),_list1);
 }else if(_v.getObjectOrNull() instanceof android.view.ViewGroup) { 
 //BA.debugLineNum = 190;BA.debugLine="Dim panel1 As Panel";
_panel1 = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 191;BA.debugLine="panel1 = v";
_panel1.setObject((android.view.ViewGroup)(_v.getObject()));
 //BA.debugLineNum = 192;BA.debugLine="For i = 0 To panel1.NumberOfViews - 1";
{
final double step179 = 1;
final double limit179 = (int)(_panel1.getNumberOfViews()-1);
for (_i = (int)(0); (step179 > 0 && _i <= limit179) || (step179 < 0 && _i >= limit179); _i += step179) {
 //BA.debugLineNum = 193;BA.debugLine="innerRestoreState(panel1.GetView(i), list1)";
_vv5(_ba,_panel1.GetView(_i),_list1);
 }
};
 };
 //BA.debugLineNum = 196;BA.debugLine="End Sub";
return "";
}
public static String  _vv6(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.ConcreteViewWrapper _v,anywheresoftware.b4a.objects.collections.List _list1) throws Exception{
Object[] _data = null;
anywheresoftware.b4a.objects.EditTextWrapper _edit = null;
anywheresoftware.b4a.objects.SpinnerWrapper _spinner1 = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _check = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.RadioButtonWrapper _radio = null;
anywheresoftware.b4a.objects.CompoundButtonWrapper.ToggleButtonWrapper _toggle = null;
anywheresoftware.b4a.objects.SeekBarWrapper _seek = null;
anywheresoftware.b4a.objects.TabHostWrapper _th = null;
int _i = 0;
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
anywheresoftware.b4a.objects.PanelWrapper _tabparentpanel = null;
anywheresoftware.b4a.objects.ScrollViewWrapper _sv = null;
anywheresoftware.b4a.objects.PanelWrapper _panel1 = null;
 //BA.debugLineNum = 75;BA.debugLine="Sub innerSaveState(v As View, list1 As List)";
 //BA.debugLineNum = 76;BA.debugLine="Dim data() As Object";
_data = new Object[(int)(0)];
{
int d0 = _data.length;
for (int i0 = 0;i0 < d0;i0++) {
_data[i0] = new Object();
}
}
;
 //BA.debugLineNum = 77;BA.debugLine="If v Is EditText Then";
if (_v.getObjectOrNull() instanceof android.widget.EditText) { 
 //BA.debugLineNum = 78;BA.debugLine="Dim edit As EditText";
_edit = new anywheresoftware.b4a.objects.EditTextWrapper();
 //BA.debugLineNum = 79;BA.debugLine="edit = v";
_edit.setObject((android.widget.EditText)(_v.getObject()));
 //BA.debugLineNum = 80;BA.debugLine="data = Array As Object(edit.Text, edit.SelectionStart)";
_data = new Object[]{(Object)(_edit.getText()),(Object)(_edit.getSelectionStart())};
 }else if(_v.getObjectOrNull() instanceof anywheresoftware.b4a.objects.SpinnerWrapper.B4ASpinner) { 
 //BA.debugLineNum = 82;BA.debugLine="Dim spinner1 As Spinner";
_spinner1 = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 83;BA.debugLine="spinner1 = v";
_spinner1.setObject((anywheresoftware.b4a.objects.SpinnerWrapper.B4ASpinner)(_v.getObject()));
 //BA.debugLineNum = 84;BA.debugLine="data = Array As Object(spinner1.SelectedIndex)";
_data = new Object[]{(Object)(_spinner1.getSelectedIndex())};
 }else if(_v.getObjectOrNull() instanceof android.widget.CheckBox) { 
 //BA.debugLineNum = 86;BA.debugLine="Dim check As CheckBox";
_check = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 87;BA.debugLine="check = v";
_check.setObject((android.widget.CheckBox)(_v.getObject()));
 //BA.debugLineNum = 88;BA.debugLine="data = Array As Object(check.Checked)";
_data = new Object[]{(Object)(_check.getChecked())};
 }else if(_v.getObjectOrNull() instanceof android.widget.RadioButton) { 
 //BA.debugLineNum = 90;BA.debugLine="Dim radio As RadioButton";
_radio = new anywheresoftware.b4a.objects.CompoundButtonWrapper.RadioButtonWrapper();
 //BA.debugLineNum = 91;BA.debugLine="radio = v";
_radio.setObject((android.widget.RadioButton)(_v.getObject()));
 //BA.debugLineNum = 92;BA.debugLine="data = Array As Object(radio.Checked)";
_data = new Object[]{(Object)(_radio.getChecked())};
 }else if(_v.getObjectOrNull() instanceof android.widget.ToggleButton) { 
 //BA.debugLineNum = 94;BA.debugLine="Dim toggle As ToggleButton";
_toggle = new anywheresoftware.b4a.objects.CompoundButtonWrapper.ToggleButtonWrapper();
 //BA.debugLineNum = 95;BA.debugLine="toggle = v";
_toggle.setObject((android.widget.ToggleButton)(_v.getObject()));
 //BA.debugLineNum = 96;BA.debugLine="data = Array As Object(toggle.Checked)";
_data = new Object[]{(Object)(_toggle.getChecked())};
 }else if(_v.getObjectOrNull() instanceof android.widget.SeekBar) { 
 //BA.debugLineNum = 98;BA.debugLine="Dim seek As SeekBar";
_seek = new anywheresoftware.b4a.objects.SeekBarWrapper();
 //BA.debugLineNum = 99;BA.debugLine="seek = v";
_seek.setObject((android.widget.SeekBar)(_v.getObject()));
 //BA.debugLineNum = 100;BA.debugLine="data = Array As Object(seek.Value)";
_data = new Object[]{(Object)(_seek.getValue())};
 }else if(_v.getObjectOrNull() instanceof android.widget.TabHost) { 
 //BA.debugLineNum = 102;BA.debugLine="Dim th As TabHost";
_th = new anywheresoftware.b4a.objects.TabHostWrapper();
 //BA.debugLineNum = 103;BA.debugLine="th = v";
_th.setObject((android.widget.TabHost)(_v.getObject()));
 //BA.debugLineNum = 104;BA.debugLine="data = Array As Object(th.CurrentTab)";
_data = new Object[]{(Object)(_th.getCurrentTab())};
 //BA.debugLineNum = 105;BA.debugLine="For i = 0 To th.TabCount - 1";
{
final double step92 = 1;
final double limit92 = (int)(_th.getTabCount()-1);
for (_i = (int)(0); (step92 > 0 && _i <= limit92) || (step92 < 0 && _i >= limit92); _i += step92) {
 //BA.debugLineNum = 106;BA.debugLine="th.CurrentTab = i";
_th.setCurrentTab(_i);
 }
};
 //BA.debugLineNum = 108;BA.debugLine="list1.Add(data)";
_list1.Add((Object)(_data));
 //BA.debugLineNum = 109;BA.debugLine="Dim data() As Object";
_data = new Object[(int)(0)];
{
int d0 = _data.length;
for (int i0 = 0;i0 < d0;i0++) {
_data[i0] = new Object();
}
}
;
 //BA.debugLineNum = 110;BA.debugLine="Dim r As Reflector";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
 //BA.debugLineNum = 111;BA.debugLine="r.Target = th";
_r.Target = (Object)(_th.getObject());
 //BA.debugLineNum = 112;BA.debugLine="Dim tabParentPanel As Panel";
_tabparentpanel = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 113;BA.debugLine="tabParentPanel = r.RunMethod(\"getTabContentView\")";
_tabparentpanel.setObject((android.view.ViewGroup)(_r.RunMethod("getTabContentView")));
 //BA.debugLineNum = 114;BA.debugLine="For i = 0 To tabParentPanel.NumberOfViews - 1";
{
final double step101 = 1;
final double limit101 = (int)(_tabparentpanel.getNumberOfViews()-1);
for (_i = (int)(0); (step101 > 0 && _i <= limit101) || (step101 < 0 && _i >= limit101); _i += step101) {
 //BA.debugLineNum = 115;BA.debugLine="innerSaveState(tabParentPanel.GetView(i), list1)";
_vv6(_ba,_tabparentpanel.GetView(_i),_list1);
 }
};
 }else if(_v.getObjectOrNull() instanceof android.widget.ScrollView) { 
 //BA.debugLineNum = 118;BA.debugLine="Dim sv As ScrollView";
_sv = new anywheresoftware.b4a.objects.ScrollViewWrapper();
 //BA.debugLineNum = 119;BA.debugLine="sv = v";
_sv.setObject((android.widget.ScrollView)(_v.getObject()));
 //BA.debugLineNum = 120;BA.debugLine="data = Array As Object(sv.ScrollPosition)";
_data = new Object[]{(Object)(_sv.getScrollPosition())};
 //BA.debugLineNum = 121;BA.debugLine="list1.Add(data)";
_list1.Add((Object)(_data));
 //BA.debugLineNum = 122;BA.debugLine="Dim data() As Object";
_data = new Object[(int)(0)];
{
int d0 = _data.length;
for (int i0 = 0;i0 < d0;i0++) {
_data[i0] = new Object();
}
}
;
 //BA.debugLineNum = 123;BA.debugLine="innerSaveState(sv.Panel, list1)";
_vv6(_ba,(anywheresoftware.b4a.objects.ConcreteViewWrapper) anywheresoftware.b4a.AbsObjectWrapper.ConvertToWrapper(new anywheresoftware.b4a.objects.ConcreteViewWrapper(), (android.view.View)(_sv.getPanel().getObject())),_list1);
 }else if(_v.getObjectOrNull() instanceof android.view.ViewGroup) { 
 //BA.debugLineNum = 125;BA.debugLine="Dim panel1 As Panel";
_panel1 = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 126;BA.debugLine="panel1 = v";
_panel1.setObject((android.view.ViewGroup)(_v.getObject()));
 //BA.debugLineNum = 127;BA.debugLine="For i = 0 To panel1.NumberOfViews - 1";
{
final double step114 = 1;
final double limit114 = (int)(_panel1.getNumberOfViews()-1);
for (_i = (int)(0); (step114 > 0 && _i <= limit114) || (step114 < 0 && _i >= limit114); _i += step114) {
 //BA.debugLineNum = 128;BA.debugLine="innerSaveState(panel1.GetView(i), list1)";
_vv6(_ba,_panel1.GetView(_i),_list1);
 }
};
 };
 //BA.debugLineNum = 131;BA.debugLine="If data.Length > 0 Then list1.Add(data)";
if (_data.length>0) { 
_list1.Add((Object)(_data));};
 //BA.debugLineNum = 132;BA.debugLine="End Sub";
return "";
}
public static String  _vv7(anywheresoftware.b4a.BA _ba) throws Exception{
anywheresoftware.b4a.randomaccessfile.RandomAccessFile _raf = null;
 //BA.debugLineNum = 232;BA.debugLine="Sub loadStateFile";
 //BA.debugLineNum = 234;BA.debugLine="If states.IsInitialized Then Return";
if (_v5.IsInitialized()) { 
if (true) return "";};
 //BA.debugLineNum = 235;BA.debugLine="If File.Exists(File.DirInternal, statesFileName) Then";
if (anywheresoftware.b4a.keywords.Common.File.Exists(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v7)) { 
 //BA.debugLineNum = 236;BA.debugLine="Dim raf As RandomAccessFile";
_raf = new anywheresoftware.b4a.randomaccessfile.RandomAccessFile();
 //BA.debugLineNum = 237;BA.debugLine="raf.Initialize(File.DirInternal, statesFileName, False)";
_raf.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v7,anywheresoftware.b4a.keywords.Common.False);
 //BA.debugLineNum = 238;BA.debugLine="states = raf.ReadObject(0)";
_v5.setObject((anywheresoftware.b4a.objects.collections.Map.MyMap)(_raf.ReadObject((long)(0))));
 //BA.debugLineNum = 239;BA.debugLine="raf.Close";
_raf.Close();
 };
 //BA.debugLineNum = 241;BA.debugLine="End Sub";
return "";
}
public static String  _process_globals() throws Exception{
 //BA.debugLineNum = 3;BA.debugLine="Sub Process_Globals";
 //BA.debugLineNum = 4;BA.debugLine="Dim states As Map";
_v5 = new anywheresoftware.b4a.objects.collections.Map();
 //BA.debugLineNum = 5;BA.debugLine="Dim listPosition As Int";
_v6 = 0;
 //BA.debugLineNum = 6;BA.debugLine="Dim statesFileName, settingsFileName As String";
_v7 = "";
_v0 = "";
 //BA.debugLineNum = 7;BA.debugLine="statesFileName = \"state.dat\"";
_v7 = BA.__b (new byte[] {36,49,-13,97,55,106,-22,55,44}, 819375);
 //BA.debugLineNum = 8;BA.debugLine="settingsFileName = \"settings.properties\"";
_v0 = BA.__b (new byte[] {36,33,34,-99,59,43,45,-39,118,49,62,-125,55,45,59,-36,54,32,40}, 10989);
 //BA.debugLineNum = 9;BA.debugLine="Dim settings As Map";
_vv1 = new anywheresoftware.b4a.objects.collections.Map();
 //BA.debugLineNum = 10;BA.debugLine="End Sub";
return "";
}
public static String  _vv0(anywheresoftware.b4a.BA _ba,String _activityname) throws Exception{
 //BA.debugLineNum = 50;BA.debugLine="Sub ResetState(ActivityName As String)";
 //BA.debugLineNum = 51;BA.debugLine="loadStateFile";
_vv7(_ba);
 //BA.debugLineNum = 52;BA.debugLine="If states.IsInitialized Then";
if (_v5.IsInitialized()) { 
 //BA.debugLineNum = 53;BA.debugLine="states.Remove(ActivityName.ToLowerCase)";
_v5.Remove((Object)(_activityname.toLowerCase()));
 //BA.debugLineNum = 54;BA.debugLine="writeStateToFile";
_vvv5(_ba);
 };
 //BA.debugLineNum = 56;BA.debugLine="End Sub";
return "";
}
public static boolean  _vvv1(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.ActivityWrapper _activity,String _activityname,int _validperiodinminutes) throws Exception{
anywheresoftware.b4a.objects.collections.List _list1 = null;
long _time = 0L;
int _i = 0;
 //BA.debugLineNum = 206;BA.debugLine="Sub RestoreState(Activity As Activity, ActivityName As String, ValidPeriodInMinutes As Int) As Boolean";
 //BA.debugLineNum = 207;BA.debugLine="Try";
try { //BA.debugLineNum = 208;BA.debugLine="loadStateFile";
_vv7(_ba);
 //BA.debugLineNum = 209;BA.debugLine="If states.IsInitialized = False Then";
if (_v5.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 210;BA.debugLine="Return False";
if (true) return anywheresoftware.b4a.keywords.Common.False;
 };
 //BA.debugLineNum = 212;BA.debugLine="Dim list1 As List";
_list1 = new anywheresoftware.b4a.objects.collections.List();
 //BA.debugLineNum = 213;BA.debugLine="list1 = states.Get(ActivityName.ToLowerCase)";
_list1.setObject((java.util.List)(_v5.Get((Object)(_activityname.toLowerCase()))));
 //BA.debugLineNum = 214;BA.debugLine="If list1.IsInitialized = False Then Return";
if (_list1.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
if (true) return false;};
 //BA.debugLineNum = 215;BA.debugLine="Dim time As Long";
_time = 0L;
 //BA.debugLineNum = 216;BA.debugLine="time = list1.Get(0)";
_time = BA.ObjectToLongNumber(_list1.Get((int)(0)));
 //BA.debugLineNum = 217;BA.debugLine="If ValidPeriodInMinutes > 0 AND time + ValidPeriodInMinutes * DateTime.TicksPerMinute < DateTime.Now Then";
if (_validperiodinminutes>0 && _time+_validperiodinminutes*anywheresoftware.b4a.keywords.Common.DateTime.TicksPerMinute<anywheresoftware.b4a.keywords.Common.DateTime.getNow()) { 
 //BA.debugLineNum = 218;BA.debugLine="Return False";
if (true) return anywheresoftware.b4a.keywords.Common.False;
 };
 //BA.debugLineNum = 220;BA.debugLine="listPosition = 0";
_v6 = (int)(0);
 //BA.debugLineNum = 221;BA.debugLine="For i = 0 To Activity.NumberOfViews - 1";
{
final double step203 = 1;
final double limit203 = (int)(_activity.getNumberOfViews()-1);
for (_i = (int)(0); (step203 > 0 && _i <= limit203) || (step203 < 0 && _i >= limit203); _i += step203) {
 //BA.debugLineNum = 222;BA.debugLine="innerRestoreState(Activity.GetView(i), list1)";
_vv5(_ba,_activity.GetView(_i),_list1);
 }
};
 //BA.debugLineNum = 224;BA.debugLine="Return True";
if (true) return anywheresoftware.b4a.keywords.Common.True;
 } 
       catch (Exception e208) {
			(_ba.processBA == null ? _ba : _ba.processBA).setLastException(e208); //BA.debugLineNum = 226;BA.debugLine="Log(\"Error loading state.\")";
anywheresoftware.b4a.keywords.Common.Log("Error loading state.");
 //BA.debugLineNum = 227;BA.debugLine="Log(LastException.Message)";
anywheresoftware.b4a.keywords.Common.Log(anywheresoftware.b4a.keywords.Common.LastException(_ba).getMessage());
 //BA.debugLineNum = 228;BA.debugLine="Return False";
if (true) return anywheresoftware.b4a.keywords.Common.False;
 };
 //BA.debugLineNum = 230;BA.debugLine="End Sub";
return false;
}
public static String  _vvv2(anywheresoftware.b4a.BA _ba) throws Exception{
 //BA.debugLineNum = 43;BA.debugLine="Sub SaveSettings";
 //BA.debugLineNum = 44;BA.debugLine="If settings.IsInitialized Then";
if (_vv1.IsInitialized()) { 
 //BA.debugLineNum = 45;BA.debugLine="File.WriteMap(File.DirInternal, settingsFileName, settings)";
anywheresoftware.b4a.keywords.Common.File.WriteMap(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v0,_vv1);
 };
 //BA.debugLineNum = 47;BA.debugLine="End Sub";
return "";
}
public static String  _vvv3(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.ActivityWrapper _activity,String _activityname) throws Exception{
anywheresoftware.b4a.objects.collections.List _list1 = null;
int _i = 0;
 //BA.debugLineNum = 58;BA.debugLine="Sub SaveState(Activity As Activity, ActivityName As String)";
 //BA.debugLineNum = 59;BA.debugLine="If states.IsInitialized = False Then states.Initialize";
if (_v5.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
_v5.Initialize();};
 //BA.debugLineNum = 60;BA.debugLine="Dim list1 As List";
_list1 = new anywheresoftware.b4a.objects.collections.List();
 //BA.debugLineNum = 61;BA.debugLine="list1.Initialize";
_list1.Initialize();
 //BA.debugLineNum = 62;BA.debugLine="list1.Add(DateTime.Now)";
_list1.Add((Object)(anywheresoftware.b4a.keywords.Common.DateTime.getNow()));
 //BA.debugLineNum = 63;BA.debugLine="For i = 0 To Activity.NumberOfViews - 1";
{
final double step50 = 1;
final double limit50 = (int)(_activity.getNumberOfViews()-1);
for (_i = (int)(0); (step50 > 0 && _i <= limit50) || (step50 < 0 && _i >= limit50); _i += step50) {
 //BA.debugLineNum = 64;BA.debugLine="innerSaveState(Activity.GetView(i), list1)";
_vv6(_ba,_activity.GetView(_i),_list1);
 }
};
 //BA.debugLineNum = 66;BA.debugLine="states.Put(ActivityName.ToLowerCase, list1)";
_v5.Put((Object)(_activityname.toLowerCase()),(Object)(_list1.getObject()));
 //BA.debugLineNum = 67;BA.debugLine="writeStateToFile";
_vvv5(_ba);
 //BA.debugLineNum = 68;BA.debugLine="End Sub";
return "";
}
public static String  _vvv4(anywheresoftware.b4a.BA _ba,String _key,String _value) throws Exception{
 //BA.debugLineNum = 31;BA.debugLine="Sub SetSetting(Key As String, Value As String)";
 //BA.debugLineNum = 32;BA.debugLine="If settings.IsInitialized = False Then";
if (_vv1.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 34;BA.debugLine="If File.Exists(File.DirInternal, settingsFileName) Then";
if (anywheresoftware.b4a.keywords.Common.File.Exists(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v0)) { 
 //BA.debugLineNum = 35;BA.debugLine="settings = File.ReadMap(File.DirInternal, settingsFileName)";
_vv1 = anywheresoftware.b4a.keywords.Common.File.ReadMap(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v0);
 }else {
 //BA.debugLineNum = 37;BA.debugLine="settings.Initialize";
_vv1.Initialize();
 };
 };
 //BA.debugLineNum = 40;BA.debugLine="settings.Put(Key.ToLowerCase, Value)";
_vv1.Put((Object)(_key.toLowerCase()),(Object)(_value));
 //BA.debugLineNum = 41;BA.debugLine="End Sub";
return "";
}
public static String  _vvv5(anywheresoftware.b4a.BA _ba) throws Exception{
anywheresoftware.b4a.randomaccessfile.RandomAccessFile _raf = null;
 //BA.debugLineNum = 69;BA.debugLine="Sub writeStateToFile";
 //BA.debugLineNum = 70;BA.debugLine="Dim raf As RandomAccessFile";
_raf = new anywheresoftware.b4a.randomaccessfile.RandomAccessFile();
 //BA.debugLineNum = 71;BA.debugLine="raf.Initialize(File.DirInternal, statesFileName, False)";
_raf.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),_v7,anywheresoftware.b4a.keywords.Common.False);
 //BA.debugLineNum = 72;BA.debugLine="raf.WriteObject(states, True, raf.CurrentPosition)";
_raf.WriteObject((Object)(_v5.getObject()),anywheresoftware.b4a.keywords.Common.True,_raf.CurrentPosition);
 //BA.debugLineNum = 73;BA.debugLine="raf.Close";
_raf.Close();
 //BA.debugLineNum = 74;BA.debugLine="End Sub";
return "";
}
}
