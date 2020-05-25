using System.Drawing;
using System.Maui.Graphics;
using static System.Maui.Samples.Markup.Factory;
using static System.Maui.Color;

namespace System.Maui.Samples.Markup
{
	public class LiveStreamSample : View
	{
		readonly State<int> count = 0;

		private static readonly LinearGradient LinearGradient = new LinearGradient(
			new[] { Color.Salmon, Color.CornflowerBlue },
			new PointF(0, 0),
			new PointF(1, 0));

		[Body]
		View body() => new ZStack
		{
			new ShapeView(new Rectangle()
				.Fill(LinearGradient)
				.Style(DrawingStyle.StrokeFill)),

			new VStack
			{
				new Spacer(),
				new Label(() => $"I will run {count.Value} miles this month.")
					.Color(Color.White)
					.TextAlignment(TextAlignment.Left)
					.LineBreakMode(LineBreakMode.WordWrap)
					.Margin(left:25, right:25)
					.FillHorizontal()
					.FontSize(64)
					.FontFamily("DIN Alternate")
					.Background("#7258F6"),
				new Button("Increment", () => count.Value++)
					.RoundedBorder(radius: 20, color: Color.Transparent)
					.Frame(height:76)
					.Margin(30)
					.FillHorizontal()
					.FontSize(32)
					.FontFamily("DIN Alternate")
					.Color(Color.White)
					.Shadow(),
				new Button("Decrement", () => count.Value--),
				new Spacer()
			}
		};

		View bodyOriginal() => new VStack
		{
			new Spacer(),
			new Label(() => $"I will run {count.Value} miles this month.")
				.Color(Color.White)
				.TextAlignment(TextAlignment.Left)
				.LineBreakMode(LineBreakMode.WordWrap)
				.Margin(left:25, right:25)
				.FillHorizontal()
				.FontSize(64)
				.FontFamily("DIN Alternate")
				.Background("#7258F6"),
			new Button("Increment", () => count.Value++)
				.RoundedBorder(radius: 20, color: Color.Transparent)
				.Frame(height:76)
				.Margin(30)
				.FillHorizontal()
				.FontSize(32)
				.FontFamily("DIN Alternate")
				.Color(Color.White)
				.Shadow(),
			new Button("Decrement", () => count.Value--),
			new Spacer()
		};

		VStack bodyLessNoise() => VStack (
			Spacer (),
			Label (() => $"I will run {count.Value} miles this month.")
				.Color (White, "#7258F6")
				.TextLeft ()
				.LinesWordWrap ()
				.Margin (left:25, right:25)
				.FillHorizontal ()
				.Font (64, "DIN Alternate"),
			Button ("Increment", () => count.Value++)
				.RoundedBorder (radius:20, color:Transparent)
				.Frame (height:76)
				.Margin (30)
				.FillHorizontal ()
				.FontSize (32)
				.Color (White)
				.Shadow (),
			Button ("Decrement", () => count.Value--),
			Spacer ()
		);


		VStack bodySplit() => VStack (
			Spacer (),
			Label (Message)
				.Color (White, "#7258F6")
				.TextLeft ()
				.LinesWordWrap ()
				.Margin (left: 25, right: 25)
				.FillHorizontal ()
				.Font (64, "DIN Alternate"),
			Button ("Increment", Increment)
				.RoundedBorder (radius: 20, color: Transparent)
				.Frame (height: 76)
				.Margin (30)
				.FillHorizontal ()
				.FontSize (32)
				.Color (White)
				.Shadow (),
			Button ("Decrement", Decrement),
			Spacer ()
		);

		// Lines group helpers on category: content, border, layout
		VStack bodyFormat() => VStack (
			Spacer(),

			Label (Message)
				  .Color (White, "#7258F6") .Font (64, "DIN Alternate") .LinesWordWrap ()
				  .Margin (left: 25, right: 25) .FillHorizontal() .TextLeft (),

			Button ("Increment", Increment)
				   .Color (White) .FontSize (32)
				   .RoundedBorder (radius: 20, color: Transparent) .Shadow ()
				   .Margin (30) .FillHorizontal () .Frame(height: 76),

			Button ("Decrement", Decrement),

			Spacer ()
		);

