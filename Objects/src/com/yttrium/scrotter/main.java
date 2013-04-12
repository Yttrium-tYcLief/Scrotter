package com.yttrium.scrotter;

import anywheresoftware.b4a.B4AMenuItem;
import android.app.Activity;
import android.os.Bundle;
import anywheresoftware.b4a.BA;
import anywheresoftware.b4a.BALayout;
import anywheresoftware.b4a.B4AActivity;
import anywheresoftware.b4a.ObjectWrapper;
import anywheresoftware.b4a.objects.ActivityWrapper;
import java.lang.reflect.InvocationTargetException;
import anywheresoftware.b4a.B4AUncaughtException;
import anywheresoftware.b4a.debug.*;
import java.lang.ref.WeakReference;

public class main extends Activity implements B4AActivity{
	public static main mostCurrent;
	static boolean afterFirstLayout;
	static boolean isFirst = true;
    private static boolean processGlobalsRun = false;
	BALayout layout;
	public static BA processBA;
	BA activityBA;
    ActivityWrapper _activity;
    java.util.ArrayList<B4AMenuItem> menuItems;
	private static final boolean fullScreen = false;
	private static final boolean includeTitle = false;
    public static WeakReference<Activity> previousOne;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		if (isFirst) {
			processBA = new BA(this.getApplicationContext(), null, null, "com.yttrium.scrotter", "com.yttrium.scrotter.main");
			processBA.loadHtSubs(this.getClass());
	        float deviceScale = getApplicationContext().getResources().getDisplayMetrics().density;
	        BALayout.setDeviceScale(deviceScale);
		}
		else if (previousOne != null) {
			Activity p = previousOne.get();
			if (p != null && p != this) {
                anywheresoftware.b4a.keywords.Common.Log("Killing previous instance (main).");
				p.finish();
			}
		}
		if (!includeTitle) {
        	this.getWindow().requestFeature(android.view.Window.FEATURE_NO_TITLE);
        }
        if (fullScreen) {
        	getWindow().setFlags(android.view.WindowManager.LayoutParams.FLAG_FULLSCREEN,   
        			android.view.WindowManager.LayoutParams.FLAG_FULLSCREEN);
        }
		mostCurrent = this;
        processBA.sharedProcessBA.activityBA = null;
		layout = new BALayout(this);
		setContentView(layout);
		afterFirstLayout = false;
		BA.handler.postDelayed(new WaitForLayout(), 5);

	}
	private static class WaitForLayout implements Runnable {
		public void run() {
			if (afterFirstLayout)
				return;
			if (mostCurrent == null)
				return;
			if (mostCurrent.layout.getWidth() == 0) {
				BA.handler.postDelayed(this, 5);
				return;
			}
			mostCurrent.layout.getLayoutParams().height = mostCurrent.layout.getHeight();
			mostCurrent.layout.getLayoutParams().width = mostCurrent.layout.getWidth();
			afterFirstLayout = true;
			mostCurrent.afterFirstLayout();
		}
	}
	private void afterFirstLayout() {
        if (this != mostCurrent)
			return;
		activityBA = new BA(this, layout, processBA, "com.yttrium.scrotter", "com.yttrium.scrotter.main");
        processBA.sharedProcessBA.activityBA = new java.lang.ref.WeakReference<BA>(activityBA);
        anywheresoftware.b4a.objects.ViewWrapper.lastId = 0;
        _activity = new ActivityWrapper(activityBA, "activity");
        anywheresoftware.b4a.Msgbox.isDismissing = false;
        initializeProcessGlobals();		
        initializeGlobals();
        
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Create, isFirst = " + isFirst + " **");
        processBA.raiseEvent2(null, true, "activity_create", false, isFirst);
		isFirst = false;
		if (this != mostCurrent)
			return;
        processBA.setActivityPaused(false);
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Resume **");
        processBA.raiseEvent(null, "activity_resume");
        if (android.os.Build.VERSION.SDK_INT >= 11) {
			try {
				android.app.Activity.class.getMethod("invalidateOptionsMenu").invoke(this,(Object[]) null);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

	}
	public void addMenuItem(B4AMenuItem item) {
		if (menuItems == null)
			menuItems = new java.util.ArrayList<B4AMenuItem>();
		menuItems.add(item);
	}
	@Override
	public boolean onCreateOptionsMenu(android.view.Menu menu) {
		super.onCreateOptionsMenu(menu);
		if (menuItems == null)
			return false;
		for (B4AMenuItem bmi : menuItems) {
			android.view.MenuItem mi = menu.add(bmi.title);
			if (bmi.drawable != null)
				mi.setIcon(bmi.drawable);
            if (android.os.Build.VERSION.SDK_INT >= 11) {
				try {
                    if (bmi.addToBar) {
				        android.view.MenuItem.class.getMethod("setShowAsAction", int.class).invoke(mi, 1);
                    }
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			mi.setOnMenuItemClickListener(new B4AMenuItemsClickListener(bmi.eventName.toLowerCase(BA.cul)));
		}
		return true;
	}
	private class B4AMenuItemsClickListener implements android.view.MenuItem.OnMenuItemClickListener {
		private final String eventName;
		public B4AMenuItemsClickListener(String eventName) {
			this.eventName = eventName;
		}
		public boolean onMenuItemClick(android.view.MenuItem item) {
			processBA.raiseEvent(item.getTitle(), eventName + "_click");
			return true;
		}
	}
    public static Class<?> getObject() {
		return main.class;
	}
    private Boolean onKeySubExist = null;
    private Boolean onKeyUpSubExist = null;
	@Override
	public boolean onKeyDown(int keyCode, android.view.KeyEvent event) {
		if (onKeySubExist == null)
			onKeySubExist = processBA.subExists("activity_keypress");
		if (onKeySubExist) {
			Boolean res =  (Boolean)processBA.raiseEvent2(_activity, false, "activity_keypress", false, keyCode);
			if (res == null || res == true)
				return true;
            else if (keyCode == anywheresoftware.b4a.keywords.constants.KeyCodes.KEYCODE_BACK) {
				finish();
				return true;
			}
		}
		return super.onKeyDown(keyCode, event);
	}
    @Override
	public boolean onKeyUp(int keyCode, android.view.KeyEvent event) {
		if (onKeyUpSubExist == null)
			onKeyUpSubExist = processBA.subExists("activity_keyup");
		if (onKeyUpSubExist) {
			Boolean res =  (Boolean)processBA.raiseEvent2(_activity, false, "activity_keyup", false, keyCode);
			if (res == null || res == true)
				return true;
		}
		return super.onKeyUp(keyCode, event);
	}
	@Override
	public void onNewIntent(android.content.Intent intent) {
		this.setIntent(intent);
	}
    @Override 
	public void onPause() {
		super.onPause();
        if (_activity == null) //workaround for emulator bug (Issue 2423)
            return;
		anywheresoftware.b4a.Msgbox.dismiss(true);
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Pause, UserClosed = " + activityBA.activity.isFinishing() + " **");
        processBA.raiseEvent2(_activity, true, "activity_pause", false, activityBA.activity.isFinishing());		
        processBA.setActivityPaused(true);
        mostCurrent = null;
        if (!activityBA.activity.isFinishing())
			previousOne = new WeakReference<Activity>(this);
        anywheresoftware.b4a.Msgbox.isDismissing = false;
	}

	@Override
	public void onDestroy() {
        super.onDestroy();
		previousOne = null;
	}
    @Override 
	public void onResume() {
		super.onResume();
        mostCurrent = this;
        anywheresoftware.b4a.Msgbox.isDismissing = false;
        if (activityBA != null) { //will be null during activity create (which waits for AfterLayout).
        	ResumeMessage rm = new ResumeMessage(mostCurrent);
        	BA.handler.post(rm);
        }
	}
    private static class ResumeMessage implements Runnable {
    	private final WeakReference<Activity> activity;
    	public ResumeMessage(Activity activity) {
    		this.activity = new WeakReference<Activity>(activity);
    	}
		public void run() {
			if (mostCurrent == null || mostCurrent != activity.get())
				return;
			processBA.setActivityPaused(false);
            anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Resume **");
		    processBA.raiseEvent(mostCurrent._activity, "activity_resume", (Object[])null);
		}
    }
	@Override
	protected void onActivityResult(int requestCode, int resultCode,
	      android.content.Intent data) {
		processBA.onActivityResult(requestCode, resultCode, data);
	}
	private static void initializeGlobals() {
		processBA.raiseEvent2(null, true, "globals", false, (Object[])null);
	}

public static class _panelinfo{
public boolean IsInitialized;
public int PanelType;
public boolean LayoutLoaded;
public void Initialize() {
IsInitialized = true;
PanelType = 0;
LayoutLoaded = false;
}
@Override
		public String toString() {
			return BA.TypeToString(this, false);
		}}
public anywheresoftware.b4a.keywords.Common __c = null;
public static int _type_settings = 0;
public static int _type_preview = 0;
public static int _type_options = 0;
public static int _fill_parent = 0;
public static int _wrap_content = 0;
public static int _currentpage = 0;
public de.amberhome.viewpager.AHPageContainer _container = null;
public de.amberhome.viewpager.AHViewPager _pager = null;
public de.amberhome.viewpager.AHViewPagerTabs _tabs = null;
public anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _glosscheckbox = null;
public anywheresoftware.b4a.objects.SpinnerWrapper _modelbox = null;
public anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _shadowcheckbox = null;
public anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _stretchcheckbox = null;
public anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper _undershadowcheckbox = null;
public anywheresoftware.b4a.objects.SpinnerWrapper _variantbox = null;
public anywheresoftware.b4a.objects.TabHostWrapper _tabswitcher = null;
public anywheresoftware.b4a.objects.ButtonWrapper _loadbtn = null;
public anywheresoftware.b4a.objects.ButtonWrapper _savebtn = null;
public anywheresoftware.b4a.objects.PanelWrapper _preview = null;
public anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _image3 = null;
public static String  _activity_create(boolean _firsttime) throws Exception{
anywheresoftware.b4a.objects.PanelWrapper _pan = null;
 //BA.debugLineNum = 58;BA.debugLine="Sub Activity_Create(FirstTime As Boolean)";
 //BA.debugLineNum = 60;BA.debugLine="container.Initialize";
mostCurrent._container.Initialize(mostCurrent.activityBA);
 //BA.debugLineNum = 61;BA.debugLine="Dim pan As Panel";
_pan = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 62;BA.debugLine="container.AddPage(CreatePanel(TYPE_SETTINGS, \"Settings\"),\"Settings\")";
mostCurrent._container.AddPage((android.view.View)(_createpanel(_type_settings,"Settings").getObject()),"Settings");
 //BA.debugLineNum = 63;BA.debugLine="container.AddPage(CreatePanel(TYPE_PREVIEW, \"Preview\"),\"Preview\")";
mostCurrent._container.AddPage((android.view.View)(_createpanel(_type_preview,"Preview").getObject()),"Preview");
 //BA.debugLineNum = 64;BA.debugLine="container.AddPage(CreatePanel(TYPE_OPTIONS, \"Options\"),\"Options\")";
mostCurrent._container.AddPage((android.view.View)(_createpanel(_type_options,"Options").getObject()),"Options");
 //BA.debugLineNum = 65;BA.debugLine="pager.Initialize(container, \"Pager\")";
mostCurrent._pager.Initialize(mostCurrent.activityBA,mostCurrent._container,"Pager");
 //BA.debugLineNum = 66;BA.debugLine="tabs.Initialize(pager)";
mostCurrent._tabs.Initialize(mostCurrent.activityBA,mostCurrent._pager);
 //BA.debugLineNum = 67;BA.debugLine="tabs.LineHeight = 5dip";
mostCurrent._tabs.setLineHeight(anywheresoftware.b4a.keywords.Common.DipToCurrent((int)(5)));
 //BA.debugLineNum = 68;BA.debugLine="tabs.UpperCaseTitle = True";
mostCurrent._tabs.setUpperCaseTitle(anywheresoftware.b4a.keywords.Common.True);
 //BA.debugLineNum = 69;BA.debugLine="Activity.AddView(tabs, 0, 0, FILL_PARENT, WRAP_CONTENT)";
mostCurrent._activity.AddView((android.view.View)(mostCurrent._tabs.getObject()),(int)(0),(int)(0),_fill_parent,_wrap_content);
 //BA.debugLineNum = 70;BA.debugLine="Activity.AddView(pager, 0, 29dip, Activity.Width, Activity.Height-29dip)";
mostCurrent._activity.AddView((android.view.View)(mostCurrent._pager.getObject()),(int)(0),anywheresoftware.b4a.keywords.Common.DipToCurrent((int)(29)),mostCurrent._activity.getWidth(),(int)(mostCurrent._activity.getHeight()-anywheresoftware.b4a.keywords.Common.DipToCurrent((int)(29))));
 //BA.debugLineNum = 71;BA.debugLine="tabs.Color = Colors.White";
mostCurrent._tabs.setColor(anywheresoftware.b4a.keywords.Common.Colors.White);
 //BA.debugLineNum = 72;BA.debugLine="tabs.BackgroundColorPressed = Colors.Blue";
mostCurrent._tabs.setBackgroundColorPressed(anywheresoftware.b4a.keywords.Common.Colors.Blue);
 //BA.debugLineNum = 73;BA.debugLine="tabs.LineColorCenter = Colors.DarkGray";
mostCurrent._tabs.setLineColorCenter(anywheresoftware.b4a.keywords.Common.Colors.DarkGray);
 //BA.debugLineNum = 74;BA.debugLine="tabs.TextColor = Colors.LightGray";
mostCurrent._tabs.setTextColor(anywheresoftware.b4a.keywords.Common.Colors.LightGray);
 //BA.debugLineNum = 75;BA.debugLine="tabs.TextColorCenter = Colors.DarkGray";
mostCurrent._tabs.setTextColorCenter(anywheresoftware.b4a.keywords.Common.Colors.DarkGray);
 //BA.debugLineNum = 76;BA.debugLine="End Sub";
return "";
}
public static String  _activity_pause(boolean _userclosed) throws Exception{
 //BA.debugLineNum = 82;BA.debugLine="Sub Activity_Pause (UserClosed As Boolean)";
 //BA.debugLineNum = 83;BA.debugLine="CurrentPage = pager.CurrentPage";
_currentpage = mostCurrent._pager.getCurrentPage();
 //BA.debugLineNum = 84;BA.debugLine="End Sub";
return "";
}
public static String  _activity_resume() throws Exception{
 //BA.debugLineNum = 78;BA.debugLine="Sub Activity_Resume";
 //BA.debugLineNum = 79;BA.debugLine="pager.GotoPage(CurrentPage, False)";
mostCurrent._pager.GotoPage(_currentpage,anywheresoftware.b4a.keywords.Common.False);
 //BA.debugLineNum = 80;BA.debugLine="End Sub";
return "";
}
public static anywheresoftware.b4a.objects.PanelWrapper  _createpanel(int _paneltype,String _title) throws Exception{
anywheresoftware.b4a.objects.PanelWrapper _pan = null;
com.yttrium.scrotter.main._panelinfo _pi = null;
 //BA.debugLineNum = 86;BA.debugLine="Sub CreatePanel(PanelType As Int, Title As String) As Panel";
 //BA.debugLineNum = 87;BA.debugLine="Dim pan As Panel";
_pan = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 88;BA.debugLine="Dim pi As PanelInfo";
_pi = new com.yttrium.scrotter.main._panelinfo();
 //BA.debugLineNum = 89;BA.debugLine="pi.Initialize";
_pi.Initialize();
 //BA.debugLineNum = 90;BA.debugLine="pi.LayoutLoaded = False";
_pi.LayoutLoaded = anywheresoftware.b4a.keywords.Common.False;
 //BA.debugLineNum = 91;BA.debugLine="pi.PanelType = PanelType";
_pi.PanelType = _paneltype;
 //BA.debugLineNum = 92;BA.debugLine="pan.Initialize(\"\")";
_pan.Initialize(mostCurrent.activityBA,"");
 //BA.debugLineNum = 93;BA.debugLine="pan.Tag = pi";
_pan.setTag((Object)(_pi));
 //BA.debugLineNum = 94;BA.debugLine="Return pan";
if (true) return _pan;
 //BA.debugLineNum = 95;BA.debugLine="End Sub";
return null;
}

public static void initializeProcessGlobals() {
    
    if (processGlobalsRun == false) {
	    processGlobalsRun = true;
		try {
		        main._process_globals();
		
        } catch (Exception e) {
			throw new RuntimeException(e);
		}
    }
}

public static boolean isAnyActivityVisible() {
    boolean vis = false;
vis = vis | (main.mostCurrent != null);
return vis;}
public static String  _globals() throws Exception{
 //BA.debugLineNum = 26;BA.debugLine="Sub Globals";
 //BA.debugLineNum = 29;BA.debugLine="Dim container As AHPageContainer";
mostCurrent._container = new de.amberhome.viewpager.AHPageContainer();
 //BA.debugLineNum = 30;BA.debugLine="Dim pager As AHViewPager";
mostCurrent._pager = new de.amberhome.viewpager.AHViewPager();
 //BA.debugLineNum = 31;BA.debugLine="Dim tabs As AHViewPagerTabs";
mostCurrent._tabs = new de.amberhome.viewpager.AHViewPagerTabs();
 //BA.debugLineNum = 32;BA.debugLine="Dim GlossCheckbox As CheckBox";
mostCurrent._glosscheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 33;BA.debugLine="Dim ModelBox As Spinner";
mostCurrent._modelbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 34;BA.debugLine="Dim ShadowCheckbox As CheckBox";
mostCurrent._shadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 35;BA.debugLine="Dim StretchCheckbox As CheckBox";
mostCurrent._stretchcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 36;BA.debugLine="Dim UnderShadowCheckbox As CheckBox";
mostCurrent._undershadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 37;BA.debugLine="Dim VariantBox As Spinner";
mostCurrent._variantbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 38;BA.debugLine="Dim TabSwitcher As TabHost";
mostCurrent._tabswitcher = new anywheresoftware.b4a.objects.TabHostWrapper();
 //BA.debugLineNum = 39;BA.debugLine="Dim Loadbtn As Button";
mostCurrent._loadbtn = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 40;BA.debugLine="Dim SaveBtn As Button";
mostCurrent._savebtn = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 41;BA.debugLine="Dim Preview As Panel";
mostCurrent._preview = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 42;BA.debugLine="Dim Image3 As Bitmap";
mostCurrent._image3 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 54;BA.debugLine="Dim CurrentPage As Int";
_currentpage = 0;
 //BA.debugLineNum = 56;BA.debugLine="End Sub";
return "";
}
public static String  _loadbtn_click() throws Exception{
 //BA.debugLineNum = 150;BA.debugLine="Sub Loadbtn_Click";
 //BA.debugLineNum = 152;BA.debugLine="End Sub";
return "";
}
public static String  _modelbox_itemclick(int _position,Object _value) throws Exception{
 //BA.debugLineNum = 131;BA.debugLine="Sub ModelBox_itemClick (Position As Int, Value As Object)";
 //BA.debugLineNum = 132;BA.debugLine="VariantBox.Clear";
mostCurrent._variantbox.Clear();
 //BA.debugLineNum = 133;BA.debugLine="Select Case ModelBox.SelectedItem";
switch (BA.switchObjectToInt(mostCurrent._modelbox.getSelectedItem(),"HTC One X, HTC One X+","Samsung Galaxy SIII","Motorola Xoom","Samsung Galaxy SII, Epic 4G Touch")) {
case 0:
 //BA.debugLineNum = 135;BA.debugLine="VariantBox.AddAll(Array As String(\"White\", \"Black\"))";
mostCurrent._variantbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"White","Black"}));
 break;
case 1:
 //BA.debugLineNum = 137;BA.debugLine="VariantBox.AddAll(Array As String(\"Blue\", \"White\", \"Black\", \"Red\", \"Brown\"))";
mostCurrent._variantbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"Blue","White","Black","Red","Brown"}));
 break;
