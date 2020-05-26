namespace System.Maui.Samples.Markup
{
	/// <summary>
	/// Factory eliminates new keyword and Children = { } initializers from markup.
	/// Users can create custom factories;select which factory to use with e.g. <code>using static System.Maui.Markup.Factory;</code>
	/// </summary>
	public static class Factory
	{
		public static Label Label(Binding<string> value = null) => new Label(value);
		public static Label Label(Func<string> value) => new Label(value);
		public static Spacer Spacer() => new Spacer();
		public static Button Button(Binding<string> text = null, Action action = null) => new Button(text, action);
		public static VStack VStack(params View[] children)
		{
			var stack = new VStack();
			for (int i = 0; i < children.Length; i++) stack.Insert(i, children[i]);
			return stack;
		}
	}

	/// <summary>This class illustrates several alternate strategies for reducing noise in markup</summary>
	public static class MarkupExtensions
	{
		// Combine two helpers into one:
		public static T Color<T>(this T view, Color color, Color background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, string color, string background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, Color color, string background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, string color, Color background) where T : View => view.Color(color).Background(background);

		public static T Font<T>(this T view, float size, string family) where T : Label => view.FontSize(size).FontFamily(family);

		// Eliminate instance value type name repetition: .Color(new Color("#ABCDEF")) -> .Color("#ABCDEF") by generating helpers from parameter ctor overloads:
		public static T Color<T>(this T view, string colorAsHex) where T : View => view.Color(new Color(colorAsHex));
		public static T Color<T>(this T view, float red, float green, float blue) where T : View => view.Color(new Color(red, green, blue));
		public static T Color<T>(this T view, float red, float green, float blue, float alpha) where T : View => view.Color(new Color(red, green, blue, alpha));

		// Eliminate static value enum/type name repetition: .TextAlignment(TextAlignment.Natural) -> .TextNatural() by generating a fluid method for each enum value / class static constant:
		public static T TextNatural  <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Natural  );
		public static T TextLeft     <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Left     );
		public static T TextRight    <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Right    );
		public static T TextCenter   <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Center   );
		public static T TextJustified<T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Justified);

		public static T LinesNoWrap<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.NoWrap);
		public static T LinesWordWrap<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.WordWrap);
		public static T LinesCharacterWrap<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.CharacterWrap);
		public static T LinesHeadTruncation<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.HeadTruncation);
		public static T LinesTailTruncation<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.TailTruncation);
		public static T LinesMiddleTruncation<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.MiddleTruncation);

		// Equivalent to above helpers but with subchain so .Text().Natural() instead of .TextNatural()
		public static Subchain<TLabel, TextAlignment> Text<TLabel>(this TLabel label) where TLabel : Label => new Subchain<TLabel, TextAlignment>(label);
		public static TLabel Natural  <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Natural  );
		public static TLabel Left     <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Left     );
		public static TLabel Right    <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Right    );
		public static TLabel Center   <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Center   );
		public static TLabel Justified<TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Justified);

		// Equivalent to above helpers but with subchain so .Lines().NoWrap() instead of .LinesNoWrap()
		public static Subchain<TLabel, LineBreakMode> Lines<TLabel>(this TLabel label) where TLabel : Label => new Subchain<TLabel, LineBreakMode>(label);
		public static TLabel NoWrap          <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.NoWrap          );
		public static TLabel WordWrap        <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.WordWrap        );
		public static TLabel CharacterWrap   <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.CharacterWrap   );
		public static TLabel HeadTruncation  <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.HeadTruncation  );
		public static TLabel TailTruncation  <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.TailTruncation  );
		public static TLabel MiddleTruncation<TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.MiddleTruncation);
	}

	public class Subchain<TParent, TChild> where TParent : class
	{
		public readonly TParent Parent;
		public Subchain(TParent parent) => Parent = parent;

		public static implicit operator TParent(Subchain<TParent, TChild> subchain) => subchain.Parent;
	}
}
