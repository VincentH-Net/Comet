using static System.Maui.Color;
using static System.Maui.Samples.Markup.Factory;

namespace System.Maui.Samples.Markup
{
	public class LiveStreamSample1LessNoise : View
	{
		readonly State<int> count = 0;

		[Body]
		VStack body() => VStack (
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
				.Font (32)
				.Color (White)
				.Shadow (),
			Button ("Decrement", () => count.Value--),
			Spacer ()
		);
	}
}