case 2:
 //BA.debugLineNum = 139;BA.debugLine="VariantBox.AddAll(Array As String(\"Landscape\", \"Portrait\"))";
mostCurrent._variantbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"Landscape","Portrait"}));
 break;
case 3:
 //BA.debugLineNum = 141;BA.debugLine="VariantBox.AddAll(Array As String(\"Galaxy SII\", \"Epic 4G Touch\"))";
mostCurrent._variantbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"Galaxy SII","Epic 4G Touch"}));
 break;
}
;
 //BA.debugLineNum = 143;BA.debugLine="RefreshPreview";
_refreshpreview();
 //BA.debugLineNum = 144;BA.debugLine="End Sub";
return "";
}
public static String  _pager_pagechanged(int _position) throws Exception{
 //BA.debugLineNum = 126;BA.debugLine="Sub Pager_PageChanged (Position As Int)";
 //BA.debugLineNum = 127;BA.debugLine="CurrentPage = Position";
_currentpage = _position;
 //BA.debugLineNum = 129;BA.debugLine="End Sub";
return "";
}
public static String  _pager_pagecreated(int _position,Object _page) throws Exception{
anywheresoftware.b4a.objects.PanelWrapper _pan = null;
com.yttrium.scrotter.main._panelinfo _pi = null;
anywheresoftware.b4a.objects.ConcreteViewWrapper _tv = null;
 //BA.debugLineNum = 97;BA.debugLine="Sub Pager_PageCreated (Position As Int, Page As Object)";
 //BA.debugLineNum = 98;BA.debugLine="Log (\"Page created \" & Position)";
anywheresoftware.b4a.keywords.Common.Log("Page created "+BA.NumberToString(_position));
 //BA.debugLineNum = 99;BA.debugLine="Dim pan As Panel";
_pan = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 100;BA.debugLine="Dim pi As PanelInfo";
_pi = new com.yttrium.scrotter.main._panelinfo();
 //BA.debugLineNum = 101;BA.debugLine="pan = Page";
_pan.setObject((android.view.ViewGroup)(_page));
 //BA.debugLineNum = 102;BA.debugLine="pi = pan.Tag";
_pi = (com.yttrium.scrotter.main._panelinfo)(_pan.getTag());
 //BA.debugLineNum = 103;BA.debugLine="Select pi.PanelType";
switch (BA.switchObjectToInt(_pi.PanelType,_type_settings,_type_preview,_type_options)) {
case 0:
 //BA.debugLineNum = 105;BA.debugLine="If Not(pi.LayoutLoaded) Then";
if (anywheresoftware.b4a.keywords.Common.Not(_pi.LayoutLoaded)) { 
 //BA.debugLineNum = 106;BA.debugLine="pan.LoadLayout(\"Settings\")";
_pan.LoadLayout("Settings",mostCurrent.activityBA);
 //BA.debugLineNum = 107;BA.debugLine="pi.LayoutLoaded = True";
_pi.LayoutLoaded = anywheresoftware.b4a.keywords.Common.True;
 };
 break;
case 1:
 //BA.debugLineNum = 110;BA.debugLine="If Not(pi.LayoutLoaded) Then";
if (anywheresoftware.b4a.keywords.Common.Not(_pi.LayoutLoaded)) { 
 //BA.debugLineNum = 111;BA.debugLine="pan.LoadLayout(\"Preview\")";
_pan.LoadLayout("Preview",mostCurrent.activityBA);
 //BA.debugLineNum = 112;BA.debugLine="pi.LayoutLoaded = True";
_pi.LayoutLoaded = anywheresoftware.b4a.keywords.Common.True;
 };
 break;
case 2:
 //BA.debugLineNum = 115;BA.debugLine="If Not(pi.LayoutLoaded) Then";
if (anywheresoftware.b4a.keywords.Common.Not(_pi.LayoutLoaded)) { 
 //BA.debugLineNum = 116;BA.debugLine="pan.LoadLayout(\"Options\")";
_pan.LoadLayout("Options",mostCurrent.activityBA);
 //BA.debugLineNum = 117;BA.debugLine="pi.LayoutLoaded = True";
_pi.LayoutLoaded = anywheresoftware.b4a.keywords.Common.True;
 //BA.debugLineNum = 118;BA.debugLine="ModelBox.TextColor = Colors.DarkGray";
mostCurrent._modelbox.setTextColor(anywheresoftware.b4a.keywords.Common.Colors.DarkGray);
 //BA.debugLineNum = 119;BA.debugLine="ModelBox.AddAll(Array As String(\"ASUS Eee Pad Transformer\", \"Google Nexus 4\", \"Google Nexus 7\", \"Google Nexus S\", \"HTC Amaze 4G, Ruby\", \"HTC Desire\", \"HTC Desire C\", \"HTC Desire HD, HTC Inspire 4G\", \"HTC Desire Z, T-Mobile G2\", \"HTC Droid DNA\", \"HTC Evo 3D\", \"HTC Evo 4G LTE\", \"HTC Google Nexus One\", \"HTC Hero\", \"HTC Legend\", \"HTC One S\", \"HTC One V\", \"HTC One X, HTC One X+\", \"HTC Sensation\", \"HTC Titan\", \"HTC Vivid\", \"HTC Wildfire\", \"HTC Wildfire S\", \"LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II\", \"LG Optimus 2X\", \"Motorola Droid 2, Milestone 2\", \"Motorola Droid RAZR\", \"Motorola Droid RAZR M\", \"Motorola Xoom\", \"Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G\", \"Samsung Galaxy Ace, Galaxy Cooper\", \"Samsung Galaxy Note II\", \"Samsung Galaxy SII, Epic 4G Touch\", \"Samsung Galaxy SII Skyrocket\", \"Samsung Galaxy SIII\", \"Samsung Galaxy SIII Mini\", \"Samsung Galaxy TAB 10.1\", \"Samsung Google Galaxy Nexus\", \"Sony Ericsson Xperia J\", \"Sony Ericsson Xperia X10\"))";
mostCurrent._modelbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"ASUS Eee Pad Transformer","Google Nexus 4","Google Nexus 7","Google Nexus S","HTC Amaze 4G, Ruby","HTC Desire","HTC Desire C","HTC Desire HD, HTC Inspire 4G","HTC Desire Z, T-Mobile G2","HTC Droid DNA","HTC Evo 3D","HTC Evo 4G LTE","HTC Google Nexus One","HTC Hero","HTC Legend","HTC One S","HTC One V","HTC One X, HTC One X+","HTC Sensation","HTC Titan","HTC Vivid","HTC Wildfire","HTC Wildfire S","LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II","LG Optimus 2X","Motorola Droid 2, Milestone 2","Motorola Droid RAZR","Motorola Droid RAZR M","Motorola Xoom","Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G","Samsung Galaxy Ace, Galaxy Cooper","Samsung Galaxy Note II","Samsung Galaxy SII, Epic 4G Touch","Samsung Galaxy SII Skyrocket","Samsung Galaxy SIII","Samsung Galaxy SIII Mini","Samsung Galaxy TAB 10.1","Samsung Google Galaxy Nexus","Sony Ericsson Xperia J","Sony Ericsson Xperia X10"}));
 //BA.debugLineNum = 120;BA.debugLine="ModelBox.SelectedIndex = 1";
