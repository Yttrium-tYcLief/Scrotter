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
public static String  _activity_create(boolean _firsttime) throws Exception{
		Debug.PushSubsStack("Activity_Create (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("FirstTime", _firsttime);
 BA.debugLineNum = 33;BA.debugLine="Sub Activity_Create(FirstTime As Boolean)";
Debug.ShouldStop(1);
 BA.debugLineNum = 36;BA.debugLine="Msgbox(\"Welcome to Basic4android!\", \"\")";
Debug.ShouldStop(8);
anywheresoftware.b4a.keywords.Common.Msgbox("Welcome to Basic4android!","",mostCurrent.activityBA);
 BA.debugLineNum = 37;BA.debugLine="Activity.LoadLayout(\"Main\")";
Debug.ShouldStop(16);
mostCurrent._activity.LoadLayout("Main",mostCurrent.activityBA);
 BA.debugLineNum = 38;BA.debugLine="End Sub";
Debug.ShouldStop(32);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}

public static void initializeProcessGlobals() {
    if (mostCurrent != null && mostCurrent.activityBA != null) {
Debug.StartDebugging(mostCurrent.activityBA, 13588, new int[] {3}, "836a619c-49e5-4b92-9d2d-12e850c028e1");}

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

public static void killProgram() {
    
            if (main.previousOne != null) {
				Activity a = main.previousOne.get();
				if (a != null)
					a.finish();
			}

}
public static String  _globals() throws Exception{
 //BA.debugLineNum = 21;BA.debugLine="Sub Globals";
 //BA.debugLineNum = 25;BA.debugLine="Dim GlossCheckbox As CheckBox";
mostCurrent._glosscheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 26;BA.debugLine="Dim ModelBox As Spinner";
mostCurrent._modelbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 27;BA.debugLine="Dim ShadowCheckbox As CheckBox";
mostCurrent._shadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 28;BA.debugLine="Dim StretchCheckbox As CheckBox";
mostCurrent._stretchcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 29;BA.debugLine="Dim UnderShadowCheckbox As CheckBox";
mostCurrent._undershadowcheckbox = new anywheresoftware.b4a.objects.CompoundButtonWrapper.CheckBoxWrapper();
 //BA.debugLineNum = 30;BA.debugLine="Dim VariantBox As Spinner";
mostCurrent._variantbox = new anywheresoftware.b4a.objects.SpinnerWrapper();
 //BA.debugLineNum = 31;BA.debugLine="End Sub";
return "";
}
public static String  _glosscheckbox_checkedchange(boolean _checked) throws Exception{
		Debug.PushSubsStack("GlossCheckbox_CheckedChange (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Checked", _checked);
 BA.debugLineNum = 58;BA.debugLine="Sub GlossCheckbox_CheckedChange(Checked As Boolean)";
Debug.ShouldStop(33554432);
 BA.debugLineNum = 60;BA.debugLine="End Sub";
Debug.ShouldStop(134217728);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _loadbtn_click() throws Exception{
		Debug.PushSubsStack("Loadbtn_Click (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
 BA.debugLineNum = 64;BA.debugLine="Sub Loadbtn_Click";
Debug.ShouldStop(-2147483648);
 BA.debugLineNum = 66;BA.debugLine="End Sub";
Debug.ShouldStop(2);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _modelbox_itemclick(int _position,Object _value) throws Exception{
		Debug.PushSubsStack("ModelBox_ItemClick (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Position", _position);
Debug.locals.put("Value", _value);
 BA.debugLineNum = 55;BA.debugLine="Sub ModelBox_ItemClick (Position As Int, Value As Object)";
Debug.ShouldStop(4194304);
 BA.debugLineNum = 57;BA.debugLine="End Sub";
Debug.ShouldStop(16777216);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _process_globals() throws Exception{
 //BA.debugLineNum = 15;BA.debugLine="Sub Process_Globals";
 //BA.debugLineNum = 19;BA.debugLine="End Sub";
return "";
}
public static String  _savebtn_click() throws Exception{
		Debug.PushSubsStack("SaveBtn_Click (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
 BA.debugLineNum = 61;BA.debugLine="Sub SaveBtn_Click";
Debug.ShouldStop(268435456);
 BA.debugLineNum = 63;BA.debugLine="End Sub";
Debug.ShouldStop(1073741824);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _shadowcheckbox_checkedchange(boolean _checked) throws Exception{
		Debug.PushSubsStack("ShadowCheckbox_CheckedChange (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Checked", _checked);
 BA.debugLineNum = 52;BA.debugLine="Sub ShadowCheckbox_CheckedChange(Checked As Boolean)";
Debug.ShouldStop(524288);
 BA.debugLineNum = 54;BA.debugLine="End Sub";
Debug.ShouldStop(2097152);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _stretchcheckbox_checkedchange(boolean _checked) throws Exception{
		Debug.PushSubsStack("StretchCheckbox_CheckedChange (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Checked", _checked);
 BA.debugLineNum = 49;BA.debugLine="Sub StretchCheckbox_CheckedChange(Checked As Boolean)";
Debug.ShouldStop(65536);
 BA.debugLineNum = 51;BA.debugLine="End Sub";
Debug.ShouldStop(262144);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _tabswitcher_tabchanged() throws Exception{
		Debug.PushSubsStack("TabSwitcher_TabChanged (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
 BA.debugLineNum = 46;BA.debugLine="Sub TabSwitcher_TabChanged";
Debug.ShouldStop(8192);
 BA.debugLineNum = 48;BA.debugLine="End Sub";
Debug.ShouldStop(32768);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _undershadowcheckbox_checkedchange(boolean _checked) throws Exception{
		Debug.PushSubsStack("UnderShadowCheckbox_CheckedChange (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Checked", _checked);
 BA.debugLineNum = 43;BA.debugLine="Sub UnderShadowCheckbox_CheckedChange(Checked As Boolean)";
Debug.ShouldStop(1024);
 BA.debugLineNum = 45;BA.debugLine="End Sub";
Debug.ShouldStop(4096);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
public static String  _variantbox_itemclick(int _position,Object _value) throws Exception{
		Debug.PushSubsStack("VariantBox_ItemClick (main) ","main",0,mostCurrent.activityBA,mostCurrent);
try {
Debug.locals.put("Position", _position);
Debug.locals.put("Value", _value);
 BA.debugLineNum = 40;BA.debugLine="Sub VariantBox_ItemClick (Position As Int, Value As Object)";
Debug.ShouldStop(128);
 BA.debugLineNum = 42;BA.debugLine="End Sub";
Debug.ShouldStop(512);
return "";
}
catch (Exception e) {
			Debug.ErrorCaught(e);
			throw e;
		} 
finally {
			Debug.PopSubsStack();
		}}
  public Object[] GetGlobals() {
		return new Object[] {"Activity",_activity,"GlossCheckbox",_glosscheckbox,"ModelBox",_modelbox,"ShadowCheckbox",_shadowcheckbox,"StretchCheckbox",_stretchcheckbox,"UnderShadowCheckbox",_undershadowcheckbox,"VariantBox",_variantbox};
}
}
