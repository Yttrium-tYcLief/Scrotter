package com.yttrium.scrotter.designerscripts;
import anywheresoftware.b4a.objects.TextViewWrapper;
import anywheresoftware.b4a.objects.ImageViewWrapper;
import anywheresoftware.b4a.BA;


public class LS_about{

public static void LS_general(java.util.HashMap<String, anywheresoftware.b4a.objects.ViewWrapper<?>> views, int width, int height, float scale) {
anywheresoftware.b4a.keywords.LayoutBuilder.setScaleRate(0.3);
//BA.debugLineNum = 3;BA.debugLine="IconView.Left = 8%x"[about/General script]
views.get("iconview").setLeft((int)((8d / 100 * width)));
//BA.debugLineNum = 4;BA.debugLine="IconView.Top = 5%y"[about/General script]
views.get("iconview").setTop((int)((5d / 100 * height)));
//BA.debugLineNum = 5;BA.debugLine="IconView.Width = 24%x"[about/General script]
views.get("iconview").setWidth((int)((24d / 100 * width)));
//BA.debugLineNum = 6;BA.debugLine="IconView.Height = IconView.Width"[about/General script]
views.get("iconview").setHeight((int)((views.get("iconview").getWidth())));
//BA.debugLineNum = 7;BA.debugLine="ScrotterTitle.Top = IconView.Top"[about/General script]
views.get("scrottertitle").setTop((int)((views.get("iconview").getTop())));
//BA.debugLineNum = 8;BA.debugLine="ScrotterTitle.Height = IconView.Height - 5%y"[about/General script]
views.get("scrottertitle").setHeight((int)((views.get("iconview").getHeight())-(5d / 100 * height)));
//BA.debugLineNum = 9;BA.debugLine="ScrotterTitle.Width = 55%x"[about/General script]
views.get("scrottertitle").setWidth((int)((55d / 100 * width)));
//BA.debugLineNum = 10;BA.debugLine="ScrotterTitle.Right = 92%x"[about/General script]
views.get("scrottertitle").setLeft((int)((92d / 100 * width) - (views.get("scrottertitle").getWidth())));
//BA.debugLineNum = 11;BA.debugLine="ScrotterVers.Width = ScrotterTitle.Width"[about/General script]
views.get("scrottervers").setWidth((int)((views.get("scrottertitle").getWidth())));
//BA.debugLineNum = 12;BA.debugLine="ScrotterVers.Right = ScrotterTitle.Right"[about/General script]
views.get("scrottervers").setLeft((int)((views.get("scrottertitle").getLeft() + views.get("scrottertitle").getWidth()) - (views.get("scrottervers").getWidth())));
//BA.debugLineNum = 13;BA.debugLine="ScrotterVers.Bottom = IconView.Bottom"[about/General script]
views.get("scrottervers").setTop((int)((views.get("iconview").getTop() + views.get("iconview").getHeight()) - (views.get("scrottervers").getHeight())));
//BA.debugLineNum = 14;BA.debugLine="SettingsBtn.Height = 72dip"[about/General script]
views.get("settingsbtn").setHeight((int)((72d * scale)));
//BA.debugLineNum = 15;BA.debugLine="SettingsBtn.Bottom = 100%y - 5%x"[about/General script]
views.get("settingsbtn").setTop((int)((100d / 100 * height)-(5d / 100 * width) - (views.get("settingsbtn").getHeight())));
//BA.debugLineNum = 16;BA.debugLine="SettingsBtn.Left = 10%x"[about/General script]
views.get("settingsbtn").setLeft((int)((10d / 100 * width)));
//BA.debugLineNum = 17;BA.debugLine="SettingsBtn.Width = 80%x"[about/General script]
views.get("settingsbtn").setWidth((int)((80d / 100 * width)));
//BA.debugLineNum = 18;BA.debugLine="SettingsIcon.Height = 60dip"[about/General script]
views.get("settingsicon").setHeight((int)((60d * scale)));
//BA.debugLineNum = 19;BA.debugLine="SettingsIcon.Width = 60dip"[about/General script]
views.get("settingsicon").setWidth((int)((60d * scale)));
//BA.debugLineNum = 20;BA.debugLine="SettingsIcon.Left = SettingsBtn.Left + 6dip"[about/General script]
views.get("settingsicon").setLeft((int)((views.get("settingsbtn").getLeft())+(6d * scale)));
//BA.debugLineNum = 21;BA.debugLine="SettingsIcon.Top = SettingsBtn.Top + 6dip"[about/General script]
views.get("settingsicon").setTop((int)((views.get("settingsbtn").getTop())+(6d * scale)));

}
}