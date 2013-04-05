package com.yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_preview{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
views.get("loadbtn").setWidth((int)((50d / 100 * width)));
views.get("loadbtn").setLeft((int)(0d));
views.get("loadbtn").setTop((int)((100d / 100 * height) - (views.get("loadbtn").getHeight())));
views.get("savebtn").setWidth((int)((50d / 100 * width)));
views.get("savebtn").setLeft((int)((50d / 100 * width)));
views.get("savebtn").setTop((int)((100d / 100 * height) - (views.get("savebtn").getHeight())));
views.get("preview").setTop((int)(0d));
views.get("preview").setLeft((int)(0d));
views.get("preview").setWidth((int)((100d / 100 * width)));
views.get("preview").setHeight((int)((100d / 100 * height)-(views.get("loadbtn").getHeight())));

}
}