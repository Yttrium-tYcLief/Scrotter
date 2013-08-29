/**
*	Site-specific configuration settings for Highslide JS
*/
hs.graphicsDir = 'highslide/graphics/';
hs.showCredits = false;
hs.outlineType = 'custom';
hs.dimmingOpacity = 0.5;
hs.easing = 'easeInBack';
hs.easingClose = 'easeOutBack';
hs.expandDuration = 300;
hs.anchor = 'bottom'
hs.allowSizeReduction = false;
hs.allowMultipleInstances = false;
hs.blockRightClick = true;
hs.enableKeyListener = false;
hs.captionEval = 'this.a.title';
hs.registerOverlay({
	html: '<div class="closebutton" onclick="return hs.close(this)" title="Close"></div>',
	position: 'top right',
	useOnHtml: true,
	fade: 2 // fading the semi-transparent overlay looks bad in IE
});

