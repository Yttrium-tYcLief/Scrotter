package com.yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_options{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
//BA.debugLineNum = 3;BA.debugLine="ModelBox.Width = 100%x - 6%x"[options/General script]
views.get("modelbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 4;BA.debugLine="VariantBox.Width = 100%x - 6%x"[options/General script]
views.get("variantbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 5;BA.debugLine="ModelBox.Left = 3%x"[options/General script]
views.get("modelbox").setLeft((int)((3d / 100 * width)));
//BA.debugLineNum = 6;BA.debugLine="VariantBox.Left = 3%x"[options/General script]
views.get("variantbox").setLeft((int)((3d / 100 * width)));
//BA.debugLineNum = 7;BA.debugLine="StretchCheckbox.Width = 100%x - 6%x"[options/General script]
views.get("stretchcheckbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 8;BA.debugLine="GlossCheckbox.Width = 100%x - 6%x"[options/General script]
views.get("glosscheckbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 9;BA.debugLine="ShadowCheckbox.Width = 100%x - 6%x"[options/General script]
views.get("shadowcheckbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 10;BA.debugLine="UnderShadowCheckbox.Width =100%x - 6%x"[options/General script]
views.get("undershadowcheckbox").setWidth((int)((100d / 100 * width)-(6d / 100 * width)));
//BA.debugLineNum = 11;BA.debugLine="StretchCheckbox.Left = 4%x"[options/General script]
views.get("stretchcheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 12;BA.debugLine="ShadowCheckbox.Left = 4%x"[options/General script]
views.get("shadowcheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 13;BA.debugLine="GlossCheckbox.Left = 4%x"[options/General script]
views.get("glosscheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 14;BA.debugLine="UnderShadowCheckbox.Left = 4%x"[options/General script]
views.get("undershadowcheckbox").setLeft((int)((4d / 100 * width)));

}
}