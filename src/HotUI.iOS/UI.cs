﻿
using System;
using HotUI;
using UIKit;

namespace HotUI.iOS {
	public static class UI {
		static bool hasInit;
		public static void Init ()
		{
			if (hasInit)
				return;
			hasInit = true;
			Registrar.Handlers.Register<Button, ButtonHandler> ();
			Registrar.Handlers.Register<TextField, TextFieldHandler> ();
			Registrar.Handlers.Register<Text, TextHandler> ();
			Registrar.Handlers.Register<Stack, StackHandler> ();
			Registrar.Handlers.Register<VStack, VStackHandler> ();
			Registrar.Handlers.Register<HStack, HStackHandler> ();
			//Registrar.Handlers.Register<WebView, WebViewHandler> ();
			Registrar.Handlers.Register<ScrollView, ScrollViewHandler> ();
			Registrar.Handlers.Register<Image, ImageHandler> ();
			Registrar.Handlers.Register<ListView, ListViewHandler> ();
			Registrar.Handlers.Register<View, ViewHandler> ();
			Registrar.Handlers.Register<ContentView, ContentViewHandler> ();
			ModalView.PerformPresent = (o) => {
				PresentingViewController.PresentViewController (o.ToViewController(), true,null);
			};
			ModalView.PerformDismiss = () => PresentingViewController.DismissModalViewController (true);
		}

		internal static UIViewController PresentingViewController {
			get {
				//if (overrideVc != null)
				//    return overrideVc;

				var window = UIApplication.SharedApplication.KeyWindow;
				var vc = window.RootViewController;
				while (vc.PresentedViewController != null)
					vc = vc.PresentedViewController;
				return vc;
			}
		}
	}
}