mostCurrent._modelbox.setSelectedIndex((int)(1));
 //BA.debugLineNum = 121;BA.debugLine="Dim tv As View";
_tv = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 };
 break;
}
;
 //BA.debugLineNum = 124;BA.debugLine="End Sub";
return "";
}
public static String  _process_globals() throws Exception{
 //BA.debugLineNum = 14;BA.debugLine="Sub Process_Globals";
 //BA.debugLineNum = 17;BA.debugLine="Dim TYPE_SETTINGS As Int : TYPE_SETTINGS = 1";
_type_settings = 0;
 //BA.debugLineNum = 17;BA.debugLine="Dim TYPE_SETTINGS As Int : TYPE_SETTINGS = 1";
_type_settings = (int)(1);
 //BA.debugLineNum = 18;BA.debugLine="Dim TYPE_PREVIEW As Int : TYPE_PREVIEW = 2";
_type_preview = 0;
 //BA.debugLineNum = 18;BA.debugLine="Dim TYPE_PREVIEW As Int : TYPE_PREVIEW = 2";
_type_preview = (int)(2);
 //BA.debugLineNum = 19;BA.debugLine="Dim TYPE_OPTIONS As Int : TYPE_OPTIONS = 3";
_type_options = 0;
 //BA.debugLineNum = 19;BA.debugLine="Dim TYPE_OPTIONS As Int : TYPE_OPTIONS = 3";
_type_options = (int)(3);
 //BA.debugLineNum = 20;BA.debugLine="Dim FILL_PARENT As Int : FILL_PARENT = -1";
_fill_parent = 0;
 //BA.debugLineNum = 20;BA.debugLine="Dim FILL_PARENT As Int : FILL_PARENT = -1";
_fill_parent = (int)(-1);
 //BA.debugLineNum = 21;BA.debugLine="Dim WRAP_CONTENT As Int : WRAP_CONTENT = -2";
_wrap_content = 0;
 //BA.debugLineNum = 21;BA.debugLine="Dim WRAP_CONTENT As Int : WRAP_CONTENT = -2";
_wrap_content = (int)(-2);
 //BA.debugLineNum = 22;BA.debugLine="Type PanelInfo (PanelType As Int, LayoutLoaded As Boolean)";
;
 //BA.debugLineNum = 23;BA.debugLine="Dim CurrentPage As Int : CurrentPage = 0";
_currentpage = 0;
 //BA.debugLineNum = 23;BA.debugLine="Dim CurrentPage As Int : CurrentPage = 0";
_currentpage = (int)(0);
 //BA.debugLineNum = 24;BA.debugLine="End Sub";
return "";
}
public static String  _refreshpreview() throws Exception{
anywheresoftware.b4a.objects.drawable.CanvasWrapper _mycanvas = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _image1 = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _gloss = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _shadow = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _undershadow = null;
int _indexh = 0;
int _indexw = 0;
String _r240320 = "";
String _r320480 = "";
String _r480800 = "";
String _r480854 = "";
String _r540960 = "";
String _r7201280 = "";
String _r7681280 = "";
String _r800480 = "";
String _r8001280 = "";
String _r854480 = "";
String _r10801920 = "";
String _r1280800 = "";
 //BA.debugLineNum = 154;BA.debugLine="Sub RefreshPreview";
 //BA.debugLineNum = 155;BA.debugLine="Dim MyCanvas As Canvas";
_mycanvas = new anywheresoftware.b4a.objects.drawable.CanvasWrapper();
 //BA.debugLineNum = 156;BA.debugLine="Dim Image1 As Bitmap";
_image1 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 157;BA.debugLine="Dim Gloss As Bitmap";
_gloss = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 158;BA.debugLine="Dim Shadow As Bitmap";
_shadow = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 159;BA.debugLine="Dim Undershadow As Bitmap";
_undershadow = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 160;BA.debugLine="Dim IndexH As Int";
_indexh = 0;
 //BA.debugLineNum = 161;BA.debugLine="Dim IndexW As Int";
_indexw = 0;
 //BA.debugLineNum = 162;BA.debugLine="Dim r240320 As String = \"240x320.png\"";
_r240320 = "240x320.png";
 //BA.debugLineNum = 163;BA.debugLine="Dim r320480 As String = \"320x480.png\"";
_r320480 = "320x480.png";
 //BA.debugLineNum = 164;BA.debugLine="Dim r480800 As String = \"480x800.png\"";
_r480800 = "480x800.png";
 //BA.debugLineNum = 165;BA.debugLine="Dim r480854 As String = \"480x854.png\"";
_r480854 = "480x854.png";
 //BA.debugLineNum = 166;BA.debugLine="Dim r540960 As String = \"540x960.png\"";
_r540960 = "540x960.png";
 //BA.debugLineNum = 167;BA.debugLine="Dim r7201280 As String = \"720x1280.png\"";
_r7201280 = "720x1280.png";
 //BA.debugLineNum = 168;BA.debugLine="Dim r7681280 As String = \"768x1280.png\"";
_r7681280 = "768x1280.png";
 //BA.debugLineNum = 169;BA.debugLine="Dim r800480 As String = \"800x480.png\"";
_r800480 = "800x480.png";
 //BA.debugLineNum = 170;BA.debugLine="Dim r8001280 As String = \"800x1280.png\"";
_r8001280 = "800x1280.png";
 //BA.debugLineNum = 171;BA.debugLine="Dim r854480 As String = \"854x480.png\"";
_r854480 = "854x480.png";
 //BA.debugLineNum = 172;BA.debugLine="Dim r10801920 As String = \"1080x1920.png\"";
_r10801920 = "1080x1920.png";
 //BA.debugLineNum = 173;BA.debugLine="Dim r1280800 As String = \"1280x800.png\"";
_r1280800 = "1280x800.png";
 //BA.debugLineNum = 175;BA.debugLine="Select Case ModelBox.SelectedItem";
switch (BA.switchObjectToInt(mostCurrent._modelbox.getSelectedItem(),"Samsung Galaxy SIII Mini","HTC Desire HD, HTC Inspire 4G","HTC One X, HTC One X+","Samsung Galaxy SIII","Motorola Xoom","Samsung Galaxy SII, Epic 4G Touch","Samsung Google Galaxy Nexus","Samsung Galaxy Note II","Motorola Droid RAZR","Google Nexus 7","HTC One S","HTC One V","Google Nexus S","Google Nexus 4","Motorola Droid RAZR M","Sony Ericsson Xperia X10","HTC Google Nexus One","HTC Hero","HTC Legend","HTC Droid DNA","HTC Vivid","HTC Evo 3D","HTC Desire Z, T-Mobile G2","HTC Desire","Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G","Samsung Galaxy Ace, Galaxy Cooper","Sony Ericsson Xperia J","LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II","Samsung Galaxy Tab 10.1","Samsung Galaxy SII Skyrocket","HTC Evo 4G LTE","ASUS Eee Pad Transformer","HTC Desire C","HTC Desire C","Motorola Droid 2, Milestone 2","LG Optimus 2X","HTC Titan","HTC Wildfire","HTC Wildfire S","HTC Sensation","HTC Amaze 4G, Ruby")) {
case 0:
 //BA.debugLineNum = 177;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"samsunggsiiimini.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"samsunggsiiimini.png");
 //BA.debugLineNum = 178;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 179;BA.debugLine="IndexW = 78";
_indexw = (int)(78);
 //BA.debugLineNum = 180;BA.debugLine="IndexH = 182";
_indexh = (int)(182);
 break;
case 1:
 //BA.debugLineNum = 182;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"desirehd.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"desirehd.png");
 //BA.debugLineNum = 183;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 184;BA.debugLine="IndexW = 104";
_indexw = (int)(104);
 //BA.debugLineNum = 185;BA.debugLine="IndexH = 169";
_indexh = (int)(169);
 break;
case 2:
 //BA.debugLineNum = 187;BA.debugLine="If VariantBox.SelectedItem = \"Black\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Black")) { 
 //BA.debugLineNum = 188;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"onexblack.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"onexblack.png");
 //BA.debugLineNum = 189;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"onexblack.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"onexblack.png");
 //BA.debugLineNum = 190;BA.debugLine="IndexW = 113";
_indexw = (int)(113);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("White")) { 
 //BA.debugLineNum = 192;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"onexwhite.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"onexwhite.png");
 //BA.debugLineNum = 193;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"onexwhite.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"onexwhite.png");
 //BA.debugLineNum = 194;BA.debugLine="IndexW = 115";
_indexw = (int)(115);
 };
 //BA.debugLineNum = 196;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 197;BA.debugLine="IndexH = 213";
_indexh = (int)(213);
 break;
case 3:
 //BA.debugLineNum = 199;BA.debugLine="IndexW = 88";
_indexw = (int)(88);
 //BA.debugLineNum = 200;BA.debugLine="If VariantBox.SelectedItem = \"Blue\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Blue")) { 
 //BA.debugLineNum = 201;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsiiiblue.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsiiiblue.png");
 //BA.debugLineNum = 202;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"gsiiiblue.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"gsiiiblue.png");
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("White")) { 
 //BA.debugLineNum = 204;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsiiiwhite.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsiiiwhite.png");
 //BA.debugLineNum = 205;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"gsiiiwhite.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"gsiiiwhite.png");
 //BA.debugLineNum = 206;BA.debugLine="IndexW = 84";
_indexw = (int)(84);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Black")) { 
 //BA.debugLineNum = 208;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsiiiblack.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsiiiblack.png");
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Red")) { 
 //BA.debugLineNum = 210;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsiiired.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsiiired.png");
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Brown")) { 
 //BA.debugLineNum = 212;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsiiibrown.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsiiibrown.png");
 };
 //BA.debugLineNum = 214;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"gsiii.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"gsiii.png");
 //BA.debugLineNum = 215;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 216;BA.debugLine="IndexH = 184";
