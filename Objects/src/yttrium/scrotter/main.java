package yttrium.scrotter;

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
	private static final boolean includeTitle = true;
    public static WeakReference<Activity> previousOne;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		if (isFirst) {
			processBA = new BA(this.getApplicationContext(), null, null, "yttrium.scrotter", "yttrium.scrotter.main");
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
		activityBA = new BA(this, layout, processBA, "yttrium.scrotter", "yttrium.scrotter.main");
        processBA.sharedProcessBA.activityBA = new java.lang.ref.WeakReference<BA>(activityBA);
        anywheresoftware.b4a.objects.ViewWrapper.lastId = 0;
        _activity = new ActivityWrapper(activityBA, "activity");
        anywheresoftware.b4a.Msgbox.isDismissing = false;
        initializeProcessGlobals();		
        initializeGlobals();
        
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Create, isFirst = " + isFirst + " **");
        processBA.raiseEvent2(null, true, "activity_create", false, isFirst);
		isFirst = false;
		if (mostCurrent == null || mostCurrent != this)
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

public anywheresoftware.b4a.keywords.Common __c = null;
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
 //BA.debugLineNum = 51;BA.debugLine="Sub Activity_Create(FirstTime As Boolean)";
 //BA.debugLineNum = 54;BA.debugLine="Activity.LoadLayout(\"Main\")";
mostCurrent._activity.LoadLayout("Main",mostCurrent.activityBA);
 //BA.debugLineNum = 56;BA.debugLine="TabSwitcher.AddTab(\"Preview\", \"preview.bal\")";
mostCurrent._tabswitcher.AddTab(mostCurrent.activityBA,"Preview","preview.bal");
 //BA.debugLineNum = 57;BA.debugLine="TabSwitcher.AddTab(\"Options\", \"options.bal\")";
mostCurrent._tabswitcher.AddTab(mostCurrent.activityBA,"Options","options.bal");
 //BA.debugLineNum = 58;BA.debugLine="ModelBox.AddAll(Array As String(\"ASUS Eee Pad Transformer\", \"Google Nexus 4\", \"Google Nexus 7\", \"Google Nexus 10\", \"Google Nexus S\", \"HTC 8S\", \"HTC 8X\", \"HTC Amaze 4G, Ruby\", \"HTC Desire\", \"HTC Desire C\", \"HTC Desire HD, HTC Inspire 4G\", \"HTC Desire Z, T-Mobile G2\", \"HTC Droid DNA\", \"HTC Evo 3D\", \"HTC Evo 4G LTE\", \"HTC Google Nexus One\", \"HTC Hero\", \"HTC Legend\", \"HTC One S\", \"HTC One V\", \"HTC One X, HTC One X+\", \"HTC Sensation\", \"HTC Titan\", \"HTC Vivid\", \"HTC Wildfire\", \"HTC Wildfire S\", \"LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II\", \"LG Optimus 2X\", \"Motorola Droid 2, Milestone 2\", \"Motorola Droid RAZR\", \"Motorola Droid RAZR M\", \"Motorola Xoom\", \"Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G\", \"Samsung Galaxy Ace, Galaxy Cooper\", \"Samsung Galaxy Note II\", \"Samsung Galaxy SII, Epic 4G Touch\", \"Samsung Galaxy SII Skyrocket\", \"Samsung Galaxy SIII\", \"Samsung Galaxy SIII Mini\", \"Samsung Galaxy TAB 10.1\", \"Samsung Google Galaxy Nexus\", \"Sony Ericsson Xperia J\", \"Sony Ericsson Xperia X10\"))";
mostCurrent._modelbox.AddAll(anywheresoftware.b4a.keywords.Common.ArrayToList(new String[]{"ASUS Eee Pad Transformer","Google Nexus 4","Google Nexus 7","Google Nexus 10","Google Nexus S","HTC 8S","HTC 8X","HTC Amaze 4G, Ruby","HTC Desire","HTC Desire C","HTC Desire HD, HTC Inspire 4G","HTC Desire Z, T-Mobile G2","HTC Droid DNA","HTC Evo 3D","HTC Evo 4G LTE","HTC Google Nexus One","HTC Hero","HTC Legend","HTC One S","HTC One V","HTC One X, HTC One X+","HTC Sensation","HTC Titan","HTC Vivid","HTC Wildfire","HTC Wildfire S","LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II","LG Optimus 2X","Motorola Droid 2, Milestone 2","Motorola Droid RAZR","Motorola Droid RAZR M","Motorola Xoom","Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G","Samsung Galaxy Ace, Galaxy Cooper","Samsung Galaxy Note II","Samsung Galaxy SII, Epic 4G Touch","Samsung Galaxy SII Skyrocket","Samsung Galaxy SIII","Samsung Galaxy SIII Mini","Samsung Galaxy TAB 10.1","Samsung Google Galaxy Nexus","Sony Ericsson Xperia J","Sony Ericsson Xperia X10"}));
 //BA.debugLineNum = 59;BA.debugLine="ModelBox.SelectedIndex = 1";
mostCurrent._modelbox.setSelectedIndex((int)(1));
 //BA.debugLineNum = 60;BA.debugLine="Msgbox(File.DirAssets & \"/Shadow\", \"test\")";
anywheresoftware.b4a.keywords.Common.Msgbox(anywheresoftware.b4a.keywords.Common.File.getDirAssets()+"/Shadow","test",mostCurrent.activityBA);
 //BA.debugLineNum = 61;BA.debugLine="End Sub";
return "";
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
 //BA.debugLineNum = 23;BA.debugLine="Sub Globals";
 //BA.debugLineNum = 26;BA.debugLine="Dim GlossCheckbox As CheckBox";
mostCurrent._glosscheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 27;BA.debugLine="Dim ModelBox As Spinner";
mostCurrent._modelbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 28;BA.debugLine="Dim ShadowCheckbox As CheckBox";
mostCurrent._shadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 29;BA.debugLine="Dim StretchCheckbox As CheckBox";
mostCurrent._stretchcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 30;BA.debugLine="Dim UnderShadowCheckbox As CheckBox";
mostCurrent._undershadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 31;BA.debugLine="Dim VariantBox As Spinner";
mostCurrent._variantbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 32;BA.debugLine="Dim TabSwitcher As TabHost";
mostCurrent._tabswitcher = new anywheresoftware.b4a.objects.TabHostWrapper();
 //BA.debugLineNum = 33;BA.debugLine="Dim Loadbtn As Button";
mostCurrent._loadbtn = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 34;BA.debugLine="Dim SaveBtn As Button";
mostCurrent._savebtn = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 35;BA.debugLine="Dim Preview As Panel";
mostCurrent._preview = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 36;BA.debugLine="Dim Image3 As Bitmap";
mostCurrent._image3 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 49;BA.debugLine="End Sub";
return "";
}
public static String  _loadbtn_click() throws Exception{
 //BA.debugLineNum = 79;BA.debugLine="Sub Loadbtn_Click";
 //BA.debugLineNum = 81;BA.debugLine="End Sub";
return "";
}
public static String  _modelbox_itemclick(int _position,Object _value) throws Exception{
 //BA.debugLineNum = 71;BA.debugLine="Sub ModelBox_ItemClick (Position As Int, Value As Object)";
 //BA.debugLineNum = 73;BA.debugLine="End Sub";
return "";
}
public static String  _process_globals() throws Exception{
 //BA.debugLineNum = 17;BA.debugLine="Sub Process_Globals";
 //BA.debugLineNum = 21;BA.debugLine="End Sub";
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
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _image2 = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.RectWrapper _destrect = null;
anywheresoftware.b4a.objects.ConcreteViewWrapper _previewview = null;
 //BA.debugLineNum = 83;BA.debugLine="Sub RefreshPreview";
 //BA.debugLineNum = 84;BA.debugLine="Dim MyCanvas As Canvas";
_mycanvas = new anywheresoftware.b4a.objects.drawable.CanvasWrapper();
 //BA.debugLineNum = 85;BA.debugLine="Dim Image1 As Bitmap";
_image1 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 86;BA.debugLine="Dim Gloss As Bitmap";
_gloss = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 87;BA.debugLine="Dim Shadow As Bitmap";
_shadow = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 88;BA.debugLine="Dim Undershadow As Bitmap";
_undershadow = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 89;BA.debugLine="Dim IndexH As Int";
_indexh = 0;
 //BA.debugLineNum = 90;BA.debugLine="Dim IndexW As Int";
_indexw = 0;
 //BA.debugLineNum = 99;BA.debugLine="Image1.Initialize(File.DirAssets, \"\") 'THIS IS WHERE DEVICE INITS BEGIN";
_image1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"");
 //BA.debugLineNum = 102;BA.debugLine="Dim Image2 As Bitmap";
