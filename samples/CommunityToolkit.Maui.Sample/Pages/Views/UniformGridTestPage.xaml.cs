using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui;

namespace CommunityToolkit.Maui.Sample.Pages.Views;

public partial class UniformGridTestPage : BasePage
{
	readonly IReadOnlyList<Color> _colors = typeof(Colors)
											.GetFields(BindingFlags.Static | BindingFlags.Public)
											.ToDictionary(c => c.Name, c => (Color)(c.GetValue(null) ?? throw new InvalidOperationException()))
											.Values.ToList();

	public UniformGridTestPage() => InitializeComponent();

	void HandleAddButtonClicked(object? sender, System.EventArgs e)
	{
		const int widthRequest = 25;
		const int heightRequest = 25;
		var randomColor = _colors[new Random().Next(_colors.Count)];

		UniformGrid_Default.Children.Add(new BoxView
		{
			HeightRequest = widthRequest,
			WidthRequest = heightRequest,
			Color = randomColor
		});

		UniformGrid_MaxRows1.Children.Add(new BoxView
		{
			HeightRequest = widthRequest,
			WidthRequest = heightRequest,
			Color = randomColor
		});

		UniformGrid_MaxColumns1.Children.Add(new BoxView
		{
			HeightRequest = widthRequest,
			WidthRequest = heightRequest,
			Color = randomColor
		});

		UniformGrid_MaxRows2MaxColumns2.Children.Add(new BoxView
		{
			HeightRequest = widthRequest,
			WidthRequest = heightRequest,
			Color = randomColor
		});
	}
}