_indexh = (int)(184);
 break;
case 4:
 //BA.debugLineNum = 246;BA.debugLine="If VariantBox.SelectedItem = \"Portrait\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Portrait")) { 
 //BA.debugLineNum = 247;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"xoomport.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"xoomport.png");
 //BA.debugLineNum = 248;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r8001280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r8001280);
 //BA.debugLineNum = 249;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"xoomport.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"xoomport.png");
 //BA.debugLineNum = 250;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"xoomport.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"xoomport.png");
 //BA.debugLineNum = 251;BA.debugLine="IndexW = 199";
_indexw = (int)(199);
 //BA.debugLineNum = 252;BA.debugLine="IndexH = 200";
_indexh = (int)(200);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Landscape")) { 
 //BA.debugLineNum = 254;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"xoomland.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"xoomland.png");
 //BA.debugLineNum = 255;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r1280800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r1280800);
 //BA.debugLineNum = 256;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"xoomland.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"xoomland.png");
 //BA.debugLineNum = 257;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"xoomland.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"xoomland.png");
 //BA.debugLineNum = 258;BA.debugLine="IndexW = 218";
_indexw = (int)(218);
 //BA.debugLineNum = 259;BA.debugLine="IndexH = 191";
_indexh = (int)(191);
 };
 break;
