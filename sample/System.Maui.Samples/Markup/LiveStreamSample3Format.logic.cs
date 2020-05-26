namespace System.Maui.Samples.Markup
{
	public partial class LiveStreamSample3Format : View
	{
		readonly State<int> count = 0;

		string Message() => $"I will run {count.Value} miles this month.";
		void Increment() => count.Value++;
		void Decrement() => count.Value--;
	}
}