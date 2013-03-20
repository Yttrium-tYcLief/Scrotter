package yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_main{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
//BA.debugLineNum = 3;BA.debugLine="TabSwitcher.Width = 100%x"[main/General script]
views.get("tabswitcher").setWidth((int)((100d / 100 * width)));
//BA.debugLineNum = 4;BA.debugLine="TabSwitcher.Height = 100%y"[main/General script]
views.get("tabswitcher").setHeight((int)((100d / 100 * height)));

}
}