case 5:
 //BA.debugLineNum = 262;BA.debugLine="If VariantBox.SelectedItem = \"Galaxy SII\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Galaxy SII")) { 
 //BA.debugLineNum = 263;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"gsii.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"gsii.png");
 //BA.debugLineNum = 264;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"gsii.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"gsii.png");
 //BA.debugLineNum = 265;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"gsii.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"gsii.png");
 //BA.debugLineNum = 266;BA.debugLine="IndexH = 191";
_indexh = (int)(191);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Epic 4G Touch")) { 
 //BA.debugLineNum = 268;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"epic4gtouch.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"epic4gtouch.png");
 //BA.debugLineNum = 269;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"epic4gtouch.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"epic4gtouch.png");
 //BA.debugLineNum = 270;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"epic4gtouch\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"epic4gtouch");
 };
 //BA.debugLineNum = 272;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 273;BA.debugLine="IndexW = 132";
_indexw = (int)(132);
 break;
case 6:
 //BA.debugLineNum = 275;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"galaxynexus.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"galaxynexus.png");
 //BA.debugLineNum = 276;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 277;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"galaxynexus.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"galaxynexus.png");
 //BA.debugLineNum = 278;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"galaxynexus.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"galaxynexus.png");
 //BA.debugLineNum = 279;BA.debugLine="IndexW = 155";
_indexw = (int)(155);
 //BA.debugLineNum = 280;BA.debugLine="IndexH = 263";
_indexh = (int)(263);
 break;
case 7:
 //BA.debugLineNum = 282;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"GalaxyNoteII.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"GalaxyNoteII.png");
 //BA.debugLineNum = 283;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 284;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"GalaxyNoteII.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"GalaxyNoteII.png");
 //BA.debugLineNum = 285;BA.debugLine="IndexW = 49";
_indexw = (int)(49);
 //BA.debugLineNum = 286;BA.debugLine="IndexH = 140";
_indexh = (int)(140);
 break;
case 8:
 //BA.debugLineNum = 288;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"DroidRAZR.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"DroidRAZR.png");
 //BA.debugLineNum = 289;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 290;BA.debugLine="IndexW = 150";
