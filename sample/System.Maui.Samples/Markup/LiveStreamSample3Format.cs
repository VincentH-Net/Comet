using static System.Maui.Color;
using static System.Maui.Samples.Markup.Factory;
// Note that lines group helpers on category: content, border, layout
namespace System.Maui.Samples.Markup
{
	public partial class LiveStreamSample3Format
	{
		[Body]
		VStack body() => VStack (
			Spacer (),

			Label (Message)
				  .Color (White, "#7258F6") .Font (64, "DIN Alternate") .LinesWordWrap ()
				  .Margin (left: 25, right: 25) .FillHorizontal () .TextLeft (),

			Button ("Increment", Increment)
				   .Color (White) .FontSize (32)
				   .RoundedBorder (radius: 20, color: Transparent) .Shadow ()
				   .Margin (30) .FillHorizontal () .Frame (height: 76),

			Button ("Decrement", Decrement),

			Spacer ()
		);
	}
}