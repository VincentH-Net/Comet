using static System.Maui.Color;
using static System.Maui.Samples.Markup.Factory;

namespace System.Maui.Samples.Markup
{
	public partial class LiveStreamSample2Split
	{
		[Body]
		VStack body() => VStack(
			Spacer(),
			Label(Message)
				.Color(White, "#7258F6")
				.TextLeft()
				.LinesWordWrap()
				.Margin(left: 25, right: 25)
				.FillHorizontal()
				.Font(64, "DIN Alternate"),
			Button("Increment", Increment)
				.RoundedBorder(radius: 20, color: Transparent)
				.Frame(height: 76)
				.Margin(30)
				.FillHorizontal()
				.Font(32)
				.Color(White)
				.Shadow(),
			Button("Decrement", Decrement),
			Spacer()
		);
	}
}
