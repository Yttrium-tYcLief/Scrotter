package com.yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_options{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
views.get("modelbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
views.get("variantbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
views.get("modelbox").setLeft((int)((3d / 100 * width)));
views.get("variantbox").setLeft((int)((3d / 100 * width)));
views.get("glosscheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
views.get("shadowcheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
views.get("undershadowcheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
views.get("shadowcheckbox").setLeft((int)((4d / 100 * width)));
views.get("glosscheckbox").setLeft((int)((4d / 100 * width)));
views.get("undershadowcheckbox").setLeft((int)((4d / 100 * width)));
views.get("undershadowcheckbox").setTop((int)((100d / 100 * height)-(4d / 100 * width) - (views.get("undershadowcheckbox").getHeight())));
views.get("shadowcheckbox").setTop((int)((views.get("undershadowcheckbox").getTop()) - (views.get("shadowcheckbox").getHeight())));
views.get("glosscheckbox").setTop((int)((views.get("shadowcheckbox").getTop()) - (views.get("glosscheckbox").getHeight())));
views.get("loading").setTop((int)((views.get("glosscheckbox").getTop()) - (views.get("loading").getHeight())));
views.get("loading").setTop((int)((views.get("variantbox").getTop() + views.get("variantbox").getHeight())-(((views.get("variantbox").getTop() + views.get("variantbox").getHeight())-(views.get("loading").getTop()))/2d)));
views.get("loading").setLeft((int)(((100d / 100 * width)-(views.get("loading").getWidth()))/2d));

}
}