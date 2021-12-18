﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.UnitTests.Mocks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Xunit;

namespace CommunityToolkit.Maui.UnitTests.Extensions;

public class ColorAnimationExtensions_Test : BaseTest
{
	[Fact]
	public async Task LabelTextColorTo_VerifyColorChanged()
	{
		Color originalBackgroundColor = Colors.Blue, updatedBackgroundColor = Colors.Red;

		var label = new Label { BackgroundColor = originalBackgroundColor };
		label.EnableAnimations();

		Assert.Equal(originalBackgroundColor, label.BackgroundColor);

		var isSuccessful = await label.TextColorTo(updatedBackgroundColor);

		Assert.True(isSuccessful);
		Assert.Equal(updatedBackgroundColor, label.BackgroundColor);
	}

	[Fact]
	public async Task LabelTextColorTo_VerifyColorChangedForDefaultBackgroundColor()
	{
		Color updatedBackgroundColor = Colors.Yellow;

		var label = new Label();
		label.EnableAnimations();

		var isSuccessful = await label.TextColorTo(updatedBackgroundColor);

		Assert.True(isSuccessful);
		Assert.Equal(updatedBackgroundColor, label.BackgroundColor);
	}

	[Fact]
	public async Task LabelTextColorTo_VerifyFalseWhenAnimationContextNotSet()
	{
		var label = new Label();
		Assert.Null(label.BackgroundColor);

		var isSuccessful = await label.TextColorTo(Colors.Red);

		Assert.False(isSuccessful);
		Assert.Equal(Colors.Transparent, label.BackgroundColor);
	}

	[Fact]
	public async Task LabelTextColorTo_DoesNotAllowNullVisualElement()
	{
		Label? label = null;

		await Assert.ThrowsAsync<NullReferenceException>(() => label?.TextColorTo(Colors.Red));
	}

	[Fact]
	public async Task LabelTextColorTo_DoesNotAllowNullColor()
	{
		var label = new Label();
		label.EnableAnimations();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		await Assert.ThrowsAsync<ArgumentNullException>(() => label.TextColorTo(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Fact]
	public async Task BackgroundColorTo_VerifyColorChanged()
	{
		Color originalBackgroundColor = Colors.Blue, updatedBackgroundColor = Colors.Red;

		VisualElement element = new Label { BackgroundColor = originalBackgroundColor };
		element.EnableAnimations();

		Assert.Equal(originalBackgroundColor, element.BackgroundColor);

		var isSuccessful = await element.BackgroundColorTo(updatedBackgroundColor);

		Assert.True(isSuccessful);
		Assert.Equal(updatedBackgroundColor, element.BackgroundColor);
	}

	[Fact]
	public async Task BackgroundColorTo_VerifyColorChangedForDefaultBackgroundColor()
	{
		Color updatedBackgroundColor = Colors.Yellow;

		VisualElement element = new Label();
		element.EnableAnimations();

		var isSuccessful = await element.BackgroundColorTo(updatedBackgroundColor);

		Assert.True(isSuccessful);
		Assert.Equal(updatedBackgroundColor, element.BackgroundColor);
	}

	[Fact]
	public async Task BackgroundColorTo_VerifyFalseWhenAnimationContextNotSet()
	{
		VisualElement element = new Label();
		Assert.Null(element.BackgroundColor);

		var isSuccessful = await element.BackgroundColorTo(Colors.Red);

		Assert.False(isSuccessful);
		Assert.Equal(Colors.Transparent, element.BackgroundColor);
	}

	[Fact]
	public async Task BackgroundColorTo_DoesNotAllowNullVisualElement()
	{
		VisualElement? element = null;

		await Assert.ThrowsAsync<NullReferenceException>(() => element?.BackgroundColorTo(Colors.Red));
	}

	[Fact]
	public async Task BackgroundColorTo_DoesNotAllowNullColor()
	{
		VisualElement element = new Label();
		element.EnableAnimations();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		await Assert.ThrowsAsync<ArgumentNullException>(() => element.BackgroundColorTo(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}