_indexw = (int)(150);
 //BA.debugLineNum = 291;BA.debugLine="IndexH = 206";
_indexh = (int)(206);
 break;
case 9:
 //BA.debugLineNum = 293;BA.debugLine="If VariantBox.SelectedItem = \"Portrait\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Portrait")) { 
 //BA.debugLineNum = 294;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"Nexus7Port.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"Nexus7Port.png");
 //BA.debugLineNum = 295;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r8001280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r8001280);
 //BA.debugLineNum = 296;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"Nexus7Port.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"Nexus7Port.png");
 //BA.debugLineNum = 297;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"Nexus7Port.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"Nexus7Port.png");
 //BA.debugLineNum = 298;BA.debugLine="IndexW = 264";
_indexw = (int)(264);
 //BA.debugLineNum = 299;BA.debugLine="IndexH = 311";
_indexh = (int)(311);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Landscape")) { 
 //BA.debugLineNum = 301;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"Nexus7Land.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"Nexus7Land.png");
 //BA.debugLineNum = 302;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r1280800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r1280800);
 //BA.debugLineNum = 303;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"Nexus7Land.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"Nexus7Land.png");
 //BA.debugLineNum = 304;BA.debugLine="IndexW = 315";
_indexw = (int)(315);
 //BA.debugLineNum = 305;BA.debugLine="IndexH = 270";
_indexh = (int)(270);
 };
 break;
case 10:
 //BA.debugLineNum = 308;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://103.imagebam.com/download/pES86Mk-oX3FwKg72ullsg/23245/232444328/OneS.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://103.imagebam.com/download/pES86Mk-oX3FwKg72ullsg/23245/232444328/OneS.png");
 //BA.debugLineNum = 309;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 310;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://102.imagebam.com/download/2YpfhldGjShokr_7vTVvrA/23245/232446240/OneS.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://102.imagebam.com/download/2YpfhldGjShokr_7vTVvrA/23245/232446240/OneS.png");
 //BA.debugLineNum = 311;BA.debugLine="IndexW = 106";
_indexw = (int)(106);
 //BA.debugLineNum = 312;BA.debugLine="IndexH = 228";
_indexh = (int)(228);
 break;
case 11:
 //BA.debugLineNum = 314;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://103.imagebam.com/download/d78I9T94gLuErZL59eWi6Q/23245/232444333/OneV.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://103.imagebam.com/download/d78I9T94gLuErZL59eWi6Q/23245/232444333/OneV.png");
 //BA.debugLineNum = 315;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 316;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://101.imagebam.com/download/XztYn-E4j2XfLl8co66zCQ/23245/232446244/OneV.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://101.imagebam.com/download/XztYn-E4j2XfLl8co66zCQ/23245/232446244/OneV.png");
 //BA.debugLineNum = 317;BA.debugLine="IndexW = 85";
_indexw = (int)(85);
 //BA.debugLineNum = 318;BA.debugLine="IndexH = 165";
_indexh = (int)(165);
 break;
case 12:
 //BA.debugLineNum = 320;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://106.imagebam.com/download/qnwpbb1HFBzATLlQr7yD7g/23245/232444325/NexusS.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://106.imagebam.com/download/qnwpbb1HFBzATLlQr7yD7g/23245/232444325/NexusS.png");
 //BA.debugLineNum = 321;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 322;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://108.imagebam.com/download/tu5BzK46n3ka_WydBl0pPQ/23245/232446237/NexusS.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://108.imagebam.com/download/tu5BzK46n3ka_WydBl0pPQ/23245/232446237/NexusS.png");
 //BA.debugLineNum = 323;BA.debugLine="IndexW = 45";
_indexw = (int)(45);
 //BA.debugLineNum = 324;BA.debugLine="IndexH = 165";
_indexh = (int)(165);
 break;
case 13:
 //BA.debugLineNum = 326;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://101.imagebam.com/download/fiW5-5yoR6LRtY20rwQmnw/23245/232444302/Nexus4.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://101.imagebam.com/download/fiW5-5yoR6LRtY20rwQmnw/23245/232444302/Nexus4.png");
 //BA.debugLineNum = 327;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7681280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7681280);
 //BA.debugLineNum = 328;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://104.imagebam.com/download/M_vkC9maazTeEad9DTvD9g/23245/232446224/Nexus4-G.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://104.imagebam.com/download/M_vkC9maazTeEad9DTvD9g/23245/232446224/Nexus4-G.png");
 //BA.debugLineNum = 329;BA.debugLine="IndexW = 45";
_indexw = (int)(45);
 //BA.debugLineNum = 330;BA.debugLine="IndexH = 193";
_indexh = (int)(193);
 break;
case 14:
 //BA.debugLineNum = 332;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://106.imagebam.com/download/E58kNQKNie0lfbXBr8mM-A/23255/232546227/DroidRazrM.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://106.imagebam.com/download/E58kNQKNie0lfbXBr8mM-A/23255/232546227/DroidRazrM.png");
 //BA.debugLineNum = 333;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 334;BA.debugLine="IndexW = 49";
_indexw = (int)(49);
 //BA.debugLineNum = 335;BA.debugLine="IndexH = 129";
_indexh = (int)(129);
 break;
case 15:
 //BA.debugLineNum = 337;BA.debugLine="If VariantBox.SelectedItem = \"Black\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Black")) { 
 //BA.debugLineNum = 338;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDQzaA/SonyEricssonXperia10Black.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDQzaA/SonyEricssonXperia10Black.png");
 //BA.debugLineNum = 339;BA.debugLine="IndexW = 235";
_indexw = (int)(235);
 //BA.debugLineNum = 340;BA.debugLine="IndexH = 191";
_indexh = (int)(191);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("White")) { 
 //BA.debugLineNum = 342;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDQzaQ/SonyEricssonXperia10White.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDQzaQ/SonyEricssonXperia10White.png");
 //BA.debugLineNum = 343;BA.debugLine="IndexW = 255";
_indexw = (int)(255);
 //BA.debugLineNum = 344;BA.debugLine="IndexH = 205";
_indexh = (int)(205);
 };
 //BA.debugLineNum = 346;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480854)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480854);
 break;
case 16:
 //BA.debugLineNum = 348;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDQzZQ/HTCGoogleNexusOne.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDQzZQ/HTCGoogleNexusOne.png");
 //BA.debugLineNum = 349;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 350;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaDQzOQ/HTCGoogleNexusOne.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaDQzOQ/HTCGoogleNexusOne.png");
 //BA.debugLineNum = 351;BA.debugLine="IndexW = 165";
_indexw = (int)(165);
 //BA.debugLineNum = 352;BA.debugLine="IndexH = 168";
_indexh = (int)(168);
 break;
case 17:
 //BA.debugLineNum = 354;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"HTCHero.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"HTCHero.png");
 //BA.debugLineNum = 355;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r320480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r320480);
 //BA.debugLineNum = 356;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaDQzYQ/HTCHero.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaDQzYQ/HTCHero.png");
 //BA.debugLineNum = 357;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"http://ompldr.org/vaDQzYw/HTCHero.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"http://ompldr.org/vaDQzYw/HTCHero.png");
 //BA.debugLineNum = 358;BA.debugLine="IndexW = 67";
_indexw = (int)(67);
 //BA.debugLineNum = 359;BA.debugLine="IndexH = 131";
_indexh = (int)(131);
 break;
case 18:
 //BA.debugLineNum = 361;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDQzZw/HTCLegend.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDQzZw/HTCLegend.png");
 //BA.debugLineNum = 362;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r320480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r320480);
 //BA.debugLineNum = 363;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaDQzYg/HTCLegend.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaDQzYg/HTCLegend.png");
 //BA.debugLineNum = 364;BA.debugLine="IndexW = 67";
_indexw = (int)(67);
 //BA.debugLineNum = 365;BA.debugLine="IndexH = 131";
_indexh = (int)(131);
 break;
case 19:
 //BA.debugLineNum = 391;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDVxcQ/DroidDNA.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDVxcQ/DroidDNA.png");
 //BA.debugLineNum = 392;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r10801920)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r10801920);
 //BA.debugLineNum = 393;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaDY3cw/DroidDNA.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaDY3cw/DroidDNA.png");
 //BA.debugLineNum = 394;BA.debugLine="IndexW = 106";
