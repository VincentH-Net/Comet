namespace System.Maui.Samples.Markup
{
	public class LiveStreamSample : View
	{
		readonly State<int> count = 0;

		[Body]
		View body() => new VStack
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
	}
}