_image2 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 103;BA.debugLine="Image2.InitializeMutable(Image1.Width, Image1.Height)";
_image2.InitializeMutable(_image1.getWidth(),_image1.getHeight());
 //BA.debugLineNum = 104;BA.debugLine="Dim DestRect As Rect";
_destrect = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.RectWrapper();
 //BA.debugLineNum = 105;BA.debugLine="DestRect.Initialize(0dip, 0dip, Image2.Width, Image2.Height)";
_destrect.Initialize(anywheresoftware.b4a.keywords.Common.DipToCurrent((int)(0)),anywheresoftware.b4a.keywords.Common.DipToCurrent((int)(0)),_image2.getWidth(),_image2.getHeight());
 //BA.debugLineNum = 106;BA.debugLine="Dim previewview As View";
_previewview = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 //BA.debugLineNum = 107;BA.debugLine="previewview.Initialize(\"lol\")";
_previewview.Initialize(mostCurrent.activityBA,"lol");
 //BA.debugLineNum = 108;BA.debugLine="MyCanvas.Initialize(previewview)";
_mycanvas.Initialize((android.view.View)(_previewview.getObject()));
 //BA.debugLineNum = 109;BA.debugLine="MyCanvas.DrawBitmap(Image2, Null, DestRect)";
_mycanvas.DrawBitmap((android.graphics.Bitmap)(_image2.getObject()),(android.graphics.Rect)(anywheresoftware.b4a.keywords.Common.Null),(android.graphics.Rect)(_destrect.getObject()));
 //BA.debugLineNum = 110;BA.debugLine="Preview.SetBackgroundImage(Image3)";
mostCurrent._preview.SetBackgroundImage((android.graphics.Bitmap)(mostCurrent._image3.getObject()));
 //BA.debugLineNum = 111;BA.debugLine="End Sub";
return "";
}
public static String  _savebtn_click() throws Exception{
 //BA.debugLineNum = 75;BA.debugLine="Sub SaveBtn_Click";
 //BA.debugLineNum = 77;BA.debugLine="End Sub";
return "";
}
public static String  _tabswitcher_tabchanged() throws Exception{
 //BA.debugLineNum = 63;BA.debugLine="Sub TabSwitcher_TabChanged";
 //BA.debugLineNum = 64;BA.debugLine="If TabSwitcher.CurrentTab = 0 Then RefreshPreview";
if (mostCurrent._tabswitcher.getCurrentTab()==0) { 
_refreshpreview();};
 //BA.debugLineNum = 65;BA.debugLine="End Sub";
return "";
}
public static String  _variantbox_itemclick(int _position,Object _value) throws Exception{
 //BA.debugLineNum = 67;BA.debugLine="Sub VariantBox_ItemClick (Position As Int, Value As Object)";
 //BA.debugLineNum = 69;BA.debugLine="End Sub";
return "";
}
}