_indexw = (int)(106);
 //BA.debugLineNum = 395;BA.debugLine="IndexH = 300";
_indexh = (int)(300);
 break;
case 20:
 //BA.debugLineNum = 397;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDVxcA/Vivid.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDVxcA/Vivid.png");
 //BA.debugLineNum = 398;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 399;BA.debugLine="IndexW = 66";
_indexw = (int)(66);
 //BA.debugLineNum = 400;BA.debugLine="IndexH = 125";
_indexh = (int)(125);
 break;
case 21:
 //BA.debugLineNum = 402;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY3dA/Evo3D.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY3dA/Evo3D.png");
 //BA.debugLineNum = 403;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 404;BA.debugLine="IndexW = 78";
_indexw = (int)(78);
 //BA.debugLineNum = 405;BA.debugLine="IndexH = 153";
_indexh = (int)(153);
 break;
case 22:
 //BA.debugLineNum = 407;BA.debugLine="If VariantBox.SelectedItem = \"Portrait\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Portrait")) { 
 //BA.debugLineNum = 408;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4MQ/DesireZPort.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4MQ/DesireZPort.png");
 //BA.debugLineNum = 409;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 410;BA.debugLine="IndexW = 94";
_indexw = (int)(94);
 //BA.debugLineNum = 411;BA.debugLine="IndexH = 162";
_indexh = (int)(162);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Landscape")) { 
 //BA.debugLineNum = 413;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4MA/DesireZLand.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4MA/DesireZLand.png");
 //BA.debugLineNum = 414;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r800480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r800480);
 //BA.debugLineNum = 415;BA.debugLine="IndexW = 189";
_indexw = (int)(189);
 //BA.debugLineNum = 416;BA.debugLine="IndexH = 79";
_indexh = (int)(79);
 };
 break;
case 23:
 //BA.debugLineNum = 419;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4Yw/Desire.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4Yw/Desire.png");
 //BA.debugLineNum = 420;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 421;BA.debugLine="IndexW = 136";
_indexw = (int)(136);
 //BA.debugLineNum = 422;BA.debugLine="IndexH = 180";
_indexh = (int)(180);
 break;
case 24:
 //BA.debugLineNum = 424;BA.debugLine="If VariantBox.SelectedItem = \"Model 1\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Model 1")) { 
 //BA.debugLineNum = 425;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4ZQ/DroidCharge.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4ZQ/DroidCharge.png");
 //BA.debugLineNum = 426;BA.debugLine="IndexH = 191";
_indexh = (int)(191);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Model 2")) { 
 //BA.debugLineNum = 428;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4bA/GalaxySAviator.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4bA/GalaxySAviator.png");
 //BA.debugLineNum = 429;BA.debugLine="IndexH = 175";
_indexh = (int)(175);
 };
 //BA.debugLineNum = 431;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 432;BA.debugLine="IndexW = 60";
_indexw = (int)(60);
 break;
case 25:
 //BA.debugLineNum = 434;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY4cA/GalaxyAce.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY4cA/GalaxyAce.png");
 //BA.debugLineNum = 435;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r320480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r320480);
 //BA.debugLineNum = 436;BA.debugLine="IndexW = 87";
_indexw = (int)(87);
 //BA.debugLineNum = 437;BA.debugLine="IndexH = 179";
_indexh = (int)(179);
 break;
case 26:
 //BA.debugLineNum = 439;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY5aQ/XperiaJ.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY5aQ/XperiaJ.png");
 //BA.debugLineNum = 440;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480854)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480854);
 //BA.debugLineNum = 441;BA.debugLine="IndexW = 75";
_indexw = (int)(75);
 //BA.debugLineNum = 442;BA.debugLine="IndexH = 172";
_indexh = (int)(172);
 break;
case 27:
 //BA.debugLineNum = 444;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDY5eA/Nitro.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDY5eA/Nitro.png");
 //BA.debugLineNum = 445;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 446;BA.debugLine="IndexW = 113";
_indexw = (int)(113);
 //BA.debugLineNum = 447;BA.debugLine="IndexH = 191";
_indexh = (int)(191);
 break;
case 28:
 //BA.debugLineNum = 449;BA.debugLine="If VariantBox.SelectedItem = \"Portrait\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Portrait")) { 
 //BA.debugLineNum = 450;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDZhMw/GalaxyTab10.1Port.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDZhMw/GalaxyTab10.1Port.png");
 //BA.debugLineNum = 451;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r8001280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r8001280);
 //BA.debugLineNum = 452;BA.debugLine="IndexW = 129";
_indexw = (int)(129);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Landscape")) { 
 //BA.debugLineNum = 454;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDZhMg/GalaxyTab10.1Land.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDZhMg/GalaxyTab10.1Land.png");
 //BA.debugLineNum = 455;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r1280800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r1280800);
 //BA.debugLineNum = 456;BA.debugLine="IndexW = 135";
_indexw = (int)(135);
 };
 //BA.debugLineNum = 458;BA.debugLine="IndexH = 135";
_indexh = (int)(135);
 break;
case 29:
 //BA.debugLineNum = 460;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDZhYw/GSII%20Skyrocket.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDZhYw/GSII%20Skyrocket.png");
 //BA.debugLineNum = 461;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 462;BA.debugLine="IndexW = 86";
_indexw = (int)(86);
 //BA.debugLineNum = 463;BA.debugLine="IndexH = 148";
_indexh = (int)(148);
 break;
case 30:
 //BA.debugLineNum = 465;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDZoYw/EVO4GLTE.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDZoYw/EVO4GLTE.png");
 //BA.debugLineNum = 466;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r7201280)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r7201280);
 //BA.debugLineNum = 467;BA.debugLine="IndexW = 88";
_indexw = (int)(88);
 //BA.debugLineNum = 468;BA.debugLine="IndexH = 199";
_indexh = (int)(199);
 break;
case 31:
 //BA.debugLineNum = 470;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDZrdw/EeePadTransformer.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDZrdw/EeePadTransformer.png");
 //BA.debugLineNum = 471;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r1280800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r1280800);
 //BA.debugLineNum = 472;BA.debugLine="IndexW = 165";
_indexw = (int)(165);
 //BA.debugLineNum = 473;BA.debugLine="IndexH = 157";
_indexh = (int)(157);
 break;
case 32:
 //BA.debugLineNum = 475;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDc2NQ/DesireC.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDc2NQ/DesireC.png");
 //BA.debugLineNum = 476;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r320480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r320480);
 //BA.debugLineNum = 477;BA.debugLine="IndexW = 52";
_indexw = (int)(52);
 //BA.debugLineNum = 478;BA.debugLine="IndexH = 101";
_indexh = (int)(101);
 break;
case 33:
 //BA.debugLineNum = 480;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDc2Zw/Wildfire.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDc2Zw/Wildfire.png");
 //BA.debugLineNum = 481;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r240320)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r240320);
 //BA.debugLineNum = 482;BA.debugLine="IndexW = 43";
_indexw = (int)(43);
 //BA.debugLineNum = 483;BA.debugLine="IndexH = 76";
_indexh = (int)(76);
 break;
case 34:
 //BA.debugLineNum = 485;BA.debugLine="If VariantBox.SelectedItem = \"Portrait\" Then";
if ((mostCurrent._variantbox.getSelectedItem()).equals("Portrait")) { 
 //BA.debugLineNum = 486;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDhxYg/Droid2.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDhxYg/Droid2.png");
 //BA.debugLineNum = 487;BA.debugLine="IndexW = 110";
_indexw = (int)(110);
 //BA.debugLineNum = 488;BA.debugLine="IndexH = 193";
_indexh = (int)(193);
 //BA.debugLineNum = 489;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480854)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480854);
 }else if((mostCurrent._variantbox.getSelectedItem()).equals("Landscape")) { 
 //BA.debugLineNum = 491;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDhxYw/Droid2Horizontal.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDhxYw/Droid2Horizontal.png");
 //BA.debugLineNum = 492;BA.debugLine="IndexW = 198";
_indexw = (int)(198);
 //BA.debugLineNum = 493;BA.debugLine="IndexH = 95";
_indexh = (int)(95);
 //BA.debugLineNum = 494;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r854480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r854480);
 };
 break;