		string Message() => $"I will run {count.Value} miles this month.";
		void Increment() => count.Value++;
		void Decrement() => count.Value--;
	}

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

	public static class MarkupExtensions
	{

		// Generate fluid method for each enum value / class static constant:
		public static T Color_Black<T>(this T view) where T : View => view.Color(Maui.Color.Black);
		public static T Color_White<T>(this T view) where T : View => view.Color(Maui.Color.White);

		public static T Background_Black<T>(this T view) where T : View => view.Background(Maui.Color.Black);
		public static T Background_White<T>(this T view) where T : View => view.Background(Maui.Color.White);

		// Regular helpers from parameter ctor overloads:
		public static T Color<T>(this T view, string colorAsHex) where T : View => view.Color(new Color(colorAsHex));
		public static T Color<T>(this T view, float red, float green, float blue) where T : View => view.Color(new Color(red, green, blue));
		public static T Color<T>(this T view, float red, float green, float blue, float alpha) where T : View => view.Color(new Color(red, green, blue, alpha));

		// Eliminate helper name, use parameter overload
		public static T Color<T>(this T view, Color color, Color background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, string color, string background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, Color color, string background) where T : View => view.Color(color).Background(background);
		public static T Color<T>(this T view, string color, Color background) where T : View => view.Color(color).Background(background);

		public static T TextNatural  <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Natural  );
		public static T TextLeft     <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Left     );
		public static T TextRight    <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Right    );
		public static T TextCenter   <T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Center   );
		public static T TextJustified<T>(this T view) where T : Label => view.TextAlignment(Maui.TextAlignment.Justified);

		public static Subchain<TLabel, TextAlignment> Text<TLabel>(this TLabel label) where TLabel : Label => new Subchain<TLabel, TextAlignment>(label);
		public static TLabel Natural  <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Natural  );
		public static TLabel Left     <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Left     );
		public static TLabel Right    <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Right    );
		public static TLabel Center   <TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Center   );
		public static TLabel Justified<TLabel>(this Subchain<TLabel, TextAlignment> subchain) where TLabel : Label => subchain.Parent.TextAlignment(Maui.TextAlignment.Justified);

		public static Subchain<TLabel, LineBreakMode> Lines<TLabel>(this TLabel label) where TLabel : Label => new Subchain<TLabel, LineBreakMode>(label);
		public static TLabel NoWrap          <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.NoWrap          );
		public static TLabel WordWrap        <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.WordWrap        );
		public static TLabel CharacterWrap   <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.CharacterWrap   );
		public static TLabel HeadTruncation  <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.HeadTruncation  );
		public static TLabel TailTruncation  <TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.TailTruncation  );
		public static TLabel MiddleTruncation<TLabel>(this Subchain<TLabel, LineBreakMode> subchain) where TLabel : Label => subchain.Parent.LineBreakMode(Maui.LineBreakMode.MiddleTruncation);

		public static T LinesNoWrap<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.NoWrap          );
		public static T LinesWordWrap        <T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.WordWrap        );
		public static T LinesCharacterWrap   <T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.CharacterWrap   );
		public static T LinesHeadTruncation  <T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.HeadTruncation  );
		public static T LinesTailTruncation  <T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.TailTruncation  );
		public static T LinesMiddleTruncation<T>(this T view) where T : Label => view.LineBreakMode(Maui.LineBreakMode.MiddleTruncation);

		public static T Font<T>(this T view, float size, string family) where T : Label => view.FontSize(size).FontFamily(family);
	}

	// TODO: subchains is probably a standard pattern with fluent api's? -> look it up and align
	public struct Subchain<TParent, TChild> // struct to prevent adding GC pressure
	{
		public readonly TParent Parent;
		public Subchain(TParent parent) => Parent = parent;

		public static implicit operator TParent(Subchain<TParent, TChild> subchain) => subchain.Parent;
	}
}
