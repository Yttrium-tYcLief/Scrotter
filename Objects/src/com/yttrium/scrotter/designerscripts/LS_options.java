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
//BA.debugLineNum = 7;BA.debugLine="StretchCheckbox.Width = 100%x - 8%x"[options/General script]
views.get("stretchcheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
//BA.debugLineNum = 8;BA.debugLine="GlossCheckbox.Width = 100%x - 8%x"[options/General script]
views.get("glosscheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
//BA.debugLineNum = 9;BA.debugLine="ShadowCheckbox.Width = 100%x - 8%x"[options/General script]
views.get("shadowcheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
//BA.debugLineNum = 10;BA.debugLine="UnderShadowCheckbox.Width =100%x - 8%x"[options/General script]
views.get("undershadowcheckbox").setWidth((int)((100d / 100 * width)-(8d / 100 * width)));
//BA.debugLineNum = 11;BA.debugLine="StretchCheckbox.Left = 4%x"[options/General script]
views.get("stretchcheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 12;BA.debugLine="ShadowCheckbox.Left = 4%x"[options/General script]
views.get("shadowcheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 13;BA.debugLine="GlossCheckbox.Left = 4%x"[options/General script]
views.get("glosscheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 14;BA.debugLine="UnderShadowCheckbox.Left = 4%x"[options/General script]
views.get("undershadowcheckbox").setLeft((int)((4d / 100 * width)));
//BA.debugLineNum = 15;BA.debugLine="UnderShadowCheckbox.Bottom = 100%y- 4%x"[options/General script]
views.get("undershadowcheckbox").setTop((int)((100d / 100 * height)-(4d / 100 * width) - (views.get("undershadowcheckbox").getHeight())));
//BA.debugLineNum = 16;BA.debugLine="ShadowCheckbox.Bottom = UnderShadowCheckbox.Top"[options/General script]
views.get("shadowcheckbox").setTop((int)((views.get("undershadowcheckbox").getTop()) - (views.get("shadowcheckbox").getHeight())));
//BA.debugLineNum = 17;BA.debugLine="GlossCheckbox.Bottom = ShadowCheckbox.Top"[options/General script]
views.get("glosscheckbox").setTop((int)((views.get("shadowcheckbox").getTop()) - (views.get("glosscheckbox").getHeight())));
//BA.debugLineNum = 18;BA.debugLine="StretchCheckbox.Bottom = GlossCheckbox.Top"[options/General script]
views.get("stretchcheckbox").setTop((int)((views.get("glosscheckbox").getTop()) - (views.get("stretchcheckbox").getHeight())));
//BA.debugLineNum = 19;BA.debugLine="Loading.Bottom = StretchCheckbox.Top"[options/General script]
views.get("loading").setTop((int)((views.get("stretchcheckbox").getTop()) - (views.get("loading").getHeight())));
//BA.debugLineNum = 20;BA.debugLine="Loading.Top = VariantBox.Bottom - ((VariantBox.Bottom - Loading.Top) / 2)"[options/General script]
views.get("loading").setTop((int)((views.get("variantbox").getTop() + views.get("variantbox").getHeight())-(((views.get("variantbox").getTop() + views.get("variantbox").getHeight())-(views.get("loading").getTop()))/2d)));
//BA.debugLineNum = 21;BA.debugLine="Loading.Left = (100%x - Loading.Width) / 2"[options/General script]
views.get("loading").setLeft((int)(((100d / 100 * width)-(views.get("loading").getWidth()))/2d));

}
}