case 35:
 //BA.debugLineNum = 497;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDhxZA/Optimus2x.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDhxZA/Optimus2x.png");
 //BA.debugLineNum = 498;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 499;BA.debugLine="IndexW = 93";
_indexw = (int)(93);
 //BA.debugLineNum = 500;BA.debugLine="IndexH = 175";
_indexh = (int)(175);
 break;
case 36:
 //BA.debugLineNum = 502;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaGIycg/Titan.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaGIycg/Titan.png");
 //BA.debugLineNum = 503;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r480800)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r480800);
 //BA.debugLineNum = 504;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaGIydA/Titan.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaGIydA/Titan.png");
 //BA.debugLineNum = 505;BA.debugLine="IndexW = 60";
_indexw = (int)(60);
 //BA.debugLineNum = 506;BA.debugLine="IndexH = 138";
_indexh = (int)(138);
 break;
case 37:
 //BA.debugLineNum = 508;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaDc2Zw/Wildfire.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaDc2Zw/Wildfire.png");
 //BA.debugLineNum = 509;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r240320)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r240320);
 //BA.debugLineNum = 510;BA.debugLine="IndexW = 43";
_indexw = (int)(43);
 //BA.debugLineNum = 511;BA.debugLine="IndexH = 76";
_indexh = (int)(76);
 break;
case 38:
 //BA.debugLineNum = 513;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaGIzNg/WildfireS.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaGIzNg/WildfireS.png");
 //BA.debugLineNum = 514;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r320480)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r320480);
 //BA.debugLineNum = 515;BA.debugLine="IndexW = 72";
_indexw = (int)(72);
 //BA.debugLineNum = 516;BA.debugLine="IndexH = 123";
_indexh = (int)(123);
 break;
case 39:
 //BA.debugLineNum = 518;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaGJxcg/Sensation.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaGJxcg/Sensation.png");
 //BA.debugLineNum = 519;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 520;BA.debugLine="Gloss.Initialize(File.DirAssets, \"gloss/\" & \"http://ompldr.org/vaGJxcw/Sensation.png\")";
_gloss.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"gloss/"+"http://ompldr.org/vaGJxcw/Sensation.png");
 //BA.debugLineNum = 521;BA.debugLine="Undershadow.Initialize(File.DirAssets, \"undershadow/\" & \"http://ompldr.org/vaGJxdA/Sensation.png\")";
_undershadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"undershadow/"+"http://ompldr.org/vaGJxdA/Sensation.png");
 //BA.debugLineNum = 522;BA.debugLine="IndexW = 80";
_indexw = (int)(80);
 //BA.debugLineNum = 523;BA.debugLine="IndexH = 148";
_indexh = (int)(148);
 break;
case 40:
 //BA.debugLineNum = 525;BA.debugLine="Image1.Initialize(File.DirAssets, \"device/\" & \"http://ompldr.org/vaGNiaw/Ruby.png\")";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"device/"+"http://ompldr.org/vaGNiaw/Ruby.png");
 //BA.debugLineNum = 526;BA.debugLine="Shadow.Initialize(File.DirAssets, \"shadow/\" & r540960)";
_shadow.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"shadow/"+_r540960);
 //BA.debugLineNum = 527;BA.debugLine="IndexW = 84";
_indexw = (int)(84);
 //BA.debugLineNum = 528;BA.debugLine="IndexH = 157";
_indexh = (int)(157);
 break;
}
;
 //BA.debugLineNum = 543;BA.debugLine="Preview.SetBackgroundImage(ResizeImage(Image1, Preview.Width, Preview.Height))";
mostCurrent._preview.SetBackgroundImage((android.graphics.Bitmap)(_resizeimage(_image1,mostCurrent._preview.getWidth(),mostCurrent._preview.getHeight()).getObject()));
 //BA.debugLineNum = 544;BA.debugLine="End Sub";
return "";
}
public static anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper  _resizeimage(anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _original,int _targetx,int _targety) throws Exception{
float _origratio = 0f;
float _targetratio = 0f;
float _scale = 0f;
anywheresoftware.b4a.objects.drawable.CanvasWrapper _c = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _b = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.RectWrapper _r = null;
int _w = 0;
int _h = 0;
 //BA.debugLineNum = 546;BA.debugLine="Sub ResizeImage(original As Bitmap, TargetX As Int, TargetY As Int) As Bitmap";
 //BA.debugLineNum = 547;BA.debugLine="Dim origRatio As Float = original.Width / original.Height";
_origratio = (float)(_original.getWidth()/(double)_original.getHeight());
 //BA.debugLineNum = 548;BA.debugLine="Dim targetRatio As Float = TargetX / TargetY";
_targetratio = (float)(_targetx/(double)_targety);
 //BA.debugLineNum = 549;BA.debugLine="Dim scale As Float";
_scale = 0f;
 //BA.debugLineNum = 551;BA.debugLine="If targetRatio > origRatio Then";
if (_targetratio>_origratio) { 
 //BA.debugLineNum = 552;BA.debugLine="scale = TargetY / original.Height";
_scale = (float)(_targety/(double)_original.getHeight());
 }else {
 //BA.debugLineNum = 554;BA.debugLine="scale = TargetX / original.Width";
_scale = (float)(_targetx/(double)_original.getWidth());
 };
 //BA.debugLineNum = 557;BA.debugLine="Dim C As Canvas";
_c = new anywheresoftware.b4a.objects.drawable.CanvasWrapper();
 //BA.debugLineNum = 558;BA.debugLine="Dim b As Bitmap";
_b = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 559;BA.debugLine="b.InitializeMutable(TargetX, TargetY)";
_b.InitializeMutable(_targetx,_targety);
 //BA.debugLineNum = 560;BA.debugLine="C.Initialize2(b)";
_c.Initialize2((android.graphics.Bitmap)(_b.getObject()));
 //BA.debugLineNum = 562;BA.debugLine="C.DrawColor(Colors.Transparent)";
_c.DrawColor(anywheresoftware.b4a.keywords.Common.Colors.Transparent);
 //BA.debugLineNum = 563;BA.debugLine="Dim r As Rect";
_r = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.RectWrapper();
 //BA.debugLineNum = 564;BA.debugLine="Dim w = original.Width * scale, h = original.Height * scale As Int";
_w = (int)(_original.getWidth()*_scale);
_h = (int)(_original.getHeight()*_scale);
 //BA.debugLineNum = 565;BA.debugLine="r.Initialize(TargetX / 2 - w / 2, TargetY / 2 - h / 2, TargetX / 2 + w / 2, TargetY / 2+ h / 2)";
_r.Initialize((int)(_targetx/(double)2-_w/(double)2),(int)(_targety/(double)2-_h/(double)2),(int)(_targetx/(double)2+_w/(double)2),(int)(_targety/(double)2+_h/(double)2));
 //BA.debugLineNum = 566;BA.debugLine="C.DrawBitmap(original, Null, r)";
_c.DrawBitmap((android.graphics.Bitmap)(_original.getObject()),(android.graphics.Rect)(anywheresoftware.b4a.keywords.Common.Null),(android.graphics.Rect)(_r.getObject()));
 //BA.debugLineNum = 567;BA.debugLine="Return b";
if (true) return _b;
 //BA.debugLineNum = 568;BA.debugLine="End Sub";
return null;
}
public static String  _savebtn_click() throws Exception{
 //BA.debugLineNum = 146;BA.debugLine="Sub SaveBtn_Click";
 //BA.debugLineNum = 148;BA.debugLine="End Sub";
return "";
}
public static String  _variantbox_itemclick(int _position,Object _value) throws Exception{
 //BA.debugLineNum = 570;BA.debugLine="Sub VariantBox_ItemClick (Position As Int, Value As Object)";
 //BA.debugLineNum = 571;BA.debugLine="RefreshPreview";
_refreshpreview();
 //BA.debugLineNum = 572;BA.debugLine="End Sub";
return "";
}
}
