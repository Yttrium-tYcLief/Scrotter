package com.yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_settings{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
views.get("iconview").setLeft((int)((8d / 100 * width)));
views.get("iconview").setTop((int)((5d / 100 * height)));
views.get("iconview").setWidth((int)((24d / 100 * width)));
views.get("iconview").setHeight((int)((views.get("iconview").getWidth())));
views.get("scrottertitle").setTop((int)((views.get("iconview").getTop())));
views.get("scrottertitle").setHeight((int)((views.get("iconview").getHeight())-(5d / 100 * height)));
views.get("scrottertitle").setWidth((int)((55d / 100 * width)));
views.get("scrottertitle").setLeft((int)((92d / 100 * width) - (views.get("scrottertitle").getWidth())));
views.get("scrottervers").setWidth((int)((views.get("scrottertitle").getWidth())));
views.get("scrottervers").setLeft((int)((views.get("scrottertitle").getLeft() + views.get("scrottertitle").getWidth()) - (views.get("scrottervers").getWidth())));
views.get("scrottervers").setTop((int)((views.get("iconview").getTop() + views.get("iconview").getHeight()) - (views.get("scrottervers").getHeight())));

}
}