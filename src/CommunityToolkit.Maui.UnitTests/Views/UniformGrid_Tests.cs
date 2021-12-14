using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.UnitTests.Mocks;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using NSubstitute;
using Xunit;

namespace CommunityToolkit.Maui.UnitTests.Views;

public class UniformGridTests : BaseTest
{
	const double _childCount = 3;
	const double _childWidth = 20;
	const double _childHeight = 10;

	readonly UniformGrid _uniformGrid;
	readonly IView _uniformChild;

	public UniformGridTests()
	{
		_uniformChild = Substitute.For<IView>();

		_uniformGrid = new UniformGrid()
		{
			Children =
			{
				_uniformChild,
				_uniformChild,
				_uniformChild
			}
		};
	}

	[Fact]
	public void MeasureUniformGrid_NoWrap()
	{
		var expectedSize = new Size(_childWidth * _childCount, _childHeight);
		var childSize = new Size(_childWidth, _childHeight);

		SetupChildrenSize(childSize);

		var actualSize = _uniformGrid.Measure(_childWidth * _childCount, _childHeight * _childCount);

		Assert.Equal(expectedSize, actualSize);
	}

	[Fact]
	public void MeasureUniformGrid_WrapOnNextRow()
	{
		var expectedSize = new Size(_childWidth, _childHeight * _childCount);
		var childSize = new Size(_childWidth, _childHeight);

		SetupChildrenSize(childSize);

		var actualSize = _uniformGrid.Measure(_childWidth, _childHeight * _childCount);

		Assert.Equal(expectedSize, actualSize);
	}

	[Fact]
	public void ArrangeChildrenUniformGrid()
	{
		var expectedSize = new Size(_childWidth, _childHeight);

		SetupChildrenSize(expectedSize);

		var actualSize = _uniformGrid.ArrangeChildren(new Rectangle(0, 0, _childWidth * _childCount, _childHeight * _childCount));

		Assert.Equal(expectedSize, actualSize);
	}

	[Fact]
	public void MaxRowsArrangeChildrenUniformGrid()
	{
		var expectedSize = new Size(_childWidth, _childHeight);

		SetupChildrenSize(expectedSize);

		_uniformGrid.MaxColumns = 1;
		_uniformGrid.MaxRows = 1;

		var actualSize = _uniformGrid.Measure(double.PositiveInfinity, double.PositiveInfinity);

		Assert.Equal(expectedSize, actualSize);
	}

	void SetupChildrenSize(Size size)
	{
		_uniformChild.Measure(double.PositiveInfinity, double.PositiveInfinity).ReturnsForAnyArgs(size);
		_uniformGrid.Measure(_childWidth * _childCount, _childHeight * _childCount);
	